using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace FisioKH
{
    public partial class FisioKHCalendar : UserControl
    {
        private Panel loadingOverlay;
        private ProgressBar loadingBar;

        private const int HourHeight = 38;
        private const int HeaderHeight = 30;
        private const int StartHour = 8;
        private const int EndHour = 21;

        // overlap / spacing tuning
        private const int OverlapGap = 4;
        private const int OuterPad = 2;
        private const int MinEventWidth = 80;

        private Panel panelMonth;
        private Panel panelWeek;
        private Panel panelDay;

        public event Func<DateTime, DateTime, Task<DataTable>> RequestDataAsync;
        public event EventHandler<CalendarEventKH> EventClick;

        private List<CalendarEventKH> Events = new List<CalendarEventKH>();

        private FlowLayoutPanel topBar;
        private Button btnMonth, btnWeek, btnDay, btnPrev, btnNext;
        private Label lblCurrentDay;
        private DateTimePicker dtpJump;

        enum CalendarView { Month, Week, Day }
        private CalendarView currentView = CalendarView.Day;

        [Browsable(false)]
        public DataTable DataSource { get; set; }

        [Browsable(false)]
        public DateTime CurrentDate { get; set; }

        public FisioKHCalendar()
        {
            InitializeComponent();

            Width = 1200;
            Height = 900;

            BuildTopBar();
            BuildLoadingOverlay();

            panelMonth = CreateCalendarPanel();
            panelWeek = CreateCalendarPanel();
            panelDay = CreateCalendarPanel();

            Controls.Add(panelMonth);
            Controls.Add(panelWeek);
            Controls.Add(panelDay);

            Resize += (s, e) => RefreshCurrentView();

            this.Load += FisioKHCalendar_Load;
        }

        private async void FisioKHCalendar_Load(object sender, EventArgs e)
        {
            CurrentDate = DateTime.Today;

            dtpJump.ValueChanged -= DtpJump_ValueChanged;
            dtpJump.Value = CurrentDate;
            dtpJump.ValueChanged += DtpJump_ValueChanged;

            currentView = CalendarView.Day;
            await ShowDayAsync();
        }

        private Panel CreateCalendarPanel()
        {
            var p = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                Visible = false
            };

            // reduce flicker when repainting lots of controls
            SetDoubleBuffered(p, true);
            return p;
        }

        private static void SetDoubleBuffered(Control control, bool enabled)
        {
            try
            {
                typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.SetValue(control, enabled, null);
            }
            catch { /* ignore */ }
        }

        // ================= TOP BAR =================

        private void BuildLoadingOverlay()
        {
            loadingOverlay = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(120, Color.White),
                Visible = false
            };

            loadingBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Width = 200,
                Height = 25
            };

            loadingOverlay.Controls.Add(loadingBar);
            Controls.Add(loadingOverlay);

            loadingOverlay.BringToFront();

            loadingOverlay.Resize += (s, e) =>
            {
                loadingBar.Left = (loadingOverlay.Width - loadingBar.Width) / 2;
                loadingBar.Top = (loadingOverlay.Height - loadingBar.Height) / 2;
            };
        }

        private void BuildTopBar()
        {
            topBar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 35
            };

            btnMonth = new Button { Text = "Mes", Width = 60, Height = 30 };
            btnWeek = new Button { Text = "Semana", Width = 80, Height = 30 };
            btnDay = new Button { Text = "Día", Width = 60, Height = 30 };

            btnPrev = new Button { Text = "<", Width = 30, Height = 30 };
            btnNext = new Button { Text = ">", Width = 30, Height = 30 };

            lblCurrentDay = new Label
            {
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 7, 0, 0)
            };

            dtpJump = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Width = 150
            };

            dtpJump.ValueChanged += DtpJump_ValueChanged;

            btnMonth.Click += async (s, e) => await ShowMonthAsync();
            btnWeek.Click += async (s, e) => await ShowWeekAsync();
            btnDay.Click += async (s, e) => await ShowDayAsync();

            btnPrev.Click += async (s, e) => await ChangeDateAsync(-1);
            btnNext.Click += async (s, e) => await ChangeDateAsync(1);

            topBar.Controls.AddRange(new Control[]
            {
                btnMonth, btnWeek, btnDay,
                btnPrev, lblCurrentDay, btnNext,
                dtpJump
            });

            Controls.Add(topBar);
        }

        // ================= NAVIGATION =================

        private async Task ChangeDateAsync(int delta)
        {
            if (currentView == CalendarView.Month)
                CurrentDate = CurrentDate.AddMonths(delta);
            else if (currentView == CalendarView.Week)
                CurrentDate = CurrentDate.AddDays(delta * 7);
            else
                CurrentDate = CurrentDate.AddDays(delta);

            UpdateDayNavigation();
            await ReloadDataAsync();
        }

        private void UpdateDayNavigation()
        {
            if (currentView == CalendarView.Day)
                lblCurrentDay.Text = CurrentDate.ToString("dddd, dd MMMM yyyy");
            else if (currentView == CalendarView.Month)
                lblCurrentDay.Text = CurrentDate.ToString("MMMM yyyy");
            else
                lblCurrentDay.Text = $"Semana de {CurrentDate:dd MMM yyyy}";

            dtpJump.ValueChanged -= DtpJump_ValueChanged;
            dtpJump.Value = CurrentDate;
            dtpJump.ValueChanged += DtpJump_ValueChanged;
        }

        private async void DtpJump_ValueChanged(object sender, EventArgs e)
        {
            CurrentDate = dtpJump.Value.Date;
            await ReloadDataAsync();
        }

        // ================= DATA =================

        private void LoadEventsFromDataSource()
        {
            Events.Clear();
            if (DataSource == null) return;

            foreach (DataRow r in DataSource.Rows)
            {
                Events.Add(new CalendarEventKH
                {
                    Title = r["Title"].ToString(),
                    Start = (DateTime)r["Start"],
                    End = (DateTime)r["End"],
                    Color = GoogleColorToSystem(r["ColorId"].ToString()),
                    ColorId = r["ColorId"].ToString()
                });
            }
        }

        public async Task ReloadDataFromFormAsync()
        {
            await ReloadDataAsync();
        }

        private async Task ReloadDataAsync()
        {
            if (RequestDataAsync == null)
                return;

            ShowLoading(true);

            try
            {
                DateTime from, to;

                if (currentView == CalendarView.Month)
                {
                    var first = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
                    from = first;
                    to = first.AddMonths(1);
                }
                else if (currentView == CalendarView.Week)
                {
                    var start = CurrentDate.AddDays(-(int)CurrentDate.DayOfWeek);
                    from = start;
                    to = start.AddDays(7);
                }
                else
                {
                    from = CurrentDate.Date;
                    to = CurrentDate.Date.AddDays(1);
                }

                var table = await RequestDataAsync(from, to);

                if (table != null)
                {
                    DataSource = table;
                    LoadEventsFromDataSource();
                    RefreshCurrentView();
                }
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private void ShowLoading(bool show)
        {
            loadingOverlay.Visible = show;
            loadingOverlay.BringToFront();

            topBar.Enabled = !show;
            panelMonth.Enabled = !show;
            panelWeek.Enabled = !show;
            panelDay.Enabled = !show;
        }

        // ================= VIEW SWITCH =================

        private async Task ShowMonthAsync()
        {
            currentView = CalendarView.Month;
            panelMonth.Visible = true;
            panelWeek.Visible = false;
            panelDay.Visible = false;
            panelMonth.BringToFront();
            UpdateDayNavigation();
            await ReloadDataAsync();
        }

        private async Task ShowWeekAsync()
        {
            currentView = CalendarView.Week;
            panelMonth.Visible = false;
            panelWeek.Visible = true;
            panelDay.Visible = false;
            panelWeek.BringToFront();
            UpdateDayNavigation();
            await ReloadDataAsync();
        }

        private async Task ShowDayAsync()
        {
            currentView = CalendarView.Day;
            panelMonth.Visible = false;
            panelWeek.Visible = false;
            panelDay.Visible = true;
            panelDay.BringToFront();
            UpdateDayNavigation();
            await ReloadDataAsync();
            CenterDayViewOnNow();
        }

        public void RefreshCurrentView()
        {
            LoadEventsFromDataSource();

            if (currentView == CalendarView.Month) RenderMonthView();
            if (currentView == CalendarView.Week) RenderWeekView();
            if (currentView == CalendarView.Day) RenderDayView();

            UpdateDayNavigation();
        }

        // ================= MONTH VIEW =================

        private void RenderMonthView()
        {
            panelMonth.Controls.Clear();

            int cols = 7;
            int cellWidth = Math.Max(120, panelMonth.ClientSize.Width / cols);
            int cellHeight = 110;

            DateTime first = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            int offset = (int)first.DayOfWeek;
            int days = DateTime.DaysInMonth(first.Year, first.Month);

            int day = 1 - offset;
            int row = 0;

            while (day <= days)
            {
                for (int col = 0; col < 7; col++)
                {
                    Panel cell = new Panel
                    {
                        Location = new Point(col * cellWidth, row * cellHeight),
                        Size = new Size(cellWidth - 1, cellHeight - 1),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White
                    };
                    SetDoubleBuffered(cell, true);

                    if (day > 0 && day <= days)
                    {
                        DateTime date = new DateTime(first.Year, first.Month, day);

                        if (date.Date == DateTime.Today)
                            cell.BackColor = Color.FromArgb(230, 245, 255);

                        cell.Controls.Add(new Label
                        {
                            Text = day.ToString(),
                            Dock = DockStyle.Top,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold)
                        });

                        // Show events as compact "cards" (Google-like look)
                        // Month cells are list-like, but still benefit from hover + shadow.
                        int y = 22;
                        int maxLines = Math.Max(1, (cell.Height - y - 4) / 20);

                        foreach (var ev in Events.Where(e => e.Start.Date == date).OrderBy(e => e.Start).Take(maxLines))
                        {
                            var sz = new Size(cell.Width - 6, 18);
                            var pt = new Point(3, y);
                            cell.Controls.Add(CreateEventPanel(ev, sz, pt));
                            y += 20;
                        }

                        // optional "+N more" indicator
                        int total = Events.Count(e => e.Start.Date == date);
                        if (total > maxLines)
                        {
                            cell.Controls.Add(new Label
                            {
                                Text = $"+{total - maxLines} más",
                                AutoSize = true,
                                ForeColor = Color.DimGray,
                                Location = new Point(3, cell.Height - 18)
                            });
                        }
                    }

                    panelMonth.Controls.Add(cell);
                    day++;
                }
                row++;
            }
        }

        // ================= WEEK VIEW =================

        private void RenderWeekView()
        {
            panelWeek.Controls.Clear();

            DateTime start = CurrentDate.AddDays(-(int)CurrentDate.DayOfWeek);
            int labelWidth = 60;
            int colWidth = (panelWeek.ClientSize.Width - labelWidth) / 7;

            string[] dias = { "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb" };

            for (int d = 0; d < 7; d++)
            {
                panelWeek.Controls.Add(new Label
                {
                    Text = dias[d] + " " + start.AddDays(d).Day,
                    Location = new Point(labelWidth + d * colWidth, 0),
                    Size = new Size(colWidth, HeaderHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                });
            }

            for (int h = StartHour; h <= EndHour; h++)
            {
                int y = HeaderHeight + (h - StartHour) * HourHeight;

                panelWeek.Controls.Add(new Label
                {
                    Text = DateTime.Today.AddHours(h).ToString("hh:mm tt"),
                    Location = new Point(0, y),
                    Size = new Size(labelWidth, HourHeight),
                    TextAlign = ContentAlignment.TopRight
                });

                for (int d = 0; d < 7; d++)
                {
                    panelWeek.Controls.Add(new Panel
                    {
                        Location = new Point(labelWidth + d * colWidth, y),
                        Size = new Size(colWidth, 1),
                        BackColor = Color.LightGray
                    });
                }
            }

            // Week overlaps: compute per-day layout and render side-by-side in each column
            for (int d = 0; d < 7; d++)
            {
                DateTime date = start.AddDays(d).Date;
                var layouts = BuildLayoutForDate(date);

                int dayLeft = labelWidth + d * colWidth;
                int usableW = colWidth;

                foreach (var l in layouts)
                {
                    int y = HeaderHeight + (int)((l.Event.Start.Hour + l.Event.Start.Minute / 60.0 - StartHour) * HourHeight);
                    int h = Math.Max(28, (int)((l.Event.End - l.Event.Start).TotalMinutes / 60 * HourHeight));

                    int slotW = Math.Max(MinEventWidth, usableW / Math.Max(1, l.SlotCount));
                    int x = dayLeft + l.SlotIndex * slotW;

                    int cardX = x + OuterPad;
                    int cardW = Math.Max(MinEventWidth, slotW - OverlapGap - OuterPad);

                    panelWeek.Controls.Add(CreateEventPanel(l.Event,
                        new Size(cardW, h),
                        new Point(cardX, y)));
                }
            }
        }

        // ================= DAY VIEW =================

        private void RenderDayView()
        {
            panelDay.Controls.Clear();
            int labelWidth = 60;

            for (int h = StartHour; h <= EndHour; h++)
            {
                int y = HeaderHeight + (h - StartHour) * HourHeight;

                panelDay.Controls.Add(new Label
                {
                    Text = DateTime.Today.AddHours(h).ToString("hh:mm tt"),
                    Location = new Point(0, y),
                    Size = new Size(labelWidth, HourHeight),
                    TextAlign = ContentAlignment.TopRight
                });

                panelDay.Controls.Add(new Panel
                {
                    Location = new Point(labelWidth, y),
                    Size = new Size(panelDay.ClientSize.Width - labelWidth, 1),
                    BackColor = Color.LightGray
                });
            }

            var layouts = BuildLayoutForDate(CurrentDate.Date);
            int width = panelDay.ClientSize.Width - labelWidth;

            foreach (var l in layouts)
            {
                int y = HeaderHeight + (int)((l.Event.Start.Hour + l.Event.Start.Minute / 60.0 - StartHour) * HourHeight);
                int h = Math.Max(28, (int)((l.Event.End - l.Event.Start).TotalMinutes / 60 * HourHeight));

                int slotW = Math.Max(MinEventWidth, width / Math.Max(1, l.SlotCount));
                int x = labelWidth + l.SlotIndex * slotW;

                int cardX = x + OuterPad;
                int cardW = Math.Max(MinEventWidth, slotW - OverlapGap - OuterPad);

                panelDay.Controls.Add(CreateEventPanel(l.Event,
                    new Size(cardW, h),
                    new Point(cardX, y)));
            }
        }

        private void CenterDayViewOnNow()
        {
            if (CurrentDate.Date != DateTime.Today) return;

            int y = HeaderHeight + (int)((DateTime.Now.Hour + DateTime.Now.Minute / 60.0 - StartHour) * HourHeight);
            panelDay.AutoScrollPosition = new Point(0, Math.Max(0, y - panelDay.Height / 2));
        }

        // ================= EVENT PANEL (hover + shadow + overlap-friendly) =================

        private Color GetSoftColor(Color c)
        {
            int r = (c.R + 255) / 2;
            int g = (c.G + 255) / 2;
            int b = (c.B + 255) / 2;
            return Color.FromArgb(r, g, b);
        }

        private sealed class EventPanel : Panel
        {
            public Color AccentColor { get; set; } = Color.DeepSkyBlue;
            public Color BaseFill { get; set; } = Color.LightBlue;
            public bool Hovered { get; private set; }
            public int CornerRadius { get; set; } = 6;
            public int StripeWidth { get; set; } = 5;

            public EventPanel()
            {
                DoubleBuffered = true;
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.UserPaint |
                         ControlStyles.ResizeRedraw, true);

                MouseEnter += (s, e) => { Hovered = true; Invalidate(); BringToFront(); };
                MouseLeave += (s, e) => { Hovered = false; Invalidate(); };
                MouseDown += (s, e) => BringToFront();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, Width - 1, Height - 1);

                DrawShadow(g, rect, CornerRadius);

                var fill = Hovered ? ControlPaint.Light(AccentColor, 0.45f) : BaseFill;
                using (var path = RoundedRect(rect, CornerRadius))
                using (var b = new SolidBrush(fill))
                    g.FillPath(b, path);

                if (Hovered)
                {
                    using (var path = RoundedRect(rect, CornerRadius))
                    using (var pen = new Pen(Color.FromArgb(160, AccentColor), 1f))
                        g.DrawPath(pen, path);
                }

                using (var sb = new SolidBrush(AccentColor))
                    g.FillRectangle(sb, 0, 0, StripeWidth, Height);

                base.OnPaint(e);
            }

            private static GraphicsPath RoundedRect(Rectangle r, int radius)
            {
                int d = radius * 2;
                var path = new GraphicsPath();
                path.AddArc(r.X, r.Y, d, d, 180, 90);
                path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                return path;
            }

            private static void DrawShadow(Graphics g, Rectangle rect, int radius)
            {
                for (int i = 3; i >= 1; i--)
                {
                    int alpha = 16 / i; // subtle
                    var shadowRect = new Rectangle(rect.X + i, rect.Y + i, rect.Width, rect.Height);
                    using (var path = RoundedRect(shadowRect, radius))
                    using (var b = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0)))
                        g.FillPath(b, path);
                }
            }
        }

        private Panel CreateEventPanel(CalendarEventKH ev, Size size, Point loc)
        {
            var p = new EventPanel
            {
                Size = size,
                Location = loc,
                AccentColor = ev.Color,
                BaseFill = GetSoftColor(ev.Color),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand,
                Padding = new Padding(5 + 6, 4, 4, 4)
            };

            // ensure children clip to rounded area
            p.SizeChanged += (s, e) =>
            {
                var gp = new GraphicsPath();
                int radius = p.CornerRadius;
                gp.AddArc(0, 0, radius, radius, 180, 90);
                gp.AddArc(p.Width - radius, 0, radius, radius, 270, 90);
                gp.AddArc(p.Width - radius, p.Height - radius, radius, radius, 0, 90);
                gp.AddArc(0, p.Height - radius, radius, radius, 90, 90);
                gp.CloseAllFigures();
                p.Region = new Region(gp);
            };

            var title = new Label
            {
                Text = ev.Title,
                Dock = DockStyle.Top,
                Height = 16,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                AutoEllipsis = true
            };

            var time = new Label
            {
                Text = $"{ev.Start:h:mm tt} - {ev.End:h:mm tt}",
                Dock = DockStyle.Top,
                Height = 14,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Regular),
                ForeColor = Color.DimGray,
                BackColor = Color.Transparent,
                AutoEllipsis = true
            };

            //p.Controls.Add(time);
            p.Controls.Add(title);

            // hover/overlap friendliness: bring to front when interacting with labels too
            title.MouseEnter += (s, e) => p.BringToFront();
            time.MouseEnter += (s, e) => p.BringToFront();
            title.MouseDown += (s, e) => p.BringToFront();
            time.MouseDown += (s, e) => p.BringToFront();

            p.Click += (s, e) => EventClick?.Invoke(this, ev);
            title.Click += (s, e) => EventClick?.Invoke(this, ev);
            time.Click += (s, e) => EventClick?.Invoke(this, ev);

            return p;
        }

        // ================= HELPERS =================

        public class CalendarEventKH
        {
            public string Id { get; set; }
            public long CitaID { get; set; }
            public string Title { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public Color Color { get; set; }
            public string ColorId { get; set; }
        }

        public class EventLayoutInfo
        {
            public CalendarEventKH Event;
            public int SlotIndex;
            public int SlotCount;
        }

        // used by both Day and Week (and month list selection)
        private List<EventLayoutInfo> BuildLayoutForDate(DateTime day)
        {
            var list = Events
                .Where(e => e.Start.Date == day.Date)
                .OrderBy(e => e.Start)
                .ThenBy(e => e.End)
                .ToList();

            var result = new List<EventLayoutInfo>();

            foreach (var ev in list)
            {
                int slot = 0;
                while (result.Any(r =>
                       r.SlotIndex == slot &&
                       r.Event.End > ev.Start &&
                       r.Event.Start < ev.End))
                {
                    slot++;
                }

                result.Add(new EventLayoutInfo { Event = ev, SlotIndex = slot });
            }

            foreach (var r in result)
            {
                r.SlotCount = Math.Max(1, result.Count(x =>
                    x.Event.End > r.Event.Start &&
                    x.Event.Start < r.Event.End));
            }

            return result;
        }

        public static Color GoogleColorToSystem(string colorId)
        {
            switch (colorId)
            {
                case "1": return Color.FromArgb(121, 134, 203);
                case "2": return Color.FromArgb(51, 182, 121);
                case "3": return Color.FromArgb(142, 36, 170);
                case "4": return Color.FromArgb(230, 124, 115);
                case "5": return Color.FromArgb(246, 191, 38);
                case "6": return Color.FromArgb(244, 81, 30);
                case "7": return Color.FromArgb(3, 155, 229);
                case "8": return Color.FromArgb(97, 97, 97);
                case "9": return Color.FromArgb(63, 81, 181);
                case "10": return Color.FromArgb(11, 128, 67);
                case "11": return Color.FromArgb(213, 0, 0);
                default: return Color.LightGray;
            }
        }
    }
}

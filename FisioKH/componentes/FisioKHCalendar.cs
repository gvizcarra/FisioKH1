using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioKH
{
    public partial class FisioKHCalendar : UserControl
    {
        private Panel loadingOverlay;
        private Panel loadingBar;
        private Timer loadingTimer;
        private int loadingX = 0;



        private const int HourHeight = 38;
        private const int HeaderHeight = 30;
        private const int StartHour = 8;
        private const int EndHour = 21;

        private Panel panelMonth;
        private Panel panelWeek;
        private Panel panelDay;

        public event Func<DateTime, DateTime, Task<DataTable>> RequestDataAsync;
        public event EventHandler<CalendarEventKH> EventClick;

        private readonly List<CalendarEventKH> Events = new List<CalendarEventKH>();

        private FlowLayoutPanel topBar;
        private Button btnMonth, btnWeek, btnDay, btnPrev, btnNext;
        private Label lblCurrentDay;
        private DateTimePicker dtpJump;

         

        private enum CalendarView { Month, Week, Day }
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

            InitRenderCache();

            //Resize += (s, e) => RefreshCurrentView();
            Load += FisioKHCalendar_Load;
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
                Dock = DockStyle.Top,
                Height = 8,                 // thicker => more visible
                BackColor = Color.FromArgb(230, 230, 230),
                Visible = false
            };

            loadingBar = new Panel
            {
                Height = 8,
                Width = 260,                // longer segment => eye-catching
                BackColor = Color.FromArgb(26, 115, 232) // nice blue
            };

            loadingOverlay.Controls.Add(loadingBar);
            Controls.Add(loadingOverlay);
            loadingOverlay.BringToFront();

            loadingTimer = new Timer { Interval = 15 };
            loadingTimer.Tick += (s, e) =>
            {
                loadingX += 12;
                if (loadingX > loadingOverlay.Width)
                    loadingX = -loadingBar.Width;

                loadingBar.Left = loadingX;
                loadingBar.Top = 0;
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

            _eventsVersion++;      
            ClearRenderCache();    
        }


        public async Task ReloadDataFromFormAsync() => await ReloadDataAsync();

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

            if (show)
            {
                loadingX = -loadingBar.Width;
                loadingTimer.Start();
            }
            else
            {
                loadingTimer.Stop();
            }
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

        public void RefreshCurrentView(bool useCache = true)
{
    LoadEventsFromDataSource();

    if (currentView == CalendarView.Month)
        RenderCached(panelMonth, CacheKey_Month(), RenderMonthView, useCache);

    if (currentView == CalendarView.Week)
        RenderCached(panelWeek, CacheKey_Week(), RenderWeekView, useCache);

    if (currentView == CalendarView.Day)
        RenderCached(panelDay, CacheKey_Day(), RenderDayView, useCache);

    UpdateDayNavigation();
}


        // ================= MONTH VIEW =================
        // Month = list-like (Google behavior): show a few events + “+N más”
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

                        int y = 22;
                        int maxLines = Math.Max(1, (cell.Height - y - 6) / 20);

                        var dayEvents = Events
                            .Where(e => e.Start.Date == date.Date)
                            .OrderBy(e => e.Start)
                            .ToList();

                        foreach (var ev in dayEvents.Take(maxLines))
                        {
                            cell.Controls.Add(CreateEventPanel(
                                ev,
                                new Size(cell.Width - 6, 18),
                                new Point(3, y)));
                            y += 20;
                        }

                        if (dayEvents.Count > maxLines)
                        {
                            cell.Controls.Add(new Label
                            {
                                Text = $"+{dayEvents.Count - maxLines} más",
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

            // Overlap-aware rendering PER DAY column
            for (int d = 0; d < 7; d++)
            {
                DateTime date = start.AddDays(d).Date;
                var layouts = BuildLayoutForDate(date);

                int baseX = labelWidth + d * colWidth;
                int usableW = colWidth;

                foreach (var l in layouts)
                {
                    int y = HeaderHeight + (int)((l.Event.Start.Hour + l.Event.Start.Minute / 60.0 - StartHour) * HourHeight);
                    int h = Math.Max(28, (int)((l.Event.End - l.Event.Start).TotalMinutes / 60 * HourHeight));

                    int slotW = Math.Max(MinEventWidth, usableW / Math.Max(1, l.SlotCount));
                    int x = baseX + l.SlotIndex * slotW;

                    int cardX = x + OuterPad;
                    int cardW = Math.Max(MinEventWidth, slotW - OverlapGap - OuterPad);

                    panelWeek.Controls.Add(CreateEventPanel(l.Event, new Size(cardW, h), new Point(cardX, y)));
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

                panelDay.Controls.Add(CreateEventPanel(l.Event, new Size(cardW, h), new Point(cardX, y)));
            }
        }

        private void CenterDayViewOnNow()
        {
            if (CurrentDate.Date != DateTime.Today) return;

            int y = HeaderHeight + (int)((DateTime.Now.Hour + DateTime.Now.Minute / 60.0 - StartHour) * HourHeight);
            panelDay.AutoScrollPosition = new Point(0, Math.Max(0, y - panelDay.Height / 2));
        }
    }
}

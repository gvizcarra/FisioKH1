using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FisioKH
{
    public partial class FisioKHCalendar : UserControl
    {
        private const int HourHeight = 38;
        private const int HeaderHeight = 30;
        private const int StartHour = 8;  // 7 AM
        private const int EndHour = 21;   // 9 PM

        private Panel panelMonth;
        private Panel panelWeek;
        private Panel panelDay;

        private new List<CalendarEventKH> Events = new List<CalendarEventKH>();

        private FlowLayoutPanel topBar;
        private Button btnMonth, btnWeek, btnDay, btnPrev, btnNext;
        private Label lblCurrentDay;
        private DateTimePicker dtpJump;  // DateTimePicker to jump to any date

        enum CalendarView { Month, Week, Day }
        private CalendarView currentView = CalendarView.Day;

        [Browsable(false)]
        public DataTable DataSource { get; set; }

        public DateTime CurrentDate { get; set; }

        // ================= CONSTRUCTOR =================
        public FisioKHCalendar()
        {
            InitializeComponent();

            Width = 1200;
            Height = 900;

            CurrentDate = DateTime.Today;

            BuildTopBar();

            panelMonth = CreateCalendarPanel();
            panelWeek = CreateCalendarPanel();
            panelDay = CreateCalendarPanel();

            Controls.Add(panelMonth);
            Controls.Add(panelWeek);
            Controls.Add(panelDay);

            ShowDay(); // Default view

            Resize += (s, e) => RefreshCurrentView();
        }

        // ================= TOP BAR =================
        private void BuildTopBar()
        {
            topBar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 32
            };

            btnMonth = new Button { Text = "Mes", Font = new Font("Segoe UI", 8), Width = 60 };
            btnWeek = new Button { Text = "Semana", Font = new Font("Segoe UI", 8), Width = 60 };
            btnDay = new Button { Text = "Día", Font = new Font("Segoe UI", 8), Width = 60 };

            btnPrev = new Button { Text = "<", Font = new Font("Segoe UI", 8), Width = 30 };
            btnNext = new Button { Text = ">", Font = new Font("Segoe UI", 8), Width = 30 };
            lblCurrentDay = new Label { AutoSize = true, Text = "", TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(5, 5, 0, 0) };

            // NEW: DateTimePicker for jumping to a date
            dtpJump = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Width = 100,

            };
            dtpJump.Font = new Font("Segoe UI", 8);  // Adjust the font size
            dtpJump.Format = DateTimePickerFormat.Short;
            dtpJump.Width = 100;  // Set the width of the DateTimePicker (adjust based on your layout)
            dtpJump.DropDownAlign = LeftRightAlignment.Right;
            dtpJump.ValueChanged += (s, e) =>
            {
                CurrentDate = dtpJump.Value.Date;
                RefreshCurrentView();
            };

            btnMonth.Click += (s, e) => ShowMonth();
            btnWeek.Click += (s, e) => ShowWeek();
            btnDay.Click += (s, e) => ShowDay();

            btnPrev.Click += (s, e) => ChangeDate(-1);  // Move back
            btnNext.Click += (s, e) => ChangeDate(1);   // Move forward

            topBar.Controls.AddRange(new Control[] { btnMonth, btnWeek, btnDay, btnPrev, lblCurrentDay, btnNext, dtpJump });

            Controls.Add(topBar);
        }

        private void NavigateDay(int delta)
        {
            CurrentDate = CurrentDate.AddDays(delta);
            RefreshCurrentView();
        }

        private void ChangeDate(int delta)
        {
            if (currentView == CalendarView.Month)
            {
                CurrentDate = CurrentDate.AddMonths(delta);  // Move by one month
            }
            else if (currentView == CalendarView.Week)
            {
                CurrentDate = CurrentDate.AddDays(delta * 7);  // Move by one week
            }
            else if (currentView == CalendarView.Day)
            {
                CurrentDate = CurrentDate.AddDays(delta);  // Move by one day
            }

            RefreshCurrentView();
        }

        // ================= PANELS =================
        private Panel CreateCalendarPanel()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                Visible = false
            };
        }

        // ================= DATA =================
        private void LoadEventsFromDataSource()
        {
            Events.Clear();
            DataTable table = DataSource;

            if (table == null) return;

            foreach (DataRow r in table.Rows)
            {
                Events.Add(new CalendarEventKH
                {
                    Id = (Guid)r["Id"],
                    Title = r["Title"].ToString(),
                    StartTime = (DateTime)r["StartTime"],
                    EndTime = (DateTime)r["EndTime"],
                    Color = Color.FromName(r["Color"].ToString()),
                    IdCita = r.Table.Columns.Contains("IdCita") ? Convert.ToInt32(r["IdCita"]) : 0
                });
            }
        }

        // ================= VIEW SWITCH =================
        private void ShowMonth()
        {
            currentView = CalendarView.Month;
            panelMonth.Visible = true;
            panelWeek.Visible = false;
            panelDay.Visible = false;
            panelMonth.BringToFront();
            UpdateDayNavigation();
            RenderMonthView();
        }

        private void ShowWeek()
        {
            currentView = CalendarView.Week;
            panelMonth.Visible = false;
            panelWeek.Visible = true;
            panelDay.Visible = false;
            panelWeek.BringToFront();
            UpdateDayNavigation();
            RenderWeekView();
        }

        private void ShowDay()
        {
            currentView = CalendarView.Day;
            panelMonth.Visible = false;
            panelWeek.Visible = false;
            panelDay.Visible = true;
            panelDay.BringToFront();
            UpdateDayNavigation();
            RenderDayView();
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

        // ================= MONTH =================
        private void RenderMonthView()
        {
            panelMonth.Controls.Clear();

            string[] diasSemana = { "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb" };
            int cols = 7;
            int cellWidth = panelMonth.ClientSize.Width / cols;
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
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    if (day > 0 && day <= days)
                    {
                        DateTime date = new DateTime(first.Year, first.Month, day);
                        cell.Controls.Add(new Label
                        {
                            Text = day.ToString(),
                            Dock = DockStyle.Top,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold)
                        });

                        int y = 22;
                        foreach (var ev in Events.Where(e => e.StartTime.Date == date))
                        {
                            cell.Controls.Add(CreateEventPanel(ev,
                                new Size(cell.Width - 6, 18),
                                new Point(3, y)));
                            y += 20;
                        }
                    }

                    panelMonth.Controls.Add(cell);
                    day++;
                }
                row++;
            }
        }

        // ================= WEEK =================
        private void RenderWeekView()
        {
            panelWeek.Controls.Clear();
            DateTime start = CurrentDate.AddDays(-(int)CurrentDate.DayOfWeek);
            int labelWidth = 60;
            int colWidth = (panelWeek.ClientSize.Width - labelWidth) / 7;

            string[] diasSemana = { "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb" };
            for (int d = 0; d < 7; d++)
            {
                panelWeek.Controls.Add(new Label
                {
                    Text = diasSemana[d] + " " + start.AddDays(d).Day,
                    Location = new Point(labelWidth + d * colWidth, 0),
                    Size = new Size(colWidth, HeaderHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.WhiteSmoke
                });
            }

            for (int h = StartHour; h <= EndHour; h++)
            {
                int y = HeaderHeight + (h - StartHour) * HourHeight;

                panelWeek.Controls.Add(new Label
                {
                    Text = $"{h:00}:00",
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

            foreach (var ev in Events)
            {
                int dayIndex = (int)(ev.StartTime.Date - start).TotalDays;
                if (dayIndex < 0 || dayIndex > 6) continue;

                int y = HeaderHeight + (int)((ev.StartTime.Hour + ev.StartTime.Minute / 60.0 - StartHour) * HourHeight);
                int h = Math.Max(25, (int)((ev.EndTime - ev.StartTime).TotalMinutes / 60 * HourHeight));
                panelWeek.Controls.Add(CreateEventPanel(ev, new Size(colWidth - 4, h), new Point(labelWidth + dayIndex * colWidth + 2, y)));
            }
        }

        // ================= DAY =================
        private void RenderDayView()
        {
            panelDay.Controls.Clear();
            int labelWidth = 60;

            for (int h = StartHour; h <= EndHour; h++)
            {
                int y = HeaderHeight + (h - StartHour) * HourHeight;

                panelDay.Controls.Add(new Label
                {
                    Text = $"{h:00}:00",
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

            var layouts = BuildDayLayout(CurrentDate);
            int width = panelDay.ClientSize.Width - labelWidth;

            foreach (var l in layouts)
            {
                int y = HeaderHeight + (int)((l.Event.StartTime.Hour + l.Event.StartTime.Minute / 60.0 - StartHour) * HourHeight);
                int h = Math.Max(25, (int)((l.Event.EndTime - l.Event.StartTime).TotalMinutes / 30 * HourHeight));
                int slotW = width / l.SlotCount;
                int x = labelWidth + l.SlotIndex * slotW;

                panelDay.Controls.Add(CreateEventPanel(l.Event, new Size(slotW - 4, h), new Point(x + 2, y)));
            }
        }

        private void CenterDayViewOnNow()
        {
            if (CurrentDate.Date != DateTime.Today) return;

            int y = HeaderHeight + (int)((DateTime.Now.Hour + DateTime.Now.Minute / 60.0 - StartHour) * HourHeight);
            if (y < HeaderHeight) y = HeaderHeight;

            panelDay.AutoScrollPosition = new Point(0, Math.Max(0, y - panelDay.Height / 2));
        }

        // ================= EVENT PANEL =================
        private Panel CreateEventPanel(CalendarEventKH ev, Size size, Point loc)
        {
            Panel p = new Panel
            {
                Size = size,
                Location = loc,
                BackColor = ev.Color,
                BorderStyle = BorderStyle.FixedSingle
            };

            p.Controls.Add(new Label
            {
                Text = ev.Title,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.Transparent
            });

            return p;
        }

        // ================= HELPER CLASSES =================
        public class CalendarEventKH
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public Color Color { get; set; }
            public int IdCita { get; set; }
        }

        public class EventLayoutInfo
        {
            public CalendarEventKH Event;
            public int SlotIndex;
            public int SlotCount;
        }

        // ================= BUILD DAY LAYOUT =================
        private List<EventLayoutInfo> BuildDayLayout(DateTime day)
        {
            // Filter events for the current day and sort by start time
            var list = Events.Where(e => e.StartTime.Date == day.Date)
                             .OrderBy(e => e.StartTime)
                             .ToList();

            var result = new List<EventLayoutInfo>();

            foreach (var ev in list)
            {
                int slot = 0;

                // Find the first slot where this event does not overlap
                while (result.Any(r =>
                    r.SlotIndex == slot &&
                    r.Event.EndTime > ev.StartTime &&
                    r.Event.StartTime < ev.EndTime))
                {
                    slot++;
                }

                result.Add(new EventLayoutInfo
                {
                    Event = ev,
                    SlotIndex = slot
                });
            }

            // Calculate slot count for each event (number of overlapping events)
            foreach (var r in result)
            {
                r.SlotCount = result.Count(x =>
                    x.Event.EndTime > r.Event.StartTime &&
                    x.Event.StartTime < r.Event.EndTime);
            }

            return result;
        }

        // ================= DAY NAVIGATION =================
        private void UpdateDayNavigation()
        {
            if (currentView == CalendarView.Day)
            {
                lblCurrentDay.Text = CurrentDate.ToString("dddd, dd MMMM yyyy");
            }
            else if (currentView == CalendarView.Month)
            {
                lblCurrentDay.Text = CurrentDate.ToString("MMMM yyyy");
            }
            else if (currentView == CalendarView.Week)
            {
                lblCurrentDay.Text = $"Semana de {CurrentDate:dd MMM yyyy}";
            }

            btnPrev.Enabled = btnNext.Enabled = currentView == CalendarView.Day || currentView == CalendarView.Month;

            // Sync DatePicker
            dtpJump.ValueChanged -= DtpJump_ValueChanged; // temporarily remove handler
            dtpJump.Value = CurrentDate;
            dtpJump.ValueChanged += DtpJump_ValueChanged; // re-attach
        }

        private void DtpJump_ValueChanged(object sender, EventArgs e)
        {
            CurrentDate = dtpJump.Value.Date;
            RefreshCurrentView();
        }
    }
}

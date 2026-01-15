using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;


namespace FisioKH
{
    public partial class FisioKHCalendar : UserControl
    {
        // ===== Constants for hours range =====
        private const int StartHour = 7;  // 7 AM
        private const int EndHour = 21;   // 9 PM
        private const int HourHeight = 60;
        private const int HeaderHeight = 30;
        private const int LabelWidth = 60;

        // ===== Fields =====
        private Panel panelMonth;
        private Panel panelWeek;
        private Panel panelDay;

        private Button btnPrev;
        private Button btnNext;
        private Button btnToday;
        private Button btnMonth;
        private Button btnWeek;
        private Button btnDay;
        private Label lblCurrentDay;  // New label to show current day in Day view

        private new List<CalendarEventKH> Events = new List<CalendarEventKH>();

        private CalendarView currentView = CalendarView.Month;

        // Current date shown in calendar
        private DateTime currentDate = DateTime.Today;
        [Browsable(false)]
        public DateTime CurrentDate
        {
            get => currentDate;
            set
            {
                if (currentDate.Date != value.Date)
                {
                    currentDate = value.Date;
                    RefreshCurrentView();
                    UpdateCurrentDayLabel();
                }
            }
        }

        // External DataTable datasource for events
        private DataTable dataSource;
        public DataTable DataSource
        {
            get => dataSource;
            set
            {
                dataSource = value;
                LoadEventsFromDataSource();
                RefreshCurrentView();
            }
        }

        // Constructor
        public FisioKHCalendar()
        {
            InitializeComponent();

            Width = 1200;
            Height = 900;

            BuildTopBar();

            // Create panels
            panelMonth = CreateCalendarPanel();
            panelWeek = CreateCalendarPanel();
            panelDay = CreateCalendarPanel();

            Controls.Add(panelMonth); // bottom
            Controls.Add(panelWeek);  // middle
            Controls.Add(panelDay);   // top

            ShowMonth();

            Resize += (s, e) => RefreshCurrentView();
        }

        private void BuildTopBar()
        {
            Font topBarFont = new Font("Segoe UI", 9);

            FlowLayoutPanel topBar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 35,
                Padding = new Padding(5, 5, 5, 5),
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };

            btnPrev = new Button { Text = "<", Font = topBarFont, Height = 26, Width = 32 };
            btnPrev.Click += (s, e) => ChangeDate(-1);

            btnToday = new Button { Text = "Hoy", Font = topBarFont, Height = 26, Width = 60 };
            btnToday.Click += (s, e) => GoToToday();

            btnNext = new Button { Text = ">", Font = topBarFont, Height = 26, Width = 32 };
            btnNext.Click += (s, e) => ChangeDate(1);

            lblCurrentDay = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Visible = false, // initially hidden (only shown in Day view)
                Padding = new Padding(8, 4, 8, 4),
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnMonth = new Button { Text = "Mes", Font = topBarFont, Height = 26, Width = 60 };
            btnMonth.Click += (s, e) => ShowMonth();

            btnWeek = new Button { Text = "Semana", Font = topBarFont, Height = 26, Width = 60 };
            btnWeek.Click += (s, e) => ShowWeek();

            btnDay = new Button { Text = "Día", Font = topBarFont, Height = 26, Width = 60 };
            btnDay.Click += (s, e) => ShowDay();

            topBar.Controls.AddRange(new Control[] {
                btnPrev, btnToday, btnNext, lblCurrentDay,
                btnMonth, btnWeek, btnDay
            });

            Controls.Add(topBar);
        }

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

        // ================== Data loading ==================
        private void LoadEventsFromDataSource()
        {
            Events.Clear();

            if (dataSource == null) return;

            foreach (DataRow r in dataSource.Rows)
            {
                // Defensive checks
                if (!r.Table.Columns.Contains("Id") ||
                    !r.Table.Columns.Contains("Title") ||
                    !r.Table.Columns.Contains("StartTime") ||
                    !r.Table.Columns.Contains("EndTime") ||
                    !r.Table.Columns.Contains("Color") ||
                    !r.Table.Columns.Contains("IdCita"))
                    continue;

                Events.Add(new CalendarEventKH
                {
                    Id = (Guid)r["Id"],
                    Title = r["Title"].ToString(),
                    StartTime = (DateTime)r["StartTime"],
                    EndTime = (DateTime)r["EndTime"],
                    Color = Color.FromName(r["Color"].ToString()),
                    IdCita = Convert.ToInt32(r["IdCita"])
                });
            }
        }

        // ================== Navigation ==================
        private void ChangeDate(int delta)
        {
            switch (currentView)
            {
                case CalendarView.Month:
                    CurrentDate = CurrentDate.AddMonths(delta);
                    break;
                case CalendarView.Week:
                    CurrentDate = CurrentDate.AddDays(delta * 7);
                    break;
                case CalendarView.Day:
                    CurrentDate = CurrentDate.AddDays(delta);
                    break;
            }
        }

        private void GoToToday()
        {
            CurrentDate = DateTime.Today;
        }

        // ================== View switching ==================
        private void ShowMonth()
        {
            currentView = CalendarView.Month;

            panelMonth.Visible = true;
            panelWeek.Visible = false;
            panelDay.Visible = false;

            panelMonth.BringToFront();

            UpdateNavigationButtons();
            UpdateCurrentDayLabel();

            RenderMonth();
        }

        private void ShowWeek()
        {
            currentView = CalendarView.Week;

            panelMonth.Visible = false;
            panelWeek.Visible = true;
            panelDay.Visible = false;

            panelWeek.BringToFront();

            UpdateNavigationButtons();
            UpdateCurrentDayLabel();

            RenderWeek();
        }

        private void ShowDay()
        {
            currentView = CalendarView.Day;

            panelMonth.Visible = false;
            panelWeek.Visible = false;
            panelDay.Visible = true;

            panelDay.BringToFront();

            UpdateNavigationButtons();
            UpdateCurrentDayLabel();

            RenderDay();
            CenterDayOnNow();
        }

        private void UpdateNavigationButtons()
        {
            // Navigation buttons enabled only in Day view
            bool enableNav = currentView == CalendarView.Day;

            btnPrev.Enabled = enableNav;
            btnNext.Enabled = enableNav;
            // btnToday can remain enabled always
        }

        private void UpdateCurrentDayLabel()
        {
            // Show the label only in Day view
            lblCurrentDay.Visible = currentView == CalendarView.Day;

            if (lblCurrentDay.Visible)
            {
                lblCurrentDay.Text = CurrentDate.ToString("dddd, dd MMMM yyyy");
                // Capitalize first letter (optional)
                lblCurrentDay.Text = char.ToUpper(lblCurrentDay.Text[0]) + lblCurrentDay.Text.Substring(1);
            }
        }

        private void RefreshCurrentView()
        {
            LoadEventsFromDataSource();

            switch (currentView)
            {
                case CalendarView.Month:
                    RenderMonth();
                    break;
                case CalendarView.Week:
                    RenderWeek();
                    break;
                case CalendarView.Day:
                    RenderDay();
                    CenterDayOnNow();
                    break;
            }

            UpdateCurrentDayLabel();
        }

        // ================== Month View ==================
        private void RenderMonth()
        {
            panelMonth.Controls.Clear();

            int cols = 7;
            int cellWidth = panelMonth.ClientSize.Width / cols;
            int cellHeight = 110;

            DateTime first = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            int offset = (int)first.DayOfWeek; // Sunday = 0
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

        // ================== Week View ==================
        private void RenderWeek()
        {
            panelWeek.Controls.Clear();

            DateTime startOfWeek = CurrentDate.AddDays(-(int)CurrentDate.DayOfWeek);

            int colWidth = (panelWeek.ClientSize.Width - LabelWidth) / 7;

            string[] spanishWeekDays = new[] { "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb" };

            // Weekday headers
            for (int d = 0; d < 7; d++)
            {
                panelWeek.Controls.Add(new Label
                {
                    Text = spanishWeekDays[d] + " " + startOfWeek.AddDays(d).Day,
                    Location = new Point(LabelWidth + d * colWidth, 0),
                    Size = new Size(colWidth, HeaderHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.WhiteSmoke
                });
            }

            // Hours and grid lines from StartHour to EndHour
            for (int h = StartHour; h < EndHour; h++)
            {
                int y = HeaderHeight + (h - StartHour) * HourHeight;

                panelWeek.Controls.Add(new Label
                {
                    Text = $"{h:00}:00",
                    Location = new Point(0, y),
                    Size = new Size(LabelWidth, HourHeight),
                    TextAlign = ContentAlignment.TopRight
                });

                for (int d = 0; d < 7; d++)
                {
                    panelWeek.Controls.Add(new Panel
                    {
                        Location = new Point(LabelWidth + d * colWidth, y),
                        Size = new Size(colWidth, 1),
                        BackColor = Color.LightGray
                    });
                }
            }

            // Render events in week view
            foreach (var ev in Events)
            {
                int dayIndex = (int)(ev.StartTime.Date - startOfWeek).TotalDays;
                if (dayIndex < 0 || dayIndex > 6) continue;

                double startHourDecimal = ev.StartTime.Hour + ev.StartTime.Minute / 60.0;
                double endHourDecimal = ev.EndTime.Hour + ev.EndTime.Minute / 60.0;

                if (endHourDecimal < StartHour || startHourDecimal > EndHour)
                    continue; // Event outside visible range

                int y = HeaderHeight + (int)((startHourDecimal - StartHour) * HourHeight);

                int height = Math.Max(25,
                    (int)((ev.EndTime - ev.StartTime).TotalMinutes / 60 * HourHeight));

                int eventWidth = colWidth - 4;
                int eventX = LabelWidth + dayIndex * colWidth + 2;

                panelWeek.Controls.Add(CreateEventPanel(ev,
                    new Size(eventWidth, height),
                    new Point(eventX, y)));
            }
        }

        // ================== Day View ==================
        private void RenderDay()
        {
            panelDay.Controls.Clear();

            bool isToday = CurrentDate.Date == DateTime.Today;

            // Hours + horizontal lines
            for (int h = StartHour; h < EndHour; h++)
            {
                int y = HeaderHeight + (h - StartHour) * HourHeight;

                Label lblHour = new Label
                {
                    Text = $"{h:00}:00",
                    Location = new Point(0, y),
                    Size = new Size(LabelWidth, HourHeight),
                    TextAlign = ContentAlignment.TopRight
                };
                panelDay.Controls.Add(lblHour);

                Panel line = new Panel
                {
                    Location = new Point(LabelWidth, y),
                    Size = new Size(panelDay.ClientSize.Width - LabelWidth, 1),
                    BackColor = isToday ? Color.LightYellow : Color.LightGray
                };
                panelDay.Controls.Add(line);
            }

            // Render events
            var dayEvents = Events.Where(e => e.StartTime.Date == CurrentDate.Date)
                                  .OrderBy(e => e.StartTime)
                                  .ToList();

            foreach (var ev in dayEvents)
            {
                double startHourDecimal = ev.StartTime.Hour + ev.StartTime.Minute / 60.0;
                double endHourDecimal = ev.EndTime.Hour + ev.EndTime.Minute / 60.0;

                // Clamp start and end within StartHour and EndHour for display purposes
                startHourDecimal = Math.Max(startHourDecimal, StartHour);
                endHourDecimal = Math.Min(endHourDecimal, EndHour);

                int y = HeaderHeight + (int)((startHourDecimal - StartHour) * HourHeight);
                int height = Math.Max(25,
                    (int)((endHourDecimal - startHourDecimal) * HourHeight));

                int eventWidth = panelDay.ClientSize.Width - LabelWidth - 6;
                int eventX = LabelWidth + 3;

                panelDay.Controls.Add(CreateEventPanel(ev,
                    new Size(eventWidth, height),
                    new Point(eventX, y)));
            }
        }

        private void CenterDayOnNow()
        {
            if (CurrentDate.Date != DateTime.Today)
                return;

            int y = HeaderHeight + (int)((DateTime.Now.TimeOfDay.TotalMinutes / 60) - StartHour) * HourHeight;
            if (y < HeaderHeight) y = HeaderHeight;

            panelDay.AutoScrollPosition = new Point(0, Math.Max(0, y - panelDay.Height / 2));
        }

        // ================== Event panel creation ==================
        private Panel CreateEventPanel(CalendarEventKH ev, Size size, Point location)
        {
            Panel p = new Panel
            {
                Size = size,
                Location = location,
                BackColor = ev.Color,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = ev
            };

            Label lbl = new Label
            {
                Text = ev.Title,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(3, 0, 3, 0)
            };
            p.Controls.Add(lbl);

            return p;
        }

        // ================== Helper Enums and Classes ==================
        enum CalendarView { Month, Week, Day }

        public class CalendarEventKH
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public Color Color { get; set; }
            public int IdCita { get; set; }
        }
    }
}

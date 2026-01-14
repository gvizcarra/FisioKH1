using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FisioKH
{
    public partial class MyCalendarForm : Form
    {
        // ================= STATIC DATA =================
        public static DataTable CalendarTable;

        private const int HourHeight = 60;
        private const int HeaderHeight = 30;

        private Panel panelMonth;
        private Panel panelWeek;
        private Panel panelDay;

        private List<CalendarEventx> Events = new List<CalendarEventx>();

        enum CalendarView { Month, Week, Day }
        private CalendarView currentView = CalendarView.Month;

        // ================= CONSTRUCTOR =================
        public MyCalendarForm()
        {
            InitializeComponent();

            Width = 1200;
            Height = 900;
            Text = "Calendar";

            InitCalendarTable();
            LoadEventsFromStaticTable();

            // ===== TOP BAR =====
            FlowLayoutPanel topBar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 32
            };

            Button btnMonth = new Button { Text = "Month" };
            Button btnWeek = new Button { Text = "Week" };
            Button btnDay = new Button { Text = "Day" };

            btnMonth.Click += (s, e) => ShowMonth();
            btnWeek.Click += (s, e) => ShowWeek();
            btnDay.Click += (s, e) => ShowDay();

            topBar.Controls.AddRange(new Control[] { btnMonth, btnWeek, btnDay });
            Controls.Add(topBar);

            // ===== PANELS (ORDER MATTERS) =====
            panelMonth = CreateCalendarPanel();
            panelWeek = CreateCalendarPanel();
            panelDay = CreateCalendarPanel();

            Controls.Add(panelMonth); // bottom
            Controls.Add(panelWeek);  // middle
            Controls.Add(panelDay);   // top

            ShowMonth();

            Resize += (s, e) => RefreshCurrentView();
        }

        // ================= STATIC TABLE =================
        private static void InitCalendarTable()
        {
            if (CalendarTable != null) return;

            CalendarTable = new DataTable();
            CalendarTable.Columns.Add("Id", typeof(Guid));
            CalendarTable.Columns.Add("Title", typeof(string));
            CalendarTable.Columns.Add("StartTime", typeof(DateTime));
            CalendarTable.Columns.Add("EndTime", typeof(DateTime));
            CalendarTable.Columns.Add("Color", typeof(string));

            CalendarTable.Rows.Add(Guid.NewGuid(), "Checkup",
                DateTime.Today.AddHours(9), DateTime.Today.AddHours(10), "LightCoral");

            CalendarTable.Rows.Add(Guid.NewGuid(), "Therapy",
                DateTime.Today.AddHours(9), DateTime.Today.AddHours(11), "LightGreen");

            CalendarTable.Rows.Add(Guid.NewGuid(), "Massage",
                DateTime.Today.AddHours(14), DateTime.Today.AddHours(15), "LightBlue");
        }

        private void LoadEventsFromStaticTable()
        {
            Events.Clear();

            foreach (DataRow r in CalendarTable.Rows)
            {
                Events.Add(new CalendarEventx
                {
                    Id = (Guid)r["Id"],
                    Title = r["Title"].ToString(),
                    StartTime = (DateTime)r["StartTime"],
                    EndTime = (DateTime)r["EndTime"],
                    Color = Color.FromName(r["Color"].ToString())
                });
            }
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

        // ================= VIEW SWITCH =================
        private void ShowMonth()
        {
            currentView = CalendarView.Month;
            panelMonth.Visible = true;
            panelWeek.Visible = false;
            panelDay.Visible = false;
            panelMonth.BringToFront();
            RenderMonthView();
        }

        private void ShowWeek()
        {
            currentView = CalendarView.Week;
            panelMonth.Visible = false;
            panelWeek.Visible = true;
            panelDay.Visible = false;
            panelWeek.BringToFront();
            RenderWeekView();
        }

        private void ShowDay()
        {
            currentView = CalendarView.Day;
            panelMonth.Visible = false;
            panelWeek.Visible = false;
            panelDay.Visible = true;
            panelDay.BringToFront();
            RenderDayView();
            CenterDayViewOnNow();
        }

        private void RefreshCurrentView()
        {
            LoadEventsFromStaticTable();

            if (currentView == CalendarView.Month) RenderMonthView();
            if (currentView == CalendarView.Week) RenderWeekView();
            if (currentView == CalendarView.Day) RenderDayView();
        }

        // ================= MONTH =================
        private void RenderMonthView()
        {
            panelMonth.Controls.Clear();

            int cols = 7;
            int cellWidth = panelMonth.ClientSize.Width / cols;
            int cellHeight = 110;

            DateTime first = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
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

            DateTime start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);

            int labelWidth = 60;
            int colWidth = (panelWeek.ClientSize.Width - labelWidth) / 7;

            for (int d = 0; d < 7; d++)
            {
                panelWeek.Controls.Add(new Label
                {
                    Text = start.AddDays(d).ToString("ddd dd"),
                    Location = new Point(labelWidth + d * colWidth, 0),
                    Size = new Size(colWidth, HeaderHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.WhiteSmoke
                });
            }

            for (int h = 0; h < 24; h++)
            {
                int y = HeaderHeight + h * HourHeight;

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

                int y = HeaderHeight +
                    (int)(ev.StartTime.TimeOfDay.TotalMinutes / 60 * HourHeight);

                int h = Math.Max(25,
                    (int)((ev.EndTime - ev.StartTime).TotalMinutes / 60 * HourHeight));

                panelWeek.Controls.Add(CreateEventPanel(ev,
                    new Size(colWidth - 4, h),
                    new Point(labelWidth + dayIndex * colWidth + 2, y)));
            }
        }

        // ================= DAY =================
        private void RenderDayView()
        {
            panelDay.Controls.Clear();

            int labelWidth = 60;

            for (int h = 0; h < 24; h++)
            {
                int y = HeaderHeight + h * HourHeight;

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

            var layouts = BuildDayLayout(DateTime.Today);
            int width = panelDay.ClientSize.Width - labelWidth;

            foreach (var l in layouts)
            {
                int y = HeaderHeight +
                    (int)(l.Event.StartTime.TimeOfDay.TotalMinutes / 60 * HourHeight);

                int h = Math.Max(25,
                    (int)((l.Event.EndTime - l.Event.StartTime).TotalMinutes / 60 * HourHeight));

                int slotW = width / l.SlotCount;
                int x = labelWidth + l.SlotIndex * slotW;

                panelDay.Controls.Add(CreateEventPanel(l.Event,
                    new Size(slotW - 4, h),
                    new Point(x + 2, y)));
            }
        }

        private void CenterDayViewOnNow()
        {
            int y = HeaderHeight +
                (int)(DateTime.Now.TimeOfDay.TotalMinutes / 60 * HourHeight);
            panelDay.AutoScrollPosition = new Point(0, Math.Max(0, y - panelDay.Height / 2));
        }

        private List<EventLayoutInfo> BuildDayLayout(DateTime day)
        {
            var list = Events.Where(e => e.StartTime.Date == day.Date)
                             .OrderBy(e => e.StartTime).ToList();

            var result = new List<EventLayoutInfo>();

            foreach (var ev in list)
            {
                int slot = 0;
                while (result.Any(r =>
                    r.SlotIndex == slot &&
                    r.Event.EndTime > ev.StartTime &&
                    r.Event.StartTime < ev.EndTime))
                    slot++;

                result.Add(new EventLayoutInfo { Event = ev, SlotIndex = slot });
            }

            foreach (var r in result)
                r.SlotCount = result.Count(x =>
                    x.Event.EndTime > r.Event.StartTime &&
                    x.Event.StartTime < r.Event.EndTime);

            return result;
        }

        private Panel CreateEventPanel(CalendarEventx ev, Size size, Point loc)
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
    }

    class EventLayoutInfo
    {
        public CalendarEventx Event;
        public int SlotIndex;
        public int SlotCount;
    }

    public class CalendarEventx
    {
        public Guid Id;
        public string Title;
        public DateTime StartTime;
        public DateTime EndTime;
        public Color Color;
    }
}

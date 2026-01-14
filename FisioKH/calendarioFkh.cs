using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FisioKH
{
    public enum CalendarView { Day, Week, Month }

    [Serializable]
    public partial class CalendarControl : UserControl
    {
        private Panel panelCalendar;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new List<CalendarEvent> Events { get; set; } = new List<CalendarEvent>();

        private CalendarView viewMode = CalendarView.Month;
        public CalendarView ViewMode
        {
            get => viewMode;
            set { viewMode = value; RenderCalendar(); }
        }

        private DateTime currentDate = DateTime.Today;
        public DateTime CurrentDate
        {
            get => currentDate;
            set { currentDate = value; RenderCalendar(); }
        }

        public CalendarControl()
        {
            panelCalendar = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White
            };
            this.Controls.Add(panelCalendar);

            this.Resize += (s, e) => RenderCalendar();
        }

        public void RenderCalendar()
        {
            panelCalendar.Controls.Clear();

            switch (ViewMode)
            {
                case CalendarView.Month: RenderMonthView(); break;
                case CalendarView.Week: RenderWeekView(); break;
                case CalendarView.Day: RenderDayView(); break;
            }
        }

        #region Month View
        private void RenderMonthView()
        {
            panelCalendar.SuspendLayout();

            int cols = 7;
            int cellWidth = panelCalendar.ClientSize.Width / cols;
            int cellHeight = 80;

            DateTime firstDay = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            int offset = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month);

            int currentDay = 1 - offset;
            int row = 0;

            while (currentDay <= daysInMonth)
            {
                for (int col = 0; col < 7; col++)
                {
                    Panel cell = new Panel
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(col * cellWidth, row * cellHeight),
                        Size = new Size(cellWidth - 1, cellHeight - 1),
                        BackColor = Color.White
                    };


                   


                    Label lbl = new Label
                    {
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.TopLeft,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold)
                    };

                    if (currentDay > 0 && currentDay <= daysInMonth)
                    {
                        DateTime cellDate = new DateTime(CurrentDate.Year, CurrentDate.Month, currentDay);
                        lbl.Text = currentDay.ToString();

                        int eventIndex = 0;
                        foreach (var ev in Events)
                        {
                            if (ev.StartTime.Date == cellDate.Date)
                            {
                                Panel eventPanel = new Panel
                                {
                                    BackColor = ev.Color,
                                    Size = new Size(cell.Width - 4, 16),
                                    Location = new Point(2, 18 + eventIndex * 18),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Tag = ev.Id
                                };

                                cell.Tag = cellDate;        // store the date of this cell
                                cell.Click += Cell_Click;


                                Label lblEv = new Label
                                {
                                    Text = ev.Title,
                                    Dock = DockStyle.Fill,
                                    TextAlign = ContentAlignment.MiddleLeft,
                                    AutoSize = false,
                                    BackColor = Color.Transparent,
                                    Font = new Font("Segoe UI", 8)
                                };

                                eventPanel.Click += EventPanel_Click;

                                lblEv.Click += EventPanel_Click;

                                eventPanel.Controls.Add(lblEv);
                                AddEventPanelClickHandler(eventPanel);
                                cell.Controls.Add(eventPanel);
                                eventIndex++;
                            }
                        }
                    }

                    cell.Controls.Add(lbl);
                    panelCalendar.Controls.Add(cell);
                    currentDay++;
                }
                row++;
            }

            panelCalendar.ResumeLayout();
        }
        #endregion

        private void Cell_Click(object sender, EventArgs e)
        {
            if (!(sender is Panel cell)) return;
            if (!(cell.Tag is DateTime cellDate)) return;

            // Example: add a new event for this cell's date
            using (Form input = new Form())
            {
                input.Text = "Add Event";
                input.Width = 300;
                input.Height = 180;

                Label lblTitle = new Label { Text = "Title:", Left = 10, Top = 20, Width = 50 };
                TextBox txtTitle = new TextBox { Left = 70, Top = 20, Width = 200 };

                Label lblStart = new Label { Text = "Start (HH:mm):", Left = 10, Top = 60, Width = 80 };
                TextBox txtStart = new TextBox { Left = 100, Top = 60, Width = 100, Text = "09:00" };

                Label lblEnd = new Label { Text = "End (HH:mm):", Left = 10, Top = 100, Width = 80 };
                TextBox txtEnd = new TextBox { Left = 100, Top = 100, Width = 100, Text = "10:00" };

                Button btnOk = new Button { Text = "OK", Left = 100, Width = 80, Top = 130, DialogResult = DialogResult.OK };

                input.Controls.Add(lblTitle);
                input.Controls.Add(txtTitle);
                input.Controls.Add(lblStart);
                input.Controls.Add(txtStart);
                input.Controls.Add(lblEnd);
                input.Controls.Add(txtEnd);
                input.Controls.Add(btnOk);

                input.AcceptButton = btnOk;

                if (input.ShowDialog() == DialogResult.OK)
                {
                    if (TimeSpan.TryParse(txtStart.Text, out TimeSpan start) &&
                        TimeSpan.TryParse(txtEnd.Text, out TimeSpan end))
                    {
                        Events.Add(new CalendarEvent
                        {
                            Title = txtTitle.Text,
                            StartTime = cellDate.Date + start,
                            EndTime = cellDate.Date + end,
                            Color = Color.LightSkyBlue
                        });

                        RenderCalendar();
                    }
                    else
                    {
                        MessageBox.Show("Invalid time format. Use HH:mm.");
                    }
                }
            }
        }


        private void EventPanel_Click(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel ?? (sender as Label)?.Parent as Panel;
            if (pnl == null || !(pnl.Tag is Guid id)) return;

            CalendarEvent ev = Events.Find(x => x.UniqueGuid  == id);
            if (ev == null) return;

            MessageBox.Show($"Title: {ev.Title}\nStart: {ev.StartTime}\nEnd: {ev.EndTime}", "Event Info");
        }



        private void AddEventPanelClickHandler(Panel eventPanel)
        {
            // Attach handler to panel itself
            
            eventPanel.Click += EventPanel_Click;

            // Attach handler to all children
            foreach (Control ctrl in eventPanel.Controls)
            {
                ctrl.Click += EventPanel_Click;
            }
        }


        #region Week View
        private void RenderWeekView()
        {
            panelCalendar.SuspendLayout();

            int cols = 7;
            int rows = 24;
            int cellWidth = panelCalendar.ClientSize.Width / cols;
            int cellHeight = 60;

            panelCalendar.AutoScrollMinSize = new Size(panelCalendar.ClientSize.Width, rows * cellHeight);

            DateTime startOfWeek = CurrentDate.AddDays(-(int)CurrentDate.DayOfWeek);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Panel cell = new Panel
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(col * cellWidth, row * cellHeight),
                        Size = new Size(cellWidth - 1, cellHeight - 1),
                        BackColor = Color.White
                    };

                    cell.Tag = startOfWeek.AddDays(col).AddHours(row); // Week view
                    cell.Click += Cell_Click;

                    DateTime cellDateTime = startOfWeek.AddDays(col).AddHours(row);

                    int eventIndex = 0;
                    foreach (var ev in Events)
                    {
                        if (ev.StartTime < cellDateTime.AddHours(1) && ev.EndTime > cellDateTime)
                        {
                            int durationHours = Math.Max(1, (int)Math.Ceiling((ev.EndTime - ev.StartTime).TotalHours));
                            int height = cellHeight * durationHours;

                            Panel eventPanel = new Panel
                            {
                                BackColor = ev.Color,
                                Size = new Size(cell.Width - 4, height - 2),
                                Location = new Point(2, eventIndex * height),
                                BorderStyle = BorderStyle.FixedSingle,
                                Tag = ev.Id 
                            };

                            Label lblEv = new Label
                            {
                                Text = ev.Title,
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter,
                                AutoSize = false,
                                BackColor = Color.Transparent,
                                Font = new Font("Segoe UI", 8)
                            };

                            eventPanel.Click += EventPanel_Click;

                            lblEv.Click += EventPanel_Click;

                            eventPanel.Controls.Add(lblEv);
                            AddEventPanelClickHandler(eventPanel);
                            cell.Controls.Add(eventPanel);

                            eventIndex++;
                        }
                    }

                    panelCalendar.Controls.Add(cell);
                }
            }

            panelCalendar.ResumeLayout();
        }
        #endregion

        #region Day View
        private void RenderDayView()
        {
            panelCalendar.SuspendLayout();

            int rows = 24;
            int cellHeight = 60;
            int cellWidth = panelCalendar.ClientSize.Width;

            panelCalendar.AutoScrollMinSize = new Size(cellWidth, rows * cellHeight);

            for (int row = 0; row < rows; row++)
            {
                Panel cell = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(0, row * cellHeight),
                    Size = new Size(cellWidth - 20, cellHeight),
                    BackColor = Color.White
                };

                cell.Tag = CurrentDate.Date.AddHours(row); // Day view
                cell.Click += Cell_Click;

                DateTime cellDateTime = CurrentDate.Date.AddHours(row);

                int eventIndex = 0;
                foreach (var ev in Events)
                {
                    if (ev.StartTime < cellDateTime.AddHours(1) && ev.EndTime > cellDateTime)
                    {
                        int durationHours = Math.Max(1, (int)Math.Ceiling((ev.EndTime - ev.StartTime).TotalHours));
                        int height = cellHeight * durationHours;

                        Panel eventPanel = new Panel
                        {
                            BackColor = ev.Color,
                            Size = new Size(cell.Width - 4, height - 2),
                            Location = new Point(2, eventIndex * height),
                            BorderStyle = BorderStyle.FixedSingle,
                            Tag = ev.Id
                        };

                        Label lblEv = new Label
                        {
                            Text = ev.Title,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            AutoSize = false,
                            BackColor = Color.Transparent,
                            Font = new Font("Segoe UI", 8)
                        };

                        eventPanel.Click += EventPanel_Click;

                        lblEv.Click += EventPanel_Click;

                        eventPanel.Controls.Add(lblEv);
                        AddEventPanelClickHandler(eventPanel);
                        cell.Controls.Add(eventPanel);
                        eventIndex++;
                    }
                }

                panelCalendar.Controls.Add(cell);
            }

            panelCalendar.ResumeLayout();
        }
        #endregion
    }

    [Serializable]
    public class CalendarEvent
    {
        public int Id { get; set; }  
        public Guid UniqueGuid { get; set; } = Guid.NewGuid(); 
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Color Color { get; set; } = Color.LightBlue;
    }
}

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FisioKH
{
    public partial class micalendario : Form
    {
        private CalendarControl calendar;
        private ToolStrip toolStrip;
        private ToolStripButton btnMonth, btnWeek, btnDay, btnAddEvent;

        public micalendario()
        {
            InitializeComponent();
            InitializeToolbar();
            InitializeCalendar();
        }

        private void InitializeToolbar()
        {
            toolStrip = new ToolStrip();
            this.Controls.Add(toolStrip);

            btnMonth = new ToolStripButton("Month");
            btnWeek = new ToolStripButton("Week");
            btnDay = new ToolStripButton("Day");
            btnAddEvent = new ToolStripButton("Add Event");

            toolStrip.Items.AddRange(new ToolStripItem[] { btnMonth, btnWeek, btnDay, btnAddEvent });

            btnMonth.Click += (s, e) => { calendar.ViewMode = CalendarView.Month; calendar.RenderCalendar(); };
            btnWeek.Click += (s, e) => { calendar.ViewMode = CalendarView.Week; calendar.RenderCalendar(); };
            btnDay.Click += (s, e) => { calendar.ViewMode = CalendarView.Day; calendar.RenderCalendar(); };
            btnAddEvent.Click += BtnAddEvent_Click;
        }

        private void InitializeCalendar()
        {
            calendar = new CalendarControl
            {
                Dock = DockStyle.Fill,
                ViewMode = CalendarView.Month,
                CurrentDate = DateTime.Today,
                BackColor = Color.AliceBlue

            };

            // Example events at startup
            calendar.Events.Add(new CalendarEvent
            {
                Title = "Checkup",
                StartTime = DateTime.Today.AddHours(10),
                EndTime = DateTime.Today.AddHours(11),
                Color = Color.LightCoral
            });

            calendar.Events.Add(new CalendarEvent
            {
                Title = "Therapy",
                StartTime = DateTime.Today.AddHours(14),
                EndTime = DateTime.Today.AddHours(15),
                Color = Color.LightGreen
            });

            calendar.RenderCalendar();
            this.Controls.Add(calendar);
            calendar.BringToFront(); // Ensure calendar fills remaining space below the toolbar
        }

        private void BtnAddEvent_Click(object sender, EventArgs e)
        {
            using (Form input = new Form())
            {
                input.Text = "Add Event";
                input.Width = 300;
                input.Height = 200;

                Label lblTitle = new Label { Text = "Title:", Left = 10, Top = 20, Width = 50 };
                TextBox txtTitle = new TextBox { Left = 70, Top = 20, Width = 200 };

                Label lblStart = new Label { Text = "Start (HH:mm):", Left = 10, Top = 60, Width = 80 };
                TextBox txtStart = new TextBox { Left = 100, Top = 60, Width = 100, Text = "09:00" };

                Label lblEnd = new Label { Text = "End (HH:mm):", Left = 10, Top = 100, Width = 80 };
                TextBox txtEnd = new TextBox { Left = 100, Top = 100, Width = 100, Text = "10:00" };

                Button btnOk = new Button { Text = "OK", Left = 100, Width = 80, Top = 140, DialogResult = DialogResult.OK };

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
                        calendar.Events.Add(new CalendarEvent
                        {
                            Title = txtTitle.Text,
                            StartTime = calendar.CurrentDate.Date + start,
                            EndTime = calendar.CurrentDate.Date + end
                        });

                        calendar.RenderCalendar();
                    }
                    else
                    {
                        MessageBox.Show("Invalid time format. Use HH:mm.");
                    }
                }
            }
        }
    }
}

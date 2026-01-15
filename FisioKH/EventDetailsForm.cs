using System;
using System.Drawing;
using System.Windows.Forms;

namespace FisioKH
{
    public partial class EventDetailsForm : Form
    {
        public FisioKHCalendar Event { get; private set; }
        public bool Deleted { get; private set; }

        // REQUIRED for Designer
        public EventDetailsForm()
        {
            InitializeComponent();
        }

        // Runtime constructor
        public EventDetailsForm(FisioKHCalendar ev) : this()
        {
            Event = ev;

           /* txtTitle.Text = ev..Title;
            dtStart.Value = ev.StartTime;
            dtEnd.Value = ev.EndTime;
            pnlColor.BackColor = ev.Color;*/
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           /* Event.Title = txtTitle.Text;
            Event.StartTime = dtStart.Value;
            Event.EndTime = dtEnd.Value;
            Event.Color = pnlColor.BackColor;*/

            DialogResult = DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Deleted = true;
            DialogResult = DialogResult.OK;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnlColor.BackColor = colorDialog1.Color;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using static FisioKH.FisioKHCalendar;

namespace FisioKH
{
    public partial class EventDetailsForm : Form
    {
        private FisioKH.FisioKHCalendar.CalendarEventKH fce;
       

        // REQUIRED for Designer
        public EventDetailsForm(CalendarEventKH ce)
        {
            fce = ce;
            InitializeComponent();
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
            
            DialogResult = DialogResult.OK;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnlColor.BackColor = colorDialog1.Color;
            }
        }

        private void EventDetailsForm_Load(object sender, EventArgs e)
        {
            this.txtTitle.Text = fce.Id.ToString();
        }
    }
}

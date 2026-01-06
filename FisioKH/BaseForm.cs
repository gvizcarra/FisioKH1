using System;
using System.Drawing;
using System.Windows.Forms;

namespace FisioKH
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            ApplyClinicStyle();
        }

        // Method to apply the clinic-like style to all forms
        private void ApplyClinicStyle()
        {
            // Form settings
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F);
            this.Padding = new Padding(10);

            // Set a default title color
            this.ForeColor = Color.FromArgb(46, 134, 193);  // Clinic Blue

            // Set all buttons to modern clinic style
            foreach (Control ctrl in this.Controls)
            {
                 
                // Additional control styling (TextBox, ComboBox, Label) remains unchanged
                if (ctrl is TextBox textbox)
                {
                    textbox.BorderStyle = BorderStyle.FixedSingle;
                    textbox.BackColor = Color.White;
                    textbox.ForeColor = Color.FromArgb(46, 134, 193);
                    textbox.Font = new Font("Segoe UI", 10F);
                    textbox.Padding = new Padding(10);
                    textbox.Height = 35;
                }
                if (ctrl is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.FromArgb(46, 134, 193);
                    comboBox.Font = new Font("Segoe UI", 10F);
                    comboBox.Height = 35;
                }
                if (ctrl is Label label)
                {
                    label.ForeColor = Color.FromArgb(46, 134, 193);
                    label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                }
            }
        }

       
    }
}

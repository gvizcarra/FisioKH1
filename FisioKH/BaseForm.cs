using System;
using System.Drawing;
using System.Windows.Forms;

namespace FisioKH
{
    public class BaseForm : Form
    {
        // Single ErrorProvider for all validated controls
        protected ErrorProvider BaseErrorProvider;

        public BaseForm()
        {
            // Initialize ErrorProvider
            BaseErrorProvider = new ErrorProvider();
            BaseErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            ApplyClinicStyle();
        }

        // Apply your clinic-like style to controls
        private void ApplyClinicStyle()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FisioKHApp));

            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F);
            this.Padding = new Padding(10);
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.ForeColor = Color.FromArgb(46, 134, 193); // Clinic Blue

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox textbox)
                {
                    textbox.BorderStyle = BorderStyle.FixedSingle;
                    textbox.BackColor = Color.White;
                    textbox.ForeColor = Color.FromArgb(46, 134, 193);
                    textbox.Font = new Font("Segoe UI", 10F);
                    textbox.Padding = new Padding(10);
                    textbox.Height = 35;
                }
                else if (ctrl is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.FromArgb(46, 134, 193);
                    comboBox.Font = new Font("Segoe UI", 10F);
                    comboBox.Height = 35;
                }
                else if (ctrl is Label label)
                {
                    label.ForeColor = Color.FromArgb(46, 134, 193);
                    label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                }
            }
        }

        // Inject ErrorProvider into all ValidatedNumericTextBox controls
        protected void AssignErrorProvider(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is ValidatedNumericTextBox v)
                    v.ErrorProvider = BaseErrorProvider;

                if (ctrl.HasChildren)
                    AssignErrorProvider(ctrl);
            }
        }

        // Find first invalid ValidatedNumericTextBox
        protected Control GetFirstInvalidControl(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is ValidatedNumericTextBox v && !v.IsValid)
                    return v;

                if (ctrl.HasChildren)
                {
                    var child = GetFirstInvalidControl(ctrl);
                    if (child != null)
                        return child;
                }
            }
            return null;
        }

        // BaseForm OnLoad: assign ErrorProvider automatically
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AssignErrorProvider(this);
        }
    }
}

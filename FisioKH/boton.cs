using System;
using System.Drawing;
using System.Windows.Forms;

namespace FisioKH
{
    public class Boton : Button
    {
        public Boton()
        {
            // Set default button styles
          
            this.ForeColor = Color.FromArgb(46, 134, 193);
            this.FlatStyle = FlatStyle.Standard;
            this.Size = new System.Drawing.Size(50, 25);
            this.FlatAppearance.BorderSize = 2;   
            this.Font = new Font("Arial Rounded MT", 10F, FontStyle.Regular);
            this.Height = 30;
            this.Width = 70;
            this.Margin = new Padding(10);
 
            
            this.MouseEnter += CustomButton_MouseEnter;
            this.MouseLeave += CustomButton_MouseLeave;
        }
 
        private void CustomButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
          
        }

     
        private void CustomButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;  
        }
    }
}

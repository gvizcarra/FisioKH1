
namespace FisioKH
{
    partial class micalendario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
           base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calendarControl1 = new FisioKH.CalendarControl();
            this.boton1 = new FisioKH.Boton();
           
            // 
            // calendarControl1
            // 
            this.calendarControl1.AutoSize = true;
            this.calendarControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.calendarControl1.CurrentDate = new System.DateTime(2026, 1, 14, 0, 0, 0, 0);
            this.calendarControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calendarControl1.Location = new System.Drawing.Point(12, 140);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.Size = new System.Drawing.Size(1140, 407);
            this.calendarControl1.TabIndex = 1;
            this.calendarControl1.ViewMode = FisioKH.CalendarView.Day;
            // 
            // boton1
            // 
            this.boton1.FlatAppearance.BorderSize = 2;
            this.boton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.boton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.boton1.Location = new System.Drawing.Point(12, 97);
            this.boton1.Margin = new System.Windows.Forms.Padding(10);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(70, 30);
            this.boton1.TabIndex = 0;
            this.boton1.Text = "boton1";
            this.boton1.UseVisualStyleBackColor = true;
            // 
            // micalendario
            // 
        

        }

        #endregion

        private Boton boton1;
        private CalendarControl calendarControl1;
    }
}
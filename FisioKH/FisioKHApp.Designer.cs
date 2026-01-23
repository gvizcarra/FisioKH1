
using System.Drawing;
using System.Windows.Forms;

namespace FisioKH
{
    partial class FisioKHApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FisioKHApp));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbInicio = new System.Windows.Forms.TabPage();
            this.boton1 = new FisioKH.Boton();
            this.lstBoxLogs = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new FisioKH.ValidatedNumericTextBox();
            this.btnLogin = new FisioKH.Boton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassPin = new FisioKH.ValidatedNumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIngresos = new System.Windows.Forms.TabPage();
            this.fisioKHCalendar1 = new FisioKH.FisioKHCalendar();
            this.tbAdmin = new System.Windows.Forms.TabPage();
            this.btnFisios = new FisioKH.Boton();
            this.btnMetodosPago = new FisioKH.Boton();
            this.btnTratamientos = new FisioKH.Boton();
            this.btnPacientes = new FisioKH.Boton();
            this.btnPrecios = new FisioKH.Boton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbReportes = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCerrarSesion = new FisioKH.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbInicio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbIngresos.SuspendLayout();
            this.tbAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tbReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbInicio);
            this.tabControl1.Controls.Add(this.tbIngresos);
            this.tabControl1.Controls.Add(this.tbAdmin);
            this.tabControl1.Controls.Add(this.tbReportes);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1162, 664);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tbInicio
            // 
            this.tbInicio.Controls.Add(this.boton1);
            this.tbInicio.Controls.Add(this.lstBoxLogs);
            this.tbInicio.Controls.Add(this.groupBox1);
            this.tbInicio.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbInicio.Location = new System.Drawing.Point(4, 30);
            this.tbInicio.Name = "tbInicio";
            this.tbInicio.Size = new System.Drawing.Size(1154, 630);
            this.tbInicio.TabIndex = 3;
            this.tbInicio.Text = "Inicio - Login";
            this.tbInicio.UseVisualStyleBackColor = true;
            // 
            // boton1
            // 
            this.boton1.FlatAppearance.BorderSize = 2;
            this.boton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.boton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.boton1.Location = new System.Drawing.Point(6, 550);
            this.boton1.Margin = new System.Windows.Forms.Padding(10);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(112, 27);
            this.boton1.TabIndex = 10;
            this.boton1.Text = "Limpiar Log ?";
            this.boton1.UseVisualStyleBackColor = true;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // lstBoxLogs
            // 
            this.lstBoxLogs.FormattingEnabled = true;
            this.lstBoxLogs.ItemHeight = 21;
            this.lstBoxLogs.Location = new System.Drawing.Point(6, 581);
            this.lstBoxLogs.Name = "lstBoxLogs";
            this.lstBoxLogs.Size = new System.Drawing.Size(1152, 46);
            this.lstBoxLogs.TabIndex = 1;
            this.lstBoxLogs.Click += new System.EventHandler(this.lstBoxLogs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.BackgroundImage = global::FisioKH.Properties.Resources.fisiokh;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.btnCerrarSesion);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPassPin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(236, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 597);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credenciales";
            // 
            // txtUsuario
            // 
            this.txtUsuario.AcceptsReturn = true;
            this.txtUsuario.AcceptsTab = true;
            this.txtUsuario.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtUsuario.ErrorMessage = "Valor no Valido";
            this.txtUsuario.ErrorProvider = null;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtUsuario.IsRequired = true;
            this.txtUsuario.Location = new System.Drawing.Point(209, 25);
            this.txtUsuario.MaxValue = null;
            this.txtUsuario.MinValue = null;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.NumericOnly = false;
            this.txtUsuario.Size = new System.Drawing.Size(132, 29);
            this.txtUsuario.TabIndex = 6;
            this.txtUsuario.Text = "gabriel";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLogin.FlatAppearance.BorderSize = 2;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogin.Location = new System.Drawing.Point(363, 31);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(10);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(196, 64);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "&INGRESAR";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(127, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario";
            // 
            // txtPassPin
            // 
            this.txtPassPin.AcceptsReturn = true;
            this.txtPassPin.AcceptsTab = true;
            this.txtPassPin.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPassPin.ErrorMessage = "Valor no Valido";
            this.txtPassPin.ErrorProvider = null;
            this.txtPassPin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtPassPin.ForeColor = System.Drawing.Color.Black;
            this.txtPassPin.IsRequired = true;
            this.txtPassPin.Location = new System.Drawing.Point(209, 66);
            this.txtPassPin.MaxValue = null;
            this.txtPassPin.MinValue = null;
            this.txtPassPin.Name = "txtPassPin";
            this.txtPassPin.NumericOnly = false;
            this.txtPassPin.PasswordChar = '*';
            this.txtPassPin.Size = new System.Drawing.Size(132, 29);
            this.txtPassPin.TabIndex = 7;
            this.txtPassPin.Text = "nada";
            this.txtPassPin.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(127, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pass/PIN";
            // 
            // tbIngresos
            // 
            this.tbIngresos.Controls.Add(this.fisioKHCalendar1);
            this.tbIngresos.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbIngresos.Location = new System.Drawing.Point(4, 30);
            this.tbIngresos.Name = "tbIngresos";
            this.tbIngresos.Padding = new System.Windows.Forms.Padding(3);
            this.tbIngresos.Size = new System.Drawing.Size(1154, 630);
            this.tbIngresos.TabIndex = 0;
            this.tbIngresos.Text = "Ingresos";
            this.tbIngresos.UseVisualStyleBackColor = true;
            // 
            // fisioKHCalendar1
            // 
            this.fisioKHCalendar1.CurrentDate = new System.DateTime(2026, 1, 14, 0, 0, 0, 0);
            this.fisioKHCalendar1.DataSource = null;
            this.fisioKHCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fisioKHCalendar1.Location = new System.Drawing.Point(3, 3);
            this.fisioKHCalendar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fisioKHCalendar1.Name = "fisioKHCalendar1";
            this.fisioKHCalendar1.Size = new System.Drawing.Size(1148, 624);
            this.fisioKHCalendar1.TabIndex = 0;
            // 
            // tbAdmin
            // 
            this.tbAdmin.Controls.Add(this.btnFisios);
            this.tbAdmin.Controls.Add(this.btnMetodosPago);
            this.tbAdmin.Controls.Add(this.btnTratamientos);
            this.tbAdmin.Controls.Add(this.btnPacientes);
            this.tbAdmin.Controls.Add(this.btnPrecios);
            this.tbAdmin.Controls.Add(this.pictureBox2);
            this.tbAdmin.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbAdmin.Location = new System.Drawing.Point(4, 30);
            this.tbAdmin.Name = "tbAdmin";
            this.tbAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tbAdmin.Size = new System.Drawing.Size(1154, 630);
            this.tbAdmin.TabIndex = 1;
            this.tbAdmin.Text = "Administración";
            this.tbAdmin.UseVisualStyleBackColor = true;
            // 
            // btnFisios
            // 
            this.btnFisios.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFisios.FlatAppearance.BorderSize = 2;
            this.btnFisios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnFisios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnFisios.Location = new System.Drawing.Point(149, 80);
            this.btnFisios.Margin = new System.Windows.Forms.Padding(10);
            this.btnFisios.Name = "btnFisios";
            this.btnFisios.Size = new System.Drawing.Size(168, 58);
            this.btnFisios.TabIndex = 9;
            this.btnFisios.Text = "&FISIO TERAPEUTAS";
            this.btnFisios.UseVisualStyleBackColor = false;
            this.btnFisios.Click += new System.EventHandler(this.btnFisios_Click);
            // 
            // btnMetodosPago
            // 
            this.btnMetodosPago.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMetodosPago.FlatAppearance.BorderSize = 2;
            this.btnMetodosPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnMetodosPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnMetodosPago.Location = new System.Drawing.Point(459, 80);
            this.btnMetodosPago.Margin = new System.Windows.Forms.Padding(10);
            this.btnMetodosPago.Name = "btnMetodosPago";
            this.btnMetodosPago.Size = new System.Drawing.Size(168, 58);
            this.btnMetodosPago.TabIndex = 8;
            this.btnMetodosPago.Text = "&METODOS PAGO";
            this.btnMetodosPago.UseVisualStyleBackColor = false;
            this.btnMetodosPago.Click += new System.EventHandler(this.btnMetodosPago_Click);
            // 
            // btnTratamientos
            // 
            this.btnTratamientos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTratamientos.FlatAppearance.BorderSize = 2;
            this.btnTratamientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTratamientos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnTratamientos.Location = new System.Drawing.Point(816, 239);
            this.btnTratamientos.Margin = new System.Windows.Forms.Padding(10);
            this.btnTratamientos.Name = "btnTratamientos";
            this.btnTratamientos.Size = new System.Drawing.Size(168, 58);
            this.btnTratamientos.TabIndex = 4;
            this.btnTratamientos.Text = "&TRATAMIENTOS";
            this.btnTratamientos.UseVisualStyleBackColor = false;
            this.btnTratamientos.Click += new System.EventHandler(this.btnTratamientos_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPacientes.FlatAppearance.BorderSize = 2;
            this.btnPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPacientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnPacientes.Location = new System.Drawing.Point(149, 239);
            this.btnPacientes.Margin = new System.Windows.Forms.Padding(10);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(168, 58);
            this.btnPacientes.TabIndex = 3;
            this.btnPacientes.Text = "P&ACIENTES";
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnPrecios
            // 
            this.btnPrecios.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrecios.FlatAppearance.BorderSize = 2;
            this.btnPrecios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrecios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnPrecios.Location = new System.Drawing.Point(816, 80);
            this.btnPrecios.Margin = new System.Windows.Forms.Padding(10);
            this.btnPrecios.Name = "btnPrecios";
            this.btnPrecios.Size = new System.Drawing.Size(168, 58);
            this.btnPrecios.TabIndex = 2;
            this.btnPrecios.Text = "&PRECIOS";
            this.btnPrecios.UseVisualStyleBackColor = false;
            this.btnPrecios.Click += new System.EventHandler(this.btnPrecios_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::FisioKH.Properties.Resources.fisiokh;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(226, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(682, 491);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // tbReportes
            // 
            this.tbReportes.Controls.Add(this.pictureBox3);
            this.tbReportes.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbReportes.Location = new System.Drawing.Point(4, 30);
            this.tbReportes.Name = "tbReportes";
            this.tbReportes.Padding = new System.Windows.Forms.Padding(3);
            this.tbReportes.Size = new System.Drawing.Size(1154, 630);
            this.tbReportes.TabIndex = 2;
            this.tbReportes.Text = "Reportes";
            this.tbReportes.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::FisioKH.Properties.Resources.fisiokh;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(226, 80);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(682, 491);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCerrarSesion.FlatAppearance.BorderSize = 2;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 528);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(10);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(140, 34);
            this.btnCerrarSesion.TabIndex = 9;
            this.btnCerrarSesion.Text = "&Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FisioKHApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 681);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.Name = "FisioKHApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbInicio.ResumeLayout(false);
            this.tbInicio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbIngresos.ResumeLayout(false);
            this.tbAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tbReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tbAdmin;
        private TabPage tbReportes;
        private TabPage tbInicio;
        private Boton btnLogin;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        public ListBox lstBoxLogs;
        private ContextMenuStrip contextMenuStrip1;
        private Boton boton1;
        private TabPage tbIngresos;
        private Boton btnTratamientos;
        private Boton btnPacientes;
        private Boton btnPrecios;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Boton btnMetodosPago;
        private FisioKHCalendar fisioKHCalendar1;
        private Boton btnFisios;
        private ValidatedNumericTextBox txtPassPin;
        private ValidatedNumericTextBox txtUsuario;
        private Boton btnCerrarSesion;
    }
}



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
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tbInicio = new System.Windows.Forms.TabPage();
            this.boton1 = new FisioKH.Boton();
            this.lstBoxLogs = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalir = new FisioKH.Boton();
            this.btnCerrarSesion = new FisioKH.Boton();
            this.txtUsuario = new FisioKH.ValidatedNumericTextBox();
            this.btnLogin = new FisioKH.Boton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassPin = new FisioKH.ValidatedNumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIngresos = new System.Windows.Forms.TabPage();
            this.fisioKHCalendar1 = new FisioKH.FisioKHCalendar();
            this.tbAdmin = new System.Windows.Forms.TabPage();
            this.btnUsuarios = new FisioKH.Boton();
            this.btnFisios = new FisioKH.Boton();
            this.btnMetodosPago = new FisioKH.Boton();
            this.btnPacientes = new FisioKH.Boton();
            this.btnPrecios = new FisioKH.Boton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbReportes = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnObtenerVisitasRealizadas = new FisioKH.Boton();
            this.dgvVisitasRealizadas = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.tbInicio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbIngresos.SuspendLayout();
            this.tbAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tbReportes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitasRealizadas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tbInicio);
            this.tabPrincipal.Controls.Add(this.tbIngresos);
            this.tabPrincipal.Controls.Add(this.tbAdmin);
            this.tabPrincipal.Controls.Add(this.tbReportes);
            this.tabPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 4);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.RightToLeftLayout = true;
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(1225, 664);
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tbInicio
            // 
            this.tbInicio.Controls.Add(this.boton1);
            this.tbInicio.Controls.Add(this.lstBoxLogs);
            this.tbInicio.Controls.Add(this.groupBox1);
            this.tbInicio.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbInicio.Location = new System.Drawing.Point(4, 30);
            this.tbInicio.Name = "tbInicio";
            this.tbInicio.Size = new System.Drawing.Size(1217, 630);
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
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnCerrarSesion);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPassPin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(236, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 597);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credenciales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 542);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Version 1.3.7.1 - Abril 2-2026";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSalir.CausesValidation = false;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalir.Location = new System.Drawing.Point(509, 35);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(84, 64);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.txtUsuario.Location = new System.Drawing.Point(112, 29);
            this.txtUsuario.MaxValue = null;
            this.txtUsuario.MinValue = null;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.NumericOnly = false;
            this.txtUsuario.Size = new System.Drawing.Size(132, 29);
            this.txtUsuario.SuppressValidation = false;
            this.txtUsuario.TabIndex = 6;
            this.txtUsuario.Text = "gabriel";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLogin.FlatAppearance.BorderSize = 2;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogin.Location = new System.Drawing.Point(266, 35);
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
            this.label1.Location = new System.Drawing.Point(30, 35);
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
            this.txtPassPin.IsRequired = false;
            this.txtPassPin.Location = new System.Drawing.Point(112, 70);
            this.txtPassPin.MaxValue = null;
            this.txtPassPin.MinValue = null;
            this.txtPassPin.Name = "txtPassPin";
            this.txtPassPin.NumericOnly = false;
            this.txtPassPin.PasswordChar = '*';
            this.txtPassPin.Size = new System.Drawing.Size(132, 29);
            this.txtPassPin.SuppressValidation = false;
            this.txtPassPin.TabIndex = 7;
            this.txtPassPin.Text = "1049";
            this.txtPassPin.UseSystemPasswordChar = true;
            this.txtPassPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassPin_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(30, 76);
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
            this.tbIngresos.Size = new System.Drawing.Size(1217, 630);
            this.tbIngresos.TabIndex = 0;
            this.tbIngresos.Text = "Ingresos";
            this.tbIngresos.UseVisualStyleBackColor = true;
            // 
            // fisioKHCalendar1
            // 
            this.fisioKHCalendar1.CurrentDate = new System.DateTime(2026, 4, 21, 0, 0, 0, 0);
            this.fisioKHCalendar1.DataSource = null;
            this.fisioKHCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fisioKHCalendar1.Location = new System.Drawing.Point(3, 3);
            this.fisioKHCalendar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fisioKHCalendar1.Name = "fisioKHCalendar1";
            this.fisioKHCalendar1.Size = new System.Drawing.Size(1211, 624);
            this.fisioKHCalendar1.TabIndex = 0;
            // 
            // tbAdmin
            // 
            this.tbAdmin.Controls.Add(this.btnUsuarios);
            this.tbAdmin.Controls.Add(this.btnFisios);
            this.tbAdmin.Controls.Add(this.btnMetodosPago);
            this.tbAdmin.Controls.Add(this.btnPacientes);
            this.tbAdmin.Controls.Add(this.btnPrecios);
            this.tbAdmin.Controls.Add(this.pictureBox2);
            this.tbAdmin.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbAdmin.Location = new System.Drawing.Point(4, 30);
            this.tbAdmin.Name = "tbAdmin";
            this.tbAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tbAdmin.Size = new System.Drawing.Size(1217, 630);
            this.tbAdmin.TabIndex = 1;
            this.tbAdmin.Text = "Administración";
            this.tbAdmin.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUsuarios.Enabled = false;
            this.btnUsuarios.FlatAppearance.BorderSize = 2;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnUsuarios.Location = new System.Drawing.Point(488, 80);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(10);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(168, 58);
            this.btnUsuarios.TabIndex = 10;
            this.btnUsuarios.Text = "&USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnFisios
            // 
            this.btnFisios.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFisios.Enabled = false;
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
            this.btnMetodosPago.Enabled = false;
            this.btnMetodosPago.FlatAppearance.BorderSize = 2;
            this.btnMetodosPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnMetodosPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnMetodosPago.Location = new System.Drawing.Point(816, 239);
            this.btnMetodosPago.Margin = new System.Windows.Forms.Padding(10);
            this.btnMetodosPago.Name = "btnMetodosPago";
            this.btnMetodosPago.Size = new System.Drawing.Size(168, 58);
            this.btnMetodosPago.TabIndex = 8;
            this.btnMetodosPago.Text = "&METODOS PAGO";
            this.btnMetodosPago.UseVisualStyleBackColor = false;
            this.btnMetodosPago.Click += new System.EventHandler(this.btnMetodosPago_Click);
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
            this.btnPrecios.Enabled = false;
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
            this.tbReportes.Controls.Add(this.groupBox2);
            this.tbReportes.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbReportes.Location = new System.Drawing.Point(4, 30);
            this.tbReportes.Name = "tbReportes";
            this.tbReportes.Padding = new System.Windows.Forms.Padding(3);
            this.tbReportes.Size = new System.Drawing.Size(1217, 630);
            this.tbReportes.TabIndex = 2;
            this.tbReportes.Text = "Reportes";
            this.tbReportes.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox2.Controls.Add(this.cboMetodoPago);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.btnObtenerVisitasRealizadas);
            this.groupBox2.Controls.Add(this.dgvVisitasRealizadas);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpFechaFin);
            this.groupBox2.Controls.Add(this.dtpFechaInicio);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1205, 646);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visitas Realizadas";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Location = new System.Drawing.Point(455, 29);
            this.cboMetodoPago.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(117, 29);
            this.cboMetodoPago.TabIndex = 69;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(347, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 21);
            this.label18.TabIndex = 70;
            this.label18.Text = "Metodo Pago";
            // 
            // btnObtenerVisitasRealizadas
            // 
            this.btnObtenerVisitasRealizadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnObtenerVisitasRealizadas.FlatAppearance.BorderSize = 2;
            this.btnObtenerVisitasRealizadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObtenerVisitasRealizadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnObtenerVisitasRealizadas.ForeColor = System.Drawing.Color.Black;
            this.btnObtenerVisitasRealizadas.Location = new System.Drawing.Point(603, 26);
            this.btnObtenerVisitasRealizadas.Margin = new System.Windows.Forms.Padding(10);
            this.btnObtenerVisitasRealizadas.Name = "btnObtenerVisitasRealizadas";
            this.btnObtenerVisitasRealizadas.Size = new System.Drawing.Size(97, 29);
            this.btnObtenerVisitasRealizadas.TabIndex = 58;
            this.btnObtenerVisitasRealizadas.Text = "&Procesar";
            this.btnObtenerVisitasRealizadas.UseVisualStyleBackColor = false;
            this.btnObtenerVisitasRealizadas.Click += new System.EventHandler(this.btnObtenerVisitasRealizadas_Click);
            // 
            // dgvVisitasRealizadas
            // 
            this.dgvVisitasRealizadas.AllowUserToAddRows = false;
            this.dgvVisitasRealizadas.AllowUserToDeleteRows = false;
            this.dgvVisitasRealizadas.AllowUserToOrderColumns = true;
            this.dgvVisitasRealizadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVisitasRealizadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVisitasRealizadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisitasRealizadas.Location = new System.Drawing.Point(6, 65);
            this.dgvVisitasRealizadas.Name = "dgvVisitasRealizadas";
            this.dgvVisitasRealizadas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvVisitasRealizadas.RowTemplate.DefaultCellStyle.NullValue = " ";
            this.dgvVisitasRealizadas.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVisitasRealizadas.Size = new System.Drawing.Size(1188, 553);
            this.dgvVisitasRealizadas.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(178, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 56;
            this.label3.Text = "Hasta";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(225, 29);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.RightToLeftLayout = true;
            this.dtpFechaFin.ShowUpDown = true;
            this.dtpFechaFin.Size = new System.Drawing.Size(109, 29);
            this.dtpFechaFin.TabIndex = 55;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(63, 29);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.RightToLeftLayout = true;
            this.dtpFechaInicio.ShowUpDown = true;
            this.dtpFechaInicio.Size = new System.Drawing.Size(109, 29);
            this.dtpFechaInicio.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(18, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 19);
            this.label12.TabIndex = 53;
            this.label12.Text = "Fecha";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FisioKHApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1235, 681);
            this.Controls.Add(this.tabPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.Name = "FisioKHApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FisioKHApp_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.tbInicio.ResumeLayout(false);
            this.tbInicio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbIngresos.ResumeLayout(false);
            this.tbAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tbReportes.ResumeLayout(false);
            this.tbReportes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitasRealizadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabPrincipal;
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
        private Boton btnPacientes;
        private Boton btnPrecios;
        private PictureBox pictureBox2;
        private Boton btnMetodosPago;
        private FisioKHCalendar fisioKHCalendar1;
        private Boton btnFisios;
        private ValidatedNumericTextBox txtPassPin;
        private ValidatedNumericTextBox txtUsuario;
        private Boton btnCerrarSesion;
        private Boton btnUsuarios;
        private Boton btnSalir;
        private GroupBox groupBox2;
        private Label label3;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private Label label12;
        private DataGridView dgvVisitasRealizadas;
        private Boton btnObtenerVisitasRealizadas;
        private ComboBox cboMetodoPago;
        private Label label18;
        private Label label4;
    }
}


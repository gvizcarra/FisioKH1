
namespace FisioKH
{
    partial class Pacientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pacientes));
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new FisioKH.ValidatedNumericTextBox();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new FisioKH.ValidatedNumericTextBox();
            this.txtCelularAlta = new System.Windows.Forms.MaskedTextBox();
            this.pbxFotoPaciente = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cboPxPrecio = new System.Windows.Forms.ComboBox();
            this.txtApellidoMaterno = new FisioKH.ValidatedNumericTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtApellidoPaterno = new FisioKH.ValidatedNumericTextBox();
            this.txtEdad = new FisioKH.ValidatedNumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNuevoPaciente = new FisioKH.Boton();
            this.label6 = new System.Windows.Forms.Label();
            this.cboFisioTerapeuta = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNotasMedicas = new FisioKH.ValidatedNumericTextBox();
            this.txtObservaciones = new FisioKH.ValidatedNumericTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDetenerCamara = new FisioKH.Boton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.trkZoomFT = new System.Windows.Forms.TrackBar();
            this.cboCamaras = new System.Windows.Forms.ComboBox();
            this.btnAbrirCamara = new FisioKH.Boton();
            this.btnGuardarFoto = new FisioKH.Boton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMedicoTratante = new FisioKH.ValidatedNumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNombreFiscal = new FisioKH.ValidatedNumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDomicilioFiscal = new FisioKH.ValidatedNumericTextBox();
            this.txtRfc = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRfcFiscal = new FisioKH.ValidatedNumericTextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtEmailAlta = new FisioKH.ValidatedNumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbSexo = new System.Windows.Forms.GroupBox();
            this.rbOtro = new System.Windows.Forms.RadioButton();
            this.rbMujer = new System.Windows.Forms.RadioButton();
            this.rbHombre = new System.Windows.Forms.RadioButton();
            this.btnGuardarFT = new FisioKH.Boton();
            this.btnBuscarPaciente = new FisioKH.Boton();
            this.tbPacientes = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boton1 = new FisioKH.Boton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPaciente)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoomFT)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbSexo.SuspendLayout();
            this.tbPacientes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePaciente.Location = new System.Drawing.Point(12, 11);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(71, 17);
            this.lblNombrePaciente.TabIndex = 14;
            this.lblNombrePaciente.Text = "Paciente";
            // 
            // txtPaciente
            // 
            this.txtPaciente.AcceptsReturn = true;
            this.txtPaciente.ErrorMessage = "Valor no Valido";
            this.txtPaciente.ErrorProvider = null;
            this.txtPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.IsRequired = false;
            this.txtPaciente.Location = new System.Drawing.Point(15, 37);
            this.txtPaciente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPaciente.MaxValue = null;
            this.txtPaciente.MinValue = null;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.NumericOnly = false;
            this.txtPaciente.Size = new System.Drawing.Size(133, 26);
            this.txtPaciente.SuppressValidation = false;
            this.txtPaciente.TabIndex = 1;
            this.txtPaciente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaciente_KeyDown);
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AllowUserToOrderColumns = true;
            this.dgvPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPacientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Location = new System.Drawing.Point(15, 79);
            this.dgvPacientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.Size = new System.Drawing.Size(1105, 538);
            this.dgvPacientes.TabIndex = 10;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            this.dgvPacientes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPacientes_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Celular";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.AcceptsReturn = true;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(294, 37);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(166, 26);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(160, 38);
            this.txtCelular.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCelular.Mask = "(999) 000-00-00";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(118, 25);
            this.txtCelular.TabIndex = 2;
            this.txtCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCelular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCelular_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(752, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Celular";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.ErrorMessage = "Valor no Valido";
            this.txtNombreCompleto.ErrorProvider = null;
            this.txtNombreCompleto.IsRequired = true;
            this.txtNombreCompleto.Location = new System.Drawing.Point(16, 35);
            this.txtNombreCompleto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreCompleto.MaxLength = 100;
            this.txtNombreCompleto.MaxValue = null;
            this.txtNombreCompleto.MinValue = null;
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.NumericOnly = false;
            this.txtNombreCompleto.Size = new System.Drawing.Size(170, 25);
            this.txtNombreCompleto.SuppressValidation = false;
            this.txtNombreCompleto.TabIndex = 5;
            // 
            // txtCelularAlta
            // 
            this.txtCelularAlta.Location = new System.Drawing.Point(804, 67);
            this.txtCelularAlta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCelularAlta.Mask = "(999) 000-00-00";
            this.txtCelularAlta.Name = "txtCelularAlta";
            this.txtCelularAlta.Size = new System.Drawing.Size(101, 25);
            this.txtCelularAlta.TabIndex = 24;
            this.txtCelularAlta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // pbxFotoPaciente
            // 
            this.pbxFotoPaciente.ErrorImage = null;
            this.pbxFotoPaciente.Image = global::FisioKH.Properties.Resources.patient;
            this.pbxFotoPaciente.InitialImage = null;
            this.pbxFotoPaciente.Location = new System.Drawing.Point(98, 31);
            this.pbxFotoPaciente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbxFotoPaciente.Name = "pbxFotoPaciente";
            this.pbxFotoPaciente.Size = new System.Drawing.Size(255, 217);
            this.pbxFotoPaciente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFotoPaciente.TabIndex = 21;
            this.pbxFotoPaciente.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.cboPxPrecio);
            this.groupBox1.Controls.Add(this.txtApellidoMaterno);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtCelularAlta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtApellidoPaterno);
            this.groupBox1.Controls.Add(this.txtEdad);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnNuevoPaciente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboFisioTerapeuta);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtMedicoTratante);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dtpFechaNacimiento);
            this.groupBox1.Controls.Add(this.txtEmailAlta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.gbSexo);
            this.groupBox1.Controls.Add(this.txtNombreCompleto);
            this.groupBox1.Controls.Add(this.btnGuardarFT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(955, 644);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(864, 99);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(41, 25);
            this.txtId.TabIndex = 54;
            this.txtId.Visible = false;
            // 
            // cboPxPrecio
            // 
            this.cboPxPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPxPrecio.FormattingEnabled = true;
            this.cboPxPrecio.Location = new System.Drawing.Point(569, 86);
            this.cboPxPrecio.Name = "cboPxPrecio";
            this.cboPxPrecio.Size = new System.Drawing.Size(143, 25);
            this.cboPxPrecio.TabIndex = 16;
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.ErrorMessage = "Valor no Valido";
            this.txtApellidoMaterno.ErrorProvider = null;
            this.txtApellidoMaterno.IsRequired = true;
            this.txtApellidoMaterno.Location = new System.Drawing.Point(385, 35);
            this.txtApellidoMaterno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtApellidoMaterno.MaxLength = 100;
            this.txtApellidoMaterno.MaxValue = null;
            this.txtApellidoMaterno.MinValue = null;
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.NumericOnly = false;
            this.txtApellidoMaterno.Size = new System.Drawing.Size(170, 25);
            this.txtApellidoMaterno.SuppressValidation = false;
            this.txtApellidoMaterno.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(381, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 19);
            this.label15.TabIndex = 50;
            this.label15.Text = "Ap. Materno";
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.ErrorMessage = "Valor no Valido";
            this.txtApellidoPaterno.ErrorProvider = null;
            this.txtApellidoPaterno.IsRequired = true;
            this.txtApellidoPaterno.Location = new System.Drawing.Point(201, 35);
            this.txtApellidoPaterno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtApellidoPaterno.MaxLength = 100;
            this.txtApellidoPaterno.MaxValue = null;
            this.txtApellidoPaterno.MinValue = null;
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.NumericOnly = false;
            this.txtApellidoPaterno.Size = new System.Drawing.Size(170, 25);
            this.txtApellidoPaterno.SuppressValidation = false;
            this.txtApellidoPaterno.TabIndex = 6;
            // 
            // txtEdad
            // 
            this.txtEdad.ErrorMessage = "Valor no Valido";
            this.txtEdad.ErrorProvider = null;
            this.txtEdad.IsRequired = true;
            this.txtEdad.Location = new System.Drawing.Point(804, 98);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdad.MaxLength = 100;
            this.txtEdad.MaxValue = null;
            this.txtEdad.MinValue = null;
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.NumericOnly = false;
            this.txtEdad.Size = new System.Drawing.Size(41, 25);
            this.txtEdad.SuppressValidation = false;
            this.txtEdad.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(197, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 19);
            this.label14.TabIndex = 48;
            this.label14.Text = "Ap. Paterno";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(752, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "Edad";
            // 
            // btnNuevoPaciente
            // 
            this.btnNuevoPaciente.BackColor = System.Drawing.Color.LightGray;
            this.btnNuevoPaciente.FlatAppearance.BorderSize = 2;
            this.btnNuevoPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevoPaciente.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoPaciente.Location = new System.Drawing.Point(628, 414);
            this.btnNuevoPaciente.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.btnNuevoPaciente.Name = "btnNuevoPaciente";
            this.btnNuevoPaciente.Size = new System.Drawing.Size(105, 62);
            this.btnNuevoPaciente.TabIndex = 47;
            this.btnNuevoPaciente.Text = "&Nuevo";
            this.btnNuevoPaciente.UseVisualStyleBackColor = false;
            this.btnNuevoPaciente.Click += new System.EventHandler(this.btnNuevoPaciente_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(402, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 19);
            this.label6.TabIndex = 46;
            this.label6.Text = "FisioTerapeuta";
            // 
            // cboFisioTerapeuta
            // 
            this.cboFisioTerapeuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFisioTerapeuta.FormattingEnabled = true;
            this.cboFisioTerapeuta.Location = new System.Drawing.Point(404, 86);
            this.cboFisioTerapeuta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboFisioTerapeuta.Name = "cboFisioTerapeuta";
            this.cboFisioTerapeuta.Size = new System.Drawing.Size(147, 25);
            this.cboFisioTerapeuta.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNotasMedicas);
            this.groupBox3.Controls.Add(this.txtObservaciones);
            this.groupBox3.Location = new System.Drawing.Point(13, 119);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(936, 154);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Diagnostico---------------------------------- Notas ";
            // 
            // txtNotasMedicas
            // 
            this.txtNotasMedicas.ErrorMessage = "Valor no Valido";
            this.txtNotasMedicas.ErrorProvider = null;
            this.txtNotasMedicas.IsRequired = false;
            this.txtNotasMedicas.Location = new System.Drawing.Point(484, 20);
            this.txtNotasMedicas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotasMedicas.MaxLength = 4000;
            this.txtNotasMedicas.MaxValue = null;
            this.txtNotasMedicas.MinValue = null;
            this.txtNotasMedicas.Multiline = true;
            this.txtNotasMedicas.Name = "txtNotasMedicas";
            this.txtNotasMedicas.NumericOnly = false;
            this.txtNotasMedicas.Size = new System.Drawing.Size(446, 126);
            this.txtNotasMedicas.SuppressValidation = false;
            this.txtNotasMedicas.TabIndex = 18;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.ErrorMessage = "Valor no Valido";
            this.txtObservaciones.ErrorProvider = null;
            this.txtObservaciones.IsRequired = false;
            this.txtObservaciones.Location = new System.Drawing.Point(6, 20);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservaciones.MaxLength = 4000;
            this.txtObservaciones.MaxValue = null;
            this.txtObservaciones.MinValue = null;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.NumericOnly = false;
            this.txtObservaciones.Size = new System.Drawing.Size(472, 126);
            this.txtObservaciones.SuppressValidation = false;
            this.txtObservaciones.TabIndex = 17;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDetenerCamara);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.pbxFotoPaciente);
            this.groupBox4.Controls.Add(this.cboCamaras);
            this.groupBox4.Controls.Add(this.btnAbrirCamara);
            this.groupBox4.Controls.Add(this.btnGuardarFoto);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 342);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(573, 286);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Foto";
            // 
            // btnDetenerCamara
            // 
            this.btnDetenerCamara.Enabled = false;
            this.btnDetenerCamara.FlatAppearance.BorderSize = 2;
            this.btnDetenerCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnDetenerCamara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnDetenerCamara.Location = new System.Drawing.Point(364, 184);
            this.btnDetenerCamara.Margin = new System.Windows.Forms.Padding(10);
            this.btnDetenerCamara.Name = "btnDetenerCamara";
            this.btnDetenerCamara.Size = new System.Drawing.Size(94, 63);
            this.btnDetenerCamara.TabIndex = 37;
            this.btnDetenerCamara.Text = "&Detener";
            this.btnDetenerCamara.UseVisualStyleBackColor = true;
            this.btnDetenerCamara.Click += new System.EventHandler(this.btnDetenerCamara_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.trkZoomFT);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(20, 24);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(61, 232);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Zoom";
            // 
            // trkZoomFT
            // 
            this.trkZoomFT.Location = new System.Drawing.Point(8, 18);
            this.trkZoomFT.Maximum = 50;
            this.trkZoomFT.Name = "trkZoomFT";
            this.trkZoomFT.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkZoomFT.Size = new System.Drawing.Size(45, 206);
            this.trkZoomFT.TabIndex = 36;
            this.trkZoomFT.Scroll += new System.EventHandler(this.trkZoomFT_Scroll);
            // 
            // cboCamaras
            // 
            this.cboCamaras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCamaras.FormattingEnabled = true;
            this.cboCamaras.Location = new System.Drawing.Point(364, 110);
            this.cboCamaras.Name = "cboCamaras";
            this.cboCamaras.Size = new System.Drawing.Size(173, 24);
            this.cboCamaras.TabIndex = 22;
            this.cboCamaras.SelectedIndexChanged += new System.EventHandler(this.cboCamaras_SelectedIndexChanged);
            // 
            // btnAbrirCamara
            // 
            this.btnAbrirCamara.Enabled = false;
            this.btnAbrirCamara.FlatAppearance.BorderSize = 2;
            this.btnAbrirCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnAbrirCamara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnAbrirCamara.Location = new System.Drawing.Point(366, 31);
            this.btnAbrirCamara.Margin = new System.Windows.Forms.Padding(10);
            this.btnAbrirCamara.Name = "btnAbrirCamara";
            this.btnAbrirCamara.Size = new System.Drawing.Size(94, 55);
            this.btnAbrirCamara.TabIndex = 23;
            this.btnAbrirCamara.Text = "&Abrir Camara";
            this.btnAbrirCamara.UseVisualStyleBackColor = true;
            this.btnAbrirCamara.Click += new System.EventHandler(this.btnAbrirCamara_Click_1);
            // 
            // btnGuardarFoto
            // 
            this.btnGuardarFoto.Enabled = false;
            this.btnGuardarFoto.FlatAppearance.BorderSize = 2;
            this.btnGuardarFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.btnGuardarFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarFoto.Location = new System.Drawing.Point(466, 185);
            this.btnGuardarFoto.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.btnGuardarFoto.Name = "btnGuardarFoto";
            this.btnGuardarFoto.Size = new System.Drawing.Size(92, 63);
            this.btnGuardarFoto.TabIndex = 26;
            this.btnGuardarFoto.Text = "&Captura Foto";
            this.btnGuardarFoto.UseVisualStyleBackColor = true;
            this.btnGuardarFoto.Click += new System.EventHandler(this.btnGuardarFoto_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(565, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 19);
            this.label13.TabIndex = 42;
            this.label13.Text = "Precio";
            // 
            // txtMedicoTratante
            // 
            this.txtMedicoTratante.ErrorMessage = "Valor no Valido";
            this.txtMedicoTratante.ErrorProvider = null;
            this.txtMedicoTratante.IsRequired = true;
            this.txtMedicoTratante.Location = new System.Drawing.Point(743, 35);
            this.txtMedicoTratante.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMedicoTratante.MaxLength = 150;
            this.txtMedicoTratante.MaxValue = null;
            this.txtMedicoTratante.MinValue = null;
            this.txtMedicoTratante.Name = "txtMedicoTratante";
            this.txtMedicoTratante.NumericOnly = false;
            this.txtMedicoTratante.Size = new System.Drawing.Size(188, 25);
            this.txtMedicoTratante.SuppressValidation = false;
            this.txtMedicoTratante.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(739, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 19);
            this.label12.TabIndex = 40;
            this.label12.Text = "Medico Tratante";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(565, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 19);
            this.label11.TabIndex = 40;
            this.label11.Text = "Fecha Nacimiento";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNombreFiscal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDomicilioFiscal);
            this.groupBox2.Controls.Add(this.txtRfc);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtRfcFiscal);
            this.groupBox2.Location = new System.Drawing.Point(11, 284);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(578, 57);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Fiscales";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtNombreFiscal
            // 
            this.txtNombreFiscal.ErrorMessage = "Valor no Valido";
            this.txtNombreFiscal.ErrorProvider = null;
            this.txtNombreFiscal.IsRequired = false;
            this.txtNombreFiscal.Location = new System.Drawing.Point(431, 20);
            this.txtNombreFiscal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreFiscal.MaxLength = 150;
            this.txtNombreFiscal.MaxValue = null;
            this.txtNombreFiscal.MinValue = null;
            this.txtNombreFiscal.Name = "txtNombreFiscal";
            this.txtNombreFiscal.NumericOnly = false;
            this.txtNombreFiscal.Size = new System.Drawing.Size(141, 25);
            this.txtNombreFiscal.SuppressValidation = false;
            this.txtNombreFiscal.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(377, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 19);
            this.label10.TabIndex = 38;
            this.label10.Text = "Nombre";
            // 
            // txtDomicilioFiscal
            // 
            this.txtDomicilioFiscal.ErrorMessage = "Valor no Valido";
            this.txtDomicilioFiscal.ErrorProvider = null;
            this.txtDomicilioFiscal.IsRequired = false;
            this.txtDomicilioFiscal.Location = new System.Drawing.Point(209, 20);
            this.txtDomicilioFiscal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDomicilioFiscal.MaxLength = 150;
            this.txtDomicilioFiscal.MaxValue = null;
            this.txtDomicilioFiscal.MinValue = null;
            this.txtDomicilioFiscal.Name = "txtDomicilioFiscal";
            this.txtDomicilioFiscal.NumericOnly = false;
            this.txtDomicilioFiscal.Size = new System.Drawing.Size(151, 25);
            this.txtDomicilioFiscal.SuppressValidation = false;
            this.txtDomicilioFiscal.TabIndex = 20;
            // 
            // txtRfc
            // 
            this.txtRfc.AutoSize = true;
            this.txtRfc.Location = new System.Drawing.Point(5, 29);
            this.txtRfc.Name = "txtRfc";
            this.txtRfc.Size = new System.Drawing.Size(33, 19);
            this.txtRfc.TabIndex = 34;
            this.txtRfc.Text = "RFC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(164, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 19);
            this.label9.TabIndex = 36;
            this.label9.Text = "Dom";
            // 
            // txtRfcFiscal
            // 
            this.txtRfcFiscal.ErrorMessage = "Valor no Valido";
            this.txtRfcFiscal.ErrorProvider = null;
            this.txtRfcFiscal.IsRequired = false;
            this.txtRfcFiscal.Location = new System.Drawing.Point(38, 21);
            this.txtRfcFiscal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRfcFiscal.MaxLength = 100;
            this.txtRfcFiscal.MaxValue = null;
            this.txtRfcFiscal.MinValue = null;
            this.txtRfcFiscal.Name = "txtRfcFiscal";
            this.txtRfcFiscal.NumericOnly = false;
            this.txtRfcFiscal.Size = new System.Drawing.Size(107, 25);
            this.txtRfcFiscal.SuppressValidation = false;
            this.txtRfcFiscal.TabIndex = 19;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(569, 35);
            this.dtpFechaNacimiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(141, 25);
            this.dtpFechaNacimiento.TabIndex = 13;
            // 
            // txtEmailAlta
            // 
            this.txtEmailAlta.ErrorMessage = "Valor no Valido";
            this.txtEmailAlta.ErrorProvider = null;
            this.txtEmailAlta.IsRequired = false;
            this.txtEmailAlta.Location = new System.Drawing.Point(234, 86);
            this.txtEmailAlta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmailAlta.MaxLength = 100;
            this.txtEmailAlta.MaxValue = null;
            this.txtEmailAlta.MinValue = null;
            this.txtEmailAlta.Name = "txtEmailAlta";
            this.txtEmailAlta.NumericOnly = false;
            this.txtEmailAlta.Size = new System.Drawing.Size(164, 25);
            this.txtEmailAlta.SuppressValidation = false;
            this.txtEmailAlta.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 30;
            this.label5.Text = "Email";
            // 
            // gbSexo
            // 
            this.gbSexo.Controls.Add(this.rbOtro);
            this.gbSexo.Controls.Add(this.rbMujer);
            this.gbSexo.Controls.Add(this.rbHombre);
            this.gbSexo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbSexo.Location = new System.Drawing.Point(13, 67);
            this.gbSexo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbSexo.Name = "gbSexo";
            this.gbSexo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbSexo.Size = new System.Drawing.Size(211, 44);
            this.gbSexo.TabIndex = 29;
            this.gbSexo.TabStop = false;
            this.gbSexo.Text = "Sexo";
            // 
            // rbOtro
            // 
            this.rbOtro.AutoSize = true;
            this.rbOtro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbOtro.Location = new System.Drawing.Point(161, 21);
            this.rbOtro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbOtro.Name = "rbOtro";
            this.rbOtro.Size = new System.Drawing.Size(49, 19);
            this.rbOtro.TabIndex = 10;
            this.rbOtro.Text = "Otro";
            this.rbOtro.UseVisualStyleBackColor = true;
            // 
            // rbMujer
            // 
            this.rbMujer.AutoSize = true;
            this.rbMujer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbMujer.Location = new System.Drawing.Point(94, 21);
            this.rbMujer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbMujer.Name = "rbMujer";
            this.rbMujer.Size = new System.Drawing.Size(56, 19);
            this.rbMujer.TabIndex = 9;
            this.rbMujer.Text = "Mujer";
            this.rbMujer.UseVisualStyleBackColor = true;
            // 
            // rbHombre
            // 
            this.rbHombre.AutoSize = true;
            this.rbHombre.Checked = true;
            this.rbHombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbHombre.Location = new System.Drawing.Point(15, 21);
            this.rbHombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbHombre.Name = "rbHombre";
            this.rbHombre.Size = new System.Drawing.Size(69, 19);
            this.rbHombre.TabIndex = 8;
            this.rbHombre.TabStop = true;
            this.rbHombre.Text = "Hombre";
            this.rbHombre.UseVisualStyleBackColor = true;
            // 
            // btnGuardarFT
            // 
            this.btnGuardarFT.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGuardarFT.FlatAppearance.BorderSize = 2;
            this.btnGuardarFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarFT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarFT.Location = new System.Drawing.Point(628, 296);
            this.btnGuardarFT.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.btnGuardarFT.Name = "btnGuardarFT";
            this.btnGuardarFT.Size = new System.Drawing.Size(105, 77);
            this.btnGuardarFT.TabIndex = 27;
            this.btnGuardarFT.Text = "&Guardar Cambios";
            this.btnGuardarFT.UseVisualStyleBackColor = false;
            this.btnGuardarFT.Click += new System.EventHandler(this.btnGuardarFT_Click);
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.FlatAppearance.BorderSize = 2;
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBuscarPaciente.Location = new System.Drawing.Point(488, 29);
            this.btnBuscarPaciente.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(111, 41);
            this.btnBuscarPaciente.TabIndex = 4;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // tbPacientes
            // 
            this.tbPacientes.Controls.Add(this.tabPage1);
            this.tbPacientes.Controls.Add(this.tabPage2);
            this.tbPacientes.Location = new System.Drawing.Point(4, 4);
            this.tbPacientes.Name = "tbPacientes";
            this.tbPacientes.SelectedIndex = 0;
            this.tbPacientes.Size = new System.Drawing.Size(1162, 692);
            this.tbPacientes.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.boton1);
            this.tabPage1.Controls.Add(this.btnBuscarPaciente);
            this.tabPage1.Controls.Add(this.dgvPacientes);
            this.tabPage1.Controls.Add(this.txtCelular);
            this.tabPage1.Controls.Add(this.txtPaciente);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblNombrePaciente);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1154, 662);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // boton1
            // 
            this.boton1.FlatAppearance.BorderSize = 2;
            this.boton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.boton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.boton1.Location = new System.Drawing.Point(623, 29);
            this.boton1.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(111, 41);
            this.boton1.TabIndex = 21;
            this.boton1.Text = "&Nuevo";
            this.boton1.UseVisualStyleBackColor = true;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1154, 662);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Pacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 664);
            this.Controls.Add(this.tbPacientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Pacientes";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.Text = "Pacientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pacientes_FormClosing);
            this.Load += new System.EventHandler(this.Pacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPaciente)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoomFT)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbSexo.ResumeLayout(false);
            this.gbSexo.PerformLayout();
            this.tbPacientes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNombrePaciente;
        private FisioKH.ValidatedNumericTextBox txtPaciente;
        private Boton btnBuscarPaciente;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Boton btnGuardarFT;
        private FisioKH.ValidatedNumericTextBox txtNombreCompleto;
        private System.Windows.Forms.MaskedTextBox txtCelularAlta;
        private System.Windows.Forms.PictureBox pbxFotoPaciente;
        private Boton btnGuardarFoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbSexo;
        private System.Windows.Forms.RadioButton rbOtro;
        private System.Windows.Forms.RadioButton rbMujer;
        private System.Windows.Forms.RadioButton rbHombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private FisioKH.ValidatedNumericTextBox txtNombreFiscal;
        private System.Windows.Forms.Label label10;
        private FisioKH.ValidatedNumericTextBox txtDomicilioFiscal;
        private System.Windows.Forms.Label txtRfc;
        private System.Windows.Forms.Label label9;
        private FisioKH.ValidatedNumericTextBox txtRfcFiscal;
        private FisioKH.ValidatedNumericTextBox txtEdad;
        private System.Windows.Forms.Label label7;
        private FisioKH.ValidatedNumericTextBox txtEmailAlta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private FisioKH.ValidatedNumericTextBox txtMedicoTratante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private FisioKH.ValidatedNumericTextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboFisioTerapeuta;
        private Boton btnNuevoPaciente;
        private Boton btnDetenerCamara;
        private System.Windows.Forms.TrackBar trkZoomFT;
        private System.Windows.Forms.ComboBox cboCamaras;
        private Boton btnAbrirCamara;
        private ValidatedNumericTextBox txtApellidoMaterno;
        private System.Windows.Forms.Label label15;
        private ValidatedNumericTextBox txtApellidoPaterno;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private ValidatedNumericTextBox txtNotasMedicas;
        private System.Windows.Forms.ComboBox cboPxPrecio;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TabControl tbPacientes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Boton boton1;
    }
}
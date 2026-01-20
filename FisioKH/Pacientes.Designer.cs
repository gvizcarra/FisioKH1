
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
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtCelularAlta = new System.Windows.Forms.MaskedTextBox();
            this.pbxFotoPaciente = new System.Windows.Forms.PictureBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cboEtiqueta = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMedicoTratante = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNombreFiscal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDomicilioFiscal = new System.Windows.Forms.TextBox();
            this.txtRfc = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRfcFiscal = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmailAlta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbSexo = new System.Windows.Forms.GroupBox();
            this.rbOtro = new System.Windows.Forms.RadioButton();
            this.rbMujer = new System.Windows.Forms.RadioButton();
            this.rbHombre = new System.Windows.Forms.RadioButton();
            this.cboFisioTerapeuta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnZoomIn = new FisioKH.Boton();
            this.btnZoomOut = new FisioKH.Boton();
            this.btnAbrirCamara = new FisioKH.Boton();
            this.btnGuardarFoto = new FisioKH.Boton();
            this.btnGuardarFT = new FisioKH.Boton();
            this.btnBuscarPaciente = new FisioKH.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPaciente)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbSexo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePaciente.Location = new System.Drawing.Point(0, 5);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(71, 17);
            this.lblNombrePaciente.TabIndex = 14;
            this.lblNombrePaciente.Text = "Paciente";
            // 
            // txtPaciente
            // 
            this.txtPaciente.AcceptsReturn = true;
            this.txtPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.Location = new System.Drawing.Point(3, 25);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(115, 26);
            this.txtPaciente.TabIndex = 12;
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AllowUserToOrderColumns = true;
            this.dgvPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPacientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Location = new System.Drawing.Point(3, 57);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.Size = new System.Drawing.Size(500, 439);
            this.dgvPacientes.TabIndex = 10;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            this.dgvPacientes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPacientes_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Celular";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(239, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.AcceptsReturn = true;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(242, 25);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(143, 26);
            this.txtEmail.TabIndex = 19;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(124, 30);
            this.txtCelular.Mask = "(999) 000-00-00";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(102, 20);
            this.txtCelular.TabIndex = 26;
            this.txtCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ciudad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Celular";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(61, 25);
            this.txtNombreCompleto.MaxLength = 100;
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(112, 20);
            this.txtNombreCompleto.TabIndex = 16;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(234, 25);
            this.txtCiudad.MaxLength = 10;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(73, 20);
            this.txtCiudad.TabIndex = 17;
            // 
            // txtCelularAlta
            // 
            this.txtCelularAlta.Location = new System.Drawing.Point(368, 25);
            this.txtCelularAlta.Mask = "(999) 000-00-00";
            this.txtCelularAlta.Name = "txtCelularAlta";
            this.txtCelularAlta.Size = new System.Drawing.Size(87, 20);
            this.txtCelularAlta.TabIndex = 18;
            this.txtCelularAlta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // pbxFotoPaciente
            // 
            this.pbxFotoPaciente.ErrorImage = null;
            this.pbxFotoPaciente.Image = global::FisioKH.Properties.Resources.patient;
            this.pbxFotoPaciente.InitialImage = null;
            this.pbxFotoPaciente.Location = new System.Drawing.Point(94, 12);
            this.pbxFotoPaciente.Name = "pbxFotoPaciente";
            this.pbxFotoPaciente.Size = new System.Drawing.Size(199, 200);
            this.pbxFotoPaciente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFotoPaciente.TabIndex = 21;
            this.pbxFotoPaciente.TabStop = false;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(317, 9);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(54, 20);
            this.txtId.TabIndex = 23;
            this.txtId.Visible = false;
            // 
            // cboEtiqueta
            // 
            this.cboEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtiqueta.FormattingEnabled = true;
            this.cboEtiqueta.Location = new System.Drawing.Point(326, 161);
            this.cboEtiqueta.Name = "cboEtiqueta";
            this.cboEtiqueta.Size = new System.Drawing.Size(121, 21);
            this.cboEtiqueta.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboFisioTerapeuta);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtMedicoTratante);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpFechaNacimiento);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtEdad);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtEmailAlta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.gbSexo);
            this.groupBox1.Controls.Add(this.cboEtiqueta);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.txtCelularAlta);
            this.groupBox1.Controls.Add(this.txtCiudad);
            this.groupBox1.Controls.Add(this.txtNombreCompleto);
            this.groupBox1.Controls.Add(this.btnGuardarFT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(521, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 484);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.btnAbrirCamara);
            this.groupBox4.Controls.Add(this.btnGuardarFoto);
            this.groupBox4.Controls.Add(this.pbxFotoPaciente);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(14, 266);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 218);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Foto";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnZoomIn);
            this.groupBox5.Controls.Add(this.btnZoomOut);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 65);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(76, 100);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Zoom";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtObservaciones);
            this.groupBox3.Location = new System.Drawing.Point(14, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 87);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(7, 19);
            this.txtObservaciones.MaxLength = 100;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(446, 58);
            this.txtObservaciones.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(323, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "TAG";
            // 
            // txtMedicoTratante
            // 
            this.txtMedicoTratante.Location = new System.Drawing.Point(132, 161);
            this.txtMedicoTratante.MaxLength = 150;
            this.txtMedicoTratante.Name = "txtMedicoTratante";
            this.txtMedicoTratante.Size = new System.Drawing.Size(188, 20);
            this.txtMedicoTratante.TabIndex = 41;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(129, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Medico Tratante";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Fecha Nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(14, 161);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(104, 20);
            this.dtpFechaNacimiento.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNombreFiscal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDomicilioFiscal);
            this.groupBox2.Controls.Add(this.txtRfc);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtRfcFiscal);
            this.groupBox2.Location = new System.Drawing.Point(14, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 50);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Fiscales";
            // 
            // txtNombreFiscal
            // 
            this.txtNombreFiscal.Location = new System.Drawing.Point(334, 19);
            this.txtNombreFiscal.MaxLength = 150;
            this.txtNombreFiscal.Name = "txtNombreFiscal";
            this.txtNombreFiscal.Size = new System.Drawing.Size(119, 20);
            this.txtNombreFiscal.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(288, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Nombre";
            // 
            // txtDomicilioFiscal
            // 
            this.txtDomicilioFiscal.Location = new System.Drawing.Point(158, 19);
            this.txtDomicilioFiscal.MaxLength = 150;
            this.txtDomicilioFiscal.Name = "txtDomicilioFiscal";
            this.txtDomicilioFiscal.Size = new System.Drawing.Size(130, 20);
            this.txtDomicilioFiscal.TabIndex = 37;
            // 
            // txtRfc
            // 
            this.txtRfc.AutoSize = true;
            this.txtRfc.Location = new System.Drawing.Point(4, 26);
            this.txtRfc.Name = "txtRfc";
            this.txtRfc.Size = new System.Drawing.Size(28, 13);
            this.txtRfc.TabIndex = 34;
            this.txtRfc.Text = "RFC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Dom";
            // 
            // txtRfcFiscal
            // 
            this.txtRfcFiscal.Location = new System.Drawing.Point(33, 20);
            this.txtRfcFiscal.MaxLength = 100;
            this.txtRfcFiscal.Name = "txtRfcFiscal";
            this.txtRfcFiscal.Size = new System.Drawing.Size(92, 20);
            this.txtRfcFiscal.TabIndex = 35;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(419, 66);
            this.txtEdad.MaxLength = 100;
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(36, 20);
            this.txtEdad.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Edad";
            // 
            // txtEmailAlta
            // 
            this.txtEmailAlta.Location = new System.Drawing.Point(259, 66);
            this.txtEmailAlta.MaxLength = 100;
            this.txtEmailAlta.Name = "txtEmailAlta";
            this.txtEmailAlta.Size = new System.Drawing.Size(112, 20);
            this.txtEmailAlta.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Email";
            // 
            // gbSexo
            // 
            this.gbSexo.Controls.Add(this.rbOtro);
            this.gbSexo.Controls.Add(this.rbMujer);
            this.gbSexo.Controls.Add(this.rbHombre);
            this.gbSexo.Location = new System.Drawing.Point(14, 51);
            this.gbSexo.Name = "gbSexo";
            this.gbSexo.Size = new System.Drawing.Size(191, 39);
            this.gbSexo.TabIndex = 29;
            this.gbSexo.TabStop = false;
            this.gbSexo.Text = "Sexo";
            // 
            // rbOtro
            // 
            this.rbOtro.AutoSize = true;
            this.rbOtro.Location = new System.Drawing.Point(138, 16);
            this.rbOtro.Name = "rbOtro";
            this.rbOtro.Size = new System.Drawing.Size(45, 17);
            this.rbOtro.TabIndex = 30;
            this.rbOtro.TabStop = true;
            this.rbOtro.Text = "Otro";
            this.rbOtro.UseVisualStyleBackColor = true;
            // 
            // rbMujer
            // 
            this.rbMujer.AutoSize = true;
            this.rbMujer.Location = new System.Drawing.Point(81, 16);
            this.rbMujer.Name = "rbMujer";
            this.rbMujer.Size = new System.Drawing.Size(51, 17);
            this.rbMujer.TabIndex = 29;
            this.rbMujer.TabStop = true;
            this.rbMujer.Text = "Mujer";
            this.rbMujer.UseVisualStyleBackColor = true;
            // 
            // rbHombre
            // 
            this.rbHombre.AutoSize = true;
            this.rbHombre.Location = new System.Drawing.Point(13, 16);
            this.rbHombre.Name = "rbHombre";
            this.rbHombre.Size = new System.Drawing.Size(62, 17);
            this.rbHombre.TabIndex = 28;
            this.rbHombre.TabStop = true;
            this.rbHombre.Text = "Hombre";
            this.rbHombre.UseVisualStyleBackColor = true;
            // 
            // cboFisioTerapeuta
            // 
            this.cboFisioTerapeuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFisioTerapeuta.FormattingEnabled = true;
            this.cboFisioTerapeuta.Location = new System.Drawing.Point(346, 299);
            this.cboFisioTerapeuta.Name = "cboFisioTerapeuta";
            this.cboFisioTerapeuta.Size = new System.Drawing.Size(121, 21);
            this.cboFisioTerapeuta.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "FisioTerapeuta";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Enabled = false;
            this.btnZoomIn.FlatAppearance.BorderSize = 2;
            this.btnZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnZoomIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnZoomIn.Location = new System.Drawing.Point(5, 20);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(10);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(65, 30);
            this.btnZoomIn.TabIndex = 25;
            this.btnZoomIn.Text = "++";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Enabled = false;
            this.btnZoomOut.FlatAppearance.BorderSize = 2;
            this.btnZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnZoomOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnZoomOut.Location = new System.Drawing.Point(5, 57);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(10);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(65, 30);
            this.btnZoomOut.TabIndex = 26;
            this.btnZoomOut.Text = "--";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnAbrirCamara
            // 
            this.btnAbrirCamara.FlatAppearance.BorderSize = 2;
            this.btnAbrirCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnAbrirCamara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnAbrirCamara.Location = new System.Drawing.Point(12, 19);
            this.btnAbrirCamara.Margin = new System.Windows.Forms.Padding(10);
            this.btnAbrirCamara.Name = "btnAbrirCamara";
            this.btnAbrirCamara.Size = new System.Drawing.Size(70, 46);
            this.btnAbrirCamara.TabIndex = 22;
            this.btnAbrirCamara.Text = "&Abrir Camara";
            this.btnAbrirCamara.UseVisualStyleBackColor = true;
            this.btnAbrirCamara.Click += new System.EventHandler(this.btnAbrirCamara_Click);
            // 
            // btnGuardarFoto
            // 
            this.btnGuardarFoto.Enabled = false;
            this.btnGuardarFoto.FlatAppearance.BorderSize = 2;
            this.btnGuardarFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.btnGuardarFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarFoto.Location = new System.Drawing.Point(12, 166);
            this.btnGuardarFoto.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarFoto.Name = "btnGuardarFoto";
            this.btnGuardarFoto.Size = new System.Drawing.Size(70, 46);
            this.btnGuardarFoto.TabIndex = 24;
            this.btnGuardarFoto.Text = "&Captura Foto";
            this.btnGuardarFoto.UseVisualStyleBackColor = true;
            this.btnGuardarFoto.Click += new System.EventHandler(this.btnGuardarFoto_Click);
            // 
            // btnGuardarFT
            // 
            this.btnGuardarFT.FlatAppearance.BorderSize = 2;
            this.btnGuardarFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarFT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarFT.Location = new System.Drawing.Point(365, 341);
            this.btnGuardarFT.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarFT.Name = "btnGuardarFT";
            this.btnGuardarFT.Size = new System.Drawing.Size(90, 130);
            this.btnGuardarFT.TabIndex = 9;
            this.btnGuardarFT.Text = "&Guardar Cambios";
            this.btnGuardarFT.UseVisualStyleBackColor = true;
            this.btnGuardarFT.Click += new System.EventHandler(this.btnGuardarFT_Click);
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.FlatAppearance.BorderSize = 2;
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBuscarPaciente.Location = new System.Drawing.Point(408, 19);
            this.btnBuscarPaciente.Margin = new System.Windows.Forms.Padding(10);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(95, 31);
            this.btnBuscarPaciente.TabIndex = 11;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // Pacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 508);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombrePaciente);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.dgvPacientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pacientes";
            this.Text = "Pacientes";
            this.Load += new System.EventHandler(this.Pacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPaciente)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbSexo.ResumeLayout(false);
            this.gbSexo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private Boton btnBuscarPaciente;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Boton btnGuardarFT;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.MaskedTextBox txtCelularAlta;
        private System.Windows.Forms.PictureBox pbxFotoPaciente;
        private Boton btnAbrirCamara;
        private System.Windows.Forms.TextBox txtId;
        private Boton btnGuardarFoto;
        private System.Windows.Forms.ComboBox cboEtiqueta;
        private Boton btnZoomIn;
        private Boton btnZoomOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbSexo;
        private System.Windows.Forms.RadioButton rbOtro;
        private System.Windows.Forms.RadioButton rbMujer;
        private System.Windows.Forms.RadioButton rbHombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombreFiscal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDomicilioFiscal;
        private System.Windows.Forms.Label txtRfc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRfcFiscal;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmailAlta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMedicoTratante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboFisioTerapeuta;
    }
}
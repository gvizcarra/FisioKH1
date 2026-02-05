namespace FisioKH
{
    partial class IngresoPaciente
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbIngresoPaciente = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIngresosPagados = new System.Windows.Forms.Label();
            this.lblCitas = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTipoIngreso = new System.Windows.Forms.Label();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pbxPacienteIngreso = new System.Windows.Forms.PictureBox();
            this.btnAgregarPaciente = new FisioKH.Boton();
            this.dgvBuscarPaciente = new System.Windows.Forms.DataGridView();
            this.btnBuscarPaciente = new FisioKH.Boton();
            this.txtBuscarPacienteIngreso = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDob = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFisio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMedicoTratante = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCelular = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.lblNombreLbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvExpediente = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).BeginInit();
            this.gbIngresoPaciente.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPacienteIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarPaciente)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpediente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(669, 588);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(34, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(717, 585);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 25);
            this.txtTitle.TabIndex = 1;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(669, 621);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(38, 19);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "Start";
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(717, 618);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 25);
            this.dtStart.TabIndex = 3;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(669, 655);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(32, 19);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "End";
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(717, 652);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 25);
            this.dtEnd.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(960, 656);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1079, 656);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 25);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbIngresoPaciente
            // 
            this.gbIngresoPaciente.Controls.Add(this.groupBox4);
            this.gbIngresoPaciente.Controls.Add(this.pbxPacienteIngreso);
            this.gbIngresoPaciente.Controls.Add(this.btnAgregarPaciente);
            this.gbIngresoPaciente.Controls.Add(this.dgvBuscarPaciente);
            this.gbIngresoPaciente.Controls.Add(this.btnBuscarPaciente);
            this.gbIngresoPaciente.Controls.Add(this.txtBuscarPacienteIngreso);
            this.gbIngresoPaciente.Location = new System.Drawing.Point(1, 1);
            this.gbIngresoPaciente.Name = "gbIngresoPaciente";
            this.gbIngresoPaciente.Size = new System.Drawing.Size(290, 680);
            this.gbIngresoPaciente.TabIndex = 11;
            this.gbIngresoPaciente.TabStop = false;
            this.gbIngresoPaciente.Text = "Paciente";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.lblIngresosPagados);
            this.groupBox4.Controls.Add(this.lblCitas);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblTipoIngreso);
            this.groupBox4.Controls.Add(this.lblIngresos);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(3, 327);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(281, 79);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ingresos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.Location = new System.Drawing.Point(139, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 49;
            this.label9.Text = "Pagados";
            // 
            // lblIngresosPagados
            // 
            this.lblIngresosPagados.AutoSize = true;
            this.lblIngresosPagados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIngresosPagados.ForeColor = System.Drawing.Color.Black;
            this.lblIngresosPagados.Location = new System.Drawing.Point(205, 51);
            this.lblIngresosPagados.Name = "lblIngresosPagados";
            this.lblIngresosPagados.Size = new System.Drawing.Size(17, 19);
            this.lblIngresosPagados.TabIndex = 48;
            this.lblIngresosPagados.Text = "#";
            // 
            // lblCitas
            // 
            this.lblCitas.AutoSize = true;
            this.lblCitas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCitas.ForeColor = System.Drawing.Color.Black;
            this.lblCitas.Location = new System.Drawing.Point(205, 21);
            this.lblCitas.Name = "lblCitas";
            this.lblCitas.Size = new System.Drawing.Size(17, 19);
            this.lblCitas.TabIndex = 47;
            this.lblCitas.Text = "#";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.Location = new System.Drawing.Point(9, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 19);
            this.label10.TabIndex = 46;
            this.label10.Text = "Ingresos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(139, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Citas";
            // 
            // lblTipoIngreso
            // 
            this.lblTipoIngreso.AutoSize = true;
            this.lblTipoIngreso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTipoIngreso.ForeColor = System.Drawing.Color.Black;
            this.lblTipoIngreso.Location = new System.Drawing.Point(100, 21);
            this.lblTipoIngreso.Name = "lblTipoIngreso";
            this.lblTipoIngreso.Size = new System.Drawing.Size(17, 19);
            this.lblTipoIngreso.TabIndex = 45;
            this.lblTipoIngreso.Text = "#";
            // 
            // lblIngresos
            // 
            this.lblIngresos.AutoSize = true;
            this.lblIngresos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIngresos.ForeColor = System.Drawing.Color.Black;
            this.lblIngresos.Location = new System.Drawing.Point(100, 51);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(17, 19);
            this.lblIngresos.TabIndex = 16;
            this.lblIngresos.Text = "#";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 19);
            this.label13.TabIndex = 44;
            this.label13.Text = "Tipo Ingreso";
            // 
            // pbxPacienteIngreso
            // 
            this.pbxPacienteIngreso.ErrorImage = null;
            this.pbxPacienteIngreso.Image = global::FisioKH.Properties.Resources.fisioTerapeuta;
            this.pbxPacienteIngreso.InitialImage = null;
            this.pbxPacienteIngreso.Location = new System.Drawing.Point(2, 411);
            this.pbxPacienteIngreso.MaximumSize = new System.Drawing.Size(282, 217);
            this.pbxPacienteIngreso.Name = "pbxPacienteIngreso";
            this.pbxPacienteIngreso.Size = new System.Drawing.Size(282, 217);
            this.pbxPacienteIngreso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPacienteIngreso.TabIndex = 22;
            this.pbxPacienteIngreso.TabStop = false;
            // 
            // btnAgregarPaciente
            // 
            this.btnAgregarPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAgregarPaciente.FlatAppearance.BorderSize = 2;
            this.btnAgregarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPaciente.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarPaciente.Location = new System.Drawing.Point(33, 633);
            this.btnAgregarPaciente.Margin = new System.Windows.Forms.Padding(10);
            this.btnAgregarPaciente.Name = "btnAgregarPaciente";
            this.btnAgregarPaciente.Size = new System.Drawing.Size(217, 40);
            this.btnAgregarPaciente.TabIndex = 3;
            this.btnAgregarPaciente.Text = "&Agregar Px";
            this.btnAgregarPaciente.UseVisualStyleBackColor = false;
            this.btnAgregarPaciente.Click += new System.EventHandler(this.btnAgregarPaciente_Click);
            // 
            // dgvBuscarPaciente
            // 
            this.dgvBuscarPaciente.AllowUserToAddRows = false;
            this.dgvBuscarPaciente.AllowUserToDeleteRows = false;
            this.dgvBuscarPaciente.AllowUserToOrderColumns = true;
            this.dgvBuscarPaciente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuscarPaciente.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvBuscarPaciente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvBuscarPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarPaciente.Location = new System.Drawing.Point(2, 48);
            this.dgvBuscarPaciente.MultiSelect = false;
            this.dgvBuscarPaciente.Name = "dgvBuscarPaciente";
            this.dgvBuscarPaciente.ReadOnly = true;
            this.dgvBuscarPaciente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBuscarPaciente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuscarPaciente.Size = new System.Drawing.Size(282, 279);
            this.dgvBuscarPaciente.TabIndex = 2;
            this.dgvBuscarPaciente.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuscarPaciente_RowEnter);
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuscarPaciente.FlatAppearance.BorderSize = 2;
            this.btnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarPaciente.Location = new System.Drawing.Point(207, 21);
            this.btnBuscarPaciente.Margin = new System.Windows.Forms.Padding(10);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(77, 26);
            this.btnBuscarPaciente.TabIndex = 1;
            this.btnBuscarPaciente.Text = "&Buscar Px";
            this.btnBuscarPaciente.UseVisualStyleBackColor = false;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // txtBuscarPacienteIngreso
            // 
            this.txtBuscarPacienteIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarPacienteIngreso.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtBuscarPacienteIngreso.Location = new System.Drawing.Point(3, 21);
            this.txtBuscarPacienteIngreso.Name = "txtBuscarPacienteIngreso";
            this.txtBuscarPacienteIngreso.Size = new System.Drawing.Size(203, 25);
            this.txtBuscarPacienteIngreso.TabIndex = 0;
            this.txtBuscarPacienteIngreso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarPacienteIngreso_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDob);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblFisio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblMedicoTratante);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblEdad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblSexo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblCelular);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNombreCompleto);
            this.groupBox1.Controls.Add(this.lblNombreLbl);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.Location = new System.Drawing.Point(297, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 209);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(227, 42);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 19);
            this.lblEmail.TabIndex = 44;
            this.lblEmail.Text = "email";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtObservaciones);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox3.Location = new System.Drawing.Point(9, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(845, 117);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(6, 16);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(833, 90);
            this.txtObservaciones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 43;
            this.label1.Text = "Email";
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDob.ForeColor = System.Drawing.Color.Black;
            this.lblDob.Location = new System.Drawing.Point(90, 42);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(33, 19);
            this.lblDob.TabIndex = 13;
            this.lblDob.Text = "dob";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Nacimiento";
            // 
            // lblFisio
            // 
            this.lblFisio.AutoSize = true;
            this.lblFisio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFisio.ForeColor = System.Drawing.Color.Black;
            this.lblFisio.Location = new System.Drawing.Point(681, 42);
            this.lblFisio.Name = "lblFisio";
            this.lblFisio.Size = new System.Drawing.Size(33, 19);
            this.lblFisio.TabIndex = 11;
            this.lblFisio.Text = "fisio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.Location = new System.Drawing.Point(639, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fisio";
            // 
            // lblMedicoTratante
            // 
            this.lblMedicoTratante.AutoSize = true;
            this.lblMedicoTratante.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMedicoTratante.ForeColor = System.Drawing.Color.Black;
            this.lblMedicoTratante.Location = new System.Drawing.Point(543, 41);
            this.lblMedicoTratante.Name = "lblMedicoTratante";
            this.lblMedicoTratante.Size = new System.Drawing.Size(53, 19);
            this.lblMedicoTratante.TabIndex = 9;
            this.lblMedicoTratante.Text = "medico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(483, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Medico";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEdad.ForeColor = System.Drawing.Color.Black;
            this.lblEdad.Location = new System.Drawing.Point(678, 22);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(39, 19);
            this.lblEdad.TabIndex = 7;
            this.lblEdad.Text = "edad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(639, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Edad";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSexo.ForeColor = System.Drawing.Color.Black;
            this.lblSexo.Location = new System.Drawing.Point(528, 22);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(36, 19);
            this.lblSexo.TabIndex = 5;
            this.lblSexo.Text = "sexo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(495, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sexo";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCelular.ForeColor = System.Drawing.Color.Black;
            this.lblCelular.Location = new System.Drawing.Point(414, 22);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(25, 19);
            this.lblCelular.TabIndex = 3;
            this.lblCelular.Text = "cel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(366, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Celular";
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.Black;
            this.lblNombreCompleto.Location = new System.Drawing.Point(71, 22);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(57, 19);
            this.lblNombreCompleto.TabIndex = 1;
            this.lblNombreCompleto.Text = "nombre";
            // 
            // lblNombreLbl
            // 
            this.lblNombreLbl.AutoSize = true;
            this.lblNombreLbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombreLbl.Location = new System.Drawing.Point(6, 22);
            this.lblNombreLbl.Name = "lblNombreLbl";
            this.lblNombreLbl.Size = new System.Drawing.Size(59, 19);
            this.lblNombreLbl.TabIndex = 0;
            this.lblNombreLbl.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvExpediente);
            this.groupBox2.Location = new System.Drawing.Point(297, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(862, 475);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Expediente";
            // 
            // dgvExpediente
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvExpediente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvExpediente.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvExpediente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpediente.Location = new System.Drawing.Point(6, 18);
            this.dgvExpediente.MultiSelect = false;
            this.dgvExpediente.Name = "dgvExpediente";
            this.dgvExpediente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpediente.Size = new System.Drawing.Size(850, 458);
            this.dgvExpediente.TabIndex = 0;
            // 
            // IngresoPaciente
            // 
            this.ClientSize = new System.Drawing.Size(1164, 681);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbIngresoPaciente);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Name = "IngresoPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingreso Paciente";
            this.Load += new System.EventHandler(this.EventDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).EndInit();
            this.gbIngresoPaciente.ResumeLayout(false);
            this.gbIngresoPaciente.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPacienteIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarPaciente)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpediente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox gbIngresoPaciente;
        private System.Windows.Forms.DataGridView dgvBuscarPaciente;
        private Boton btnBuscarPaciente;
        private System.Windows.Forms.TextBox txtBuscarPacienteIngreso;
        private Boton btnAgregarPaciente;
        private System.Windows.Forms.PictureBox pbxPacienteIngreso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvExpediente;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label lblNombreLbl;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMedicoTratante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFisio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTipoIngreso;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIngresosPagados;
        private System.Windows.Forms.Label lblCitas;
        private System.Windows.Forms.Label label10;
    }
}

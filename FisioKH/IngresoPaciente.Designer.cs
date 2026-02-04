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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbIngresoPaciente = new System.Windows.Forms.GroupBox();
            this.pbxPacienteIngreso = new System.Windows.Forms.PictureBox();
            this.btnAgregarPaciente = new FisioKH.Boton();
            this.dgvBuscarPaciente = new System.Windows.Forms.DataGridView();
            this.btnBuscarPaciente = new FisioKH.Boton();
            this.txtBuscarPacienteIngreso = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvExpediente = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).BeginInit();
            this.gbIngresoPaciente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPacienteIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarPaciente)).BeginInit();
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
            // pbxPacienteIngreso
            // 
            this.pbxPacienteIngreso.ErrorImage = null;
            this.pbxPacienteIngreso.Image = global::FisioKH.Properties.Resources.fisioTerapeuta;
            this.pbxPacienteIngreso.InitialImage = null;
            this.pbxPacienteIngreso.Location = new System.Drawing.Point(2, 418);
            this.pbxPacienteIngreso.Name = "pbxPacienteIngreso";
            this.pbxPacienteIngreso.Size = new System.Drawing.Size(282, 217);
            this.pbxPacienteIngreso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPacienteIngreso.TabIndex = 22;
            this.pbxPacienteIngreso.TabStop = false;
            // 
            // btnAgregarPaciente
            // 
            this.btnAgregarPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAgregarPaciente.FlatAppearance.BorderSize = 2;
            this.btnAgregarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPaciente.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPaciente.Location = new System.Drawing.Point(33, 639);
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
            this.dgvBuscarPaciente.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvBuscarPaciente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvBuscarPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarPaciente.Location = new System.Drawing.Point(2, 48);
            this.dgvBuscarPaciente.MultiSelect = false;
            this.dgvBuscarPaciente.Name = "dgvBuscarPaciente";
            this.dgvBuscarPaciente.ReadOnly = true;
            this.dgvBuscarPaciente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBuscarPaciente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuscarPaciente.Size = new System.Drawing.Size(282, 364);
            this.dgvBuscarPaciente.TabIndex = 2;
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.FlatAppearance.BorderSize = 2;
            this.btnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBuscarPaciente.Location = new System.Drawing.Point(207, 21);
            this.btnBuscarPaciente.Margin = new System.Windows.Forms.Padding(10);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(77, 26);
            this.btnBuscarPaciente.TabIndex = 1;
            this.btnBuscarPaciente.Text = "&Buscar Px";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
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
            this.txtBuscarPacienteIngreso.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Location = new System.Drawing.Point(297, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 87);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvExpediente);
            this.groupBox2.Location = new System.Drawing.Point(297, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(862, 479);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Expediente";
            // 
            // dgvExpediente
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvExpediente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpediente.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvExpediente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpediente.Location = new System.Drawing.Point(6, 18);
            this.dgvExpediente.Name = "dgvExpediente";
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxPacienteIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarPaciente)).EndInit();
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
    }
}


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
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRfc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreFiscal = new System.Windows.Forms.TextBox();
            this.cboEtiquetas = new System.Windows.Forms.ComboBox();
            this.btnGuardarPrecio = new FisioKH.Boton();
            this.btnBuscarPaciente = new FisioKH.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
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
            this.txtPaciente.Size = new System.Drawing.Size(146, 26);
            this.txtPaciente.TabIndex = 12;
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AllowUserToOrderColumns = true;
            this.dgvPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Location = new System.Drawing.Point(3, 57);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.Size = new System.Drawing.Size(997, 332);
            this.dgvPacientes.TabIndex = 10;
            // 
            // txtCelular
            // 
            this.txtCelular.AcceptsReturn = true;
            this.txtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelular.Location = new System.Drawing.Point(155, 25);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(115, 26);
            this.txtCelular.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Celular";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ciudad";
            // 
            // txtCiudad
            // 
            this.txtCiudad.AcceptsReturn = true;
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudad.Location = new System.Drawing.Point(276, 25);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(115, 26);
            this.txtCiudad.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(394, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.AcceptsReturn = true;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(397, 25);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(115, 26);
            this.txtEmail.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(513, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "RFC";
            // 
            // txtRfc
            // 
            this.txtRfc.AcceptsReturn = true;
            this.txtRfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRfc.Location = new System.Drawing.Point(516, 25);
            this.txtRfc.Name = "txtRfc";
            this.txtRfc.Size = new System.Drawing.Size(115, 26);
            this.txtRfc.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(635, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Nombre Fiscal";
            this.label5.Visible = false;
            // 
            // txtNombreFiscal
            // 
            this.txtNombreFiscal.AcceptsReturn = true;
            this.txtNombreFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreFiscal.Location = new System.Drawing.Point(638, 25);
            this.txtNombreFiscal.Name = "txtNombreFiscal";
            this.txtNombreFiscal.Size = new System.Drawing.Size(115, 26);
            this.txtNombreFiscal.TabIndex = 23;
            this.txtNombreFiscal.Visible = false;
            // 
            // cboEtiquetas
            // 
            this.cboEtiquetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtiquetas.FormattingEnabled = true;
            this.cboEtiquetas.Location = new System.Drawing.Point(97, 420);
            this.cboEtiquetas.Name = "cboEtiquetas";
            this.cboEtiquetas.Size = new System.Drawing.Size(121, 21);
            this.cboEtiquetas.TabIndex = 25;
            // 
            // btnGuardarPrecio
            // 
            this.btnGuardarPrecio.FlatAppearance.BorderSize = 2;
            this.btnGuardarPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarPrecio.Location = new System.Drawing.Point(888, 5);
            this.btnGuardarPrecio.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarPrecio.Name = "btnGuardarPrecio";
            this.btnGuardarPrecio.Size = new System.Drawing.Size(112, 46);
            this.btnGuardarPrecio.TabIndex = 13;
            this.btnGuardarPrecio.Text = "Guardar Cambios";
            this.btnGuardarPrecio.UseVisualStyleBackColor = true;
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.FlatAppearance.BorderSize = 2;
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBuscarPaciente.Location = new System.Drawing.Point(759, 7);
            this.btnBuscarPaciente.Margin = new System.Windows.Forms.Padding(10);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(95, 44);
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
            this.Controls.Add(this.cboEtiquetas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombreFiscal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRfc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.lblNombrePaciente);
            this.Controls.Add(this.btnGuardarPrecio);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.dgvPacientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pacientes";
            this.Text = "Pacientes";
            this.Load += new System.EventHandler(this.Pacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombrePaciente;
        private Boton btnGuardarPrecio;
        private System.Windows.Forms.TextBox txtPaciente;
        private Boton btnBuscarPaciente;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRfc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreFiscal;
        private System.Windows.Forms.ComboBox cboEtiquetas;
    }
}
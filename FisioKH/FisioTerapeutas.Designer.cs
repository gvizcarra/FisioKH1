
namespace FisioKH
{
    partial class FisioTerapeutas
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
            this.txtFisioTerapeuta = new FisioKH.ValidatedNumericTextBox();
            this.lblNombreMP = new System.Windows.Forms.Label();
            this.dgvFisioTerapeutas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnZoomOut = new FisioKH.Boton();
            this.btnZoomIn = new FisioKH.Boton();
            this.btnGuardarFoto = new FisioKH.Boton();
            this.txtId = new FisioKH.ValidatedNumericTextBox();
            this.btnAbrirCamara = new FisioKH.Boton();
            this.pbxFotoFisio = new System.Windows.Forms.PictureBox();
            this.chkValora = new System.Windows.Forms.CheckBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtNombreCorto = new FisioKH.ValidatedNumericTextBox();
            this.txtNombre = new FisioKH.ValidatedNumericTextBox();
            this.btnGuardarFT = new FisioKH.Boton();
            this.btnBuscarFT = new FisioKH.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFisioTerapeutas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoFisio)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFisioTerapeuta
            // 
            this.txtFisioTerapeuta.AcceptsReturn = true;
            this.txtFisioTerapeuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFisioTerapeuta.Location = new System.Drawing.Point(71, 16);
            this.txtFisioTerapeuta.Name = "txtFisioTerapeuta";
            this.txtFisioTerapeuta.Size = new System.Drawing.Size(146, 26);
            this.txtFisioTerapeuta.TabIndex = 8;
            // 
            // lblNombreMP
            // 
            this.lblNombreMP.AutoSize = true;
            this.lblNombreMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMP.Location = new System.Drawing.Point(15, 22);
            this.lblNombreMP.Name = "lblNombreMP";
            this.lblNombreMP.Size = new System.Drawing.Size(47, 20);
            this.lblNombreMP.TabIndex = 7;
            this.lblNombreMP.Text = "Fisio";
            // 
            // dgvFisioTerapeutas
            // 
            this.dgvFisioTerapeutas.AllowUserToAddRows = false;
            this.dgvFisioTerapeutas.AllowUserToDeleteRows = false;
            this.dgvFisioTerapeutas.AllowUserToOrderColumns = true;
            this.dgvFisioTerapeutas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFisioTerapeutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFisioTerapeutas.Location = new System.Drawing.Point(4, 55);
            this.dgvFisioTerapeutas.MultiSelect = false;
            this.dgvFisioTerapeutas.Name = "dgvFisioTerapeutas";
            this.dgvFisioTerapeutas.ReadOnly = true;
            this.dgvFisioTerapeutas.Size = new System.Drawing.Size(500, 439);
            this.dgvFisioTerapeutas.TabIndex = 5;
            this.dgvFisioTerapeutas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFisioTerapeutas_CellContentClick_1);
            this.dgvFisioTerapeutas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFisioTerapeutas_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Celular";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Activo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nick";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Valora";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(27, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "Foto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnZoomOut);
            this.groupBox1.Controls.Add(this.btnZoomIn);
            this.groupBox1.Controls.Add(this.btnGuardarFoto);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.btnAbrirCamara);
            this.groupBox1.Controls.Add(this.pbxFotoFisio);
            this.groupBox1.Controls.Add(this.chkValora);
            this.groupBox1.Controls.Add(this.chkActivo);
            this.groupBox1.Controls.Add(this.txtCelular);
            this.groupBox1.Controls.Add(this.txtNombreCorto);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.btnGuardarFT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(535, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 432);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.FlatAppearance.BorderSize = 2;
            this.btnZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnZoomOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnZoomOut.Location = new System.Drawing.Point(14, 277);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(10);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(64, 30);
            this.btnZoomOut.TabIndex = 26;
            this.btnZoomOut.Text = "--";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.FlatAppearance.BorderSize = 2;
            this.btnZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnZoomIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnZoomIn.Location = new System.Drawing.Point(13, 243);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(10);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(65, 30);
            this.btnZoomIn.TabIndex = 25;
            this.btnZoomIn.Text = "++";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnGuardarFoto
            // 
            this.btnGuardarFoto.Enabled = false;
            this.btnGuardarFoto.FlatAppearance.BorderSize = 2;
            this.btnGuardarFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.btnGuardarFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarFoto.Location = new System.Drawing.Point(14, 327);
            this.btnGuardarFoto.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarFoto.Name = "btnGuardarFoto";
            this.btnGuardarFoto.Size = new System.Drawing.Size(65, 39);
            this.btnGuardarFoto.TabIndex = 24;
            this.btnGuardarFoto.Text = "C&aptura";
            this.btnGuardarFoto.UseVisualStyleBackColor = true;
            this.btnGuardarFoto.Click += new System.EventHandler(this.btnAGuardarFoto_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(252, 93);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(54, 25);
            this.txtId.TabIndex = 23;
            this.txtId.Visible = false;
            // 
            // btnAbrirCamara
            // 
            this.btnAbrirCamara.FlatAppearance.BorderSize = 2;
            this.btnAbrirCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnAbrirCamara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnAbrirCamara.Location = new System.Drawing.Point(14, 195);
            this.btnAbrirCamara.Margin = new System.Windows.Forms.Padding(10);
            this.btnAbrirCamara.Name = "btnAbrirCamara";
            this.btnAbrirCamara.Size = new System.Drawing.Size(65, 30);
            this.btnAbrirCamara.TabIndex = 22;
            this.btnAbrirCamara.Text = "&Cam";
            this.btnAbrirCamara.UseVisualStyleBackColor = true;
            this.btnAbrirCamara.Click += new System.EventHandler(this.btnAbrirCamara_Click);
            // 
            // pbxFotoFisio
            // 
            this.pbxFotoFisio.ErrorImage = null;
            this.pbxFotoFisio.Image = global::FisioKH.Properties.Resources.fisioTerapeuta;
            this.pbxFotoFisio.InitialImage = null;
            this.pbxFotoFisio.Location = new System.Drawing.Point(112, 166);
            this.pbxFotoFisio.Name = "pbxFotoFisio";
            this.pbxFotoFisio.Size = new System.Drawing.Size(199, 200);
            this.pbxFotoFisio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFotoFisio.TabIndex = 21;
            this.pbxFotoFisio.TabStop = false;
            // 
            // chkValora
            // 
            this.chkValora.AutoSize = true;
            this.chkValora.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkValora.Location = new System.Drawing.Point(241, 124);
            this.chkValora.Name = "chkValora";
            this.chkValora.Size = new System.Drawing.Size(44, 24);
            this.chkValora.TabIndex = 20;
            this.chkValora.Text = "Si";
            this.chkValora.UseVisualStyleBackColor = true;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkActivo.Location = new System.Drawing.Point(121, 126);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(44, 24);
            this.chkActivo.TabIndex = 19;
            this.chkActivo.Text = "Si";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(112, 90);
            this.txtCelular.Mask = "(999) 000-00-00";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(120, 25);
            this.txtCelular.TabIndex = 18;
            this.txtCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Location = new System.Drawing.Point(112, 58);
            this.txtNombreCorto.MaxLength = 10;
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(210, 25);
            this.txtNombreCorto.TabIndex = 17;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(112, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(210, 25);
            this.txtNombre.TabIndex = 16;
            // 
            // btnGuardarFT
            // 
            this.btnGuardarFT.FlatAppearance.BorderSize = 2;
            this.btnGuardarFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarFT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarFT.Location = new System.Drawing.Point(127, 385);
            this.btnGuardarFT.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarFT.Name = "btnGuardarFT";
            this.btnGuardarFT.Size = new System.Drawing.Size(105, 34);
            this.btnGuardarFT.TabIndex = 9;
            this.btnGuardarFT.Text = "&Guardar Cambios";
            this.btnGuardarFT.UseVisualStyleBackColor = true;
            this.btnGuardarFT.Click += new System.EventHandler(this.btnGuardarFT_Click);
            // 
            // btnBuscarFT
            // 
            this.btnBuscarFT.FlatAppearance.BorderSize = 2;
            this.btnBuscarFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarFT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBuscarFT.Location = new System.Drawing.Point(230, 2);
            this.btnBuscarFT.Margin = new System.Windows.Forms.Padding(10);
            this.btnBuscarFT.Name = "btnBuscarFT";
            this.btnBuscarFT.Size = new System.Drawing.Size(95, 40);
            this.btnBuscarFT.TabIndex = 6;
            this.btnBuscarFT.Text = "Buscar";
            this.btnBuscarFT.UseVisualStyleBackColor = true;
            this.btnBuscarFT.Click += new System.EventHandler(this.btnBuscarFT_Click);
            // 
            // FisioTerapeutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 501);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtFisioTerapeuta);
            this.Controls.Add(this.lblNombreMP);
            this.Controls.Add(this.btnBuscarFT);
            this.Controls.Add(this.dgvFisioTerapeutas);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FisioTerapeutas";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.Text = "FisioTerapeutas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FisioTerapeutas_FormClosing);
            this.Load += new System.EventHandler(this.FisioTerapeutas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFisioTerapeutas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoFisio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Boton btnGuardarFT;
        private FisioKH.ValidatedNumericTextBox txtFisioTerapeuta;
        private System.Windows.Forms.Label lblNombreMP;
        private Boton btnBuscarFT;
        private System.Windows.Forms.DataGridView dgvFisioTerapeutas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkValora;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private FisioKH.ValidatedNumericTextBox txtNombreCorto;
        private FisioKH.ValidatedNumericTextBox txtNombre;
        private System.Windows.Forms.PictureBox pbxFotoFisio;
        private Boton btnAbrirCamara;
        private FisioKH.ValidatedNumericTextBox txtId;
        private Boton btnGuardarFoto;
        private Boton btnZoomOut;
        private Boton btnZoomIn;
    }
}
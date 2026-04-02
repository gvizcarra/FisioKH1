
namespace FisioKH
{
    partial class pagoVisita
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
            this.label20 = new System.Windows.Forms.Label();
            this.txtNombrePaciente = new System.Windows.Forms.TextBox();
            this.dtpPagoFecha = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.txtCantidadPagada = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtIdPago = new System.Windows.Forms.TextBox();
            this.btnGuardarPago = new FisioKH.Boton();
            this.btnBorrarPago = new FisioKH.Boton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.NumericUpDown();
            this.boton1 = new FisioKH.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadPagada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label20.Location = new System.Drawing.Point(64, 89);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 19);
            this.label20.TabIndex = 69;
            this.label20.Text = "Paciente";
            // 
            // txtNombrePaciente
            // 
            this.txtNombrePaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombrePaciente.Location = new System.Drawing.Point(130, 83);
            this.txtNombrePaciente.Name = "txtNombrePaciente";
            this.txtNombrePaciente.ReadOnly = true;
            this.txtNombrePaciente.Size = new System.Drawing.Size(238, 25);
            this.txtNombrePaciente.TabIndex = 68;
            // 
            // dtpPagoFecha
            // 
            this.dtpPagoFecha.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpPagoFecha.Enabled = false;
            this.dtpPagoFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPagoFecha.Location = new System.Drawing.Point(130, 118);
            this.dtpPagoFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpPagoFecha.Name = "dtpPagoFecha";
            this.dtpPagoFecha.RightToLeftLayout = true;
            this.dtpPagoFecha.ShowUpDown = true;
            this.dtpPagoFecha.Size = new System.Drawing.Size(196, 25);
            this.dtpPagoFecha.TabIndex = 71;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(69, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 19);
            this.label12.TabIndex = 70;
            this.label12.Text = "Fecha";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Location = new System.Drawing.Point(130, 151);
            this.cboMetodoPago.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(200, 25);
            this.cboMetodoPago.TabIndex = 77;
            this.cboMetodoPago.SelectionChangeCommitted += new System.EventHandler(this.cboMetodoPago_SelectionChangeCommitted);
            // 
            // txtCantidadPagada
            // 
            this.txtCantidadPagada.Location = new System.Drawing.Point(130, 226);
            this.txtCantidadPagada.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtCantidadPagada.Name = "txtCantidadPagada";
            this.txtCantidadPagada.Size = new System.Drawing.Size(74, 25);
            this.txtCantidadPagada.TabIndex = 78;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(69, 232);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 19);
            this.label21.TabIndex = 79;
            this.label21.Text = "Pago $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 80;
            this.label1.Text = "Metodo de Pago";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(69, 41);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 19);
            this.label23.TabIndex = 82;
            this.label23.Text = "id Pago";
            // 
            // txtIdPago
            // 
            this.txtIdPago.Location = new System.Drawing.Point(130, 38);
            this.txtIdPago.Name = "txtIdPago";
            this.txtIdPago.ReadOnly = true;
            this.txtIdPago.Size = new System.Drawing.Size(50, 25);
            this.txtIdPago.TabIndex = 81;
            // 
            // btnGuardarPago
            // 
            this.btnGuardarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGuardarPago.FlatAppearance.BorderSize = 2;
            this.btnGuardarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarPago.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarPago.Location = new System.Drawing.Point(68, 264);
            this.btnGuardarPago.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarPago.Name = "btnGuardarPago";
            this.btnGuardarPago.Size = new System.Drawing.Size(143, 37);
            this.btnGuardarPago.TabIndex = 83;
            this.btnGuardarPago.Text = "Actualizar &Pago";
            this.btnGuardarPago.UseVisualStyleBackColor = false;
            this.btnGuardarPago.Click += new System.EventHandler(this.btnGuardarPago_Click);
            // 
            // btnBorrarPago
            // 
            this.btnBorrarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBorrarPago.FlatAppearance.BorderSize = 2;
            this.btnBorrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnBorrarPago.ForeColor = System.Drawing.Color.Black;
            this.btnBorrarPago.Location = new System.Drawing.Point(292, 33);
            this.btnBorrarPago.Margin = new System.Windows.Forms.Padding(10);
            this.btnBorrarPago.Name = "btnBorrarPago";
            this.btnBorrarPago.Size = new System.Drawing.Size(143, 37);
            this.btnBorrarPago.TabIndex = 84;
            this.btnBorrarPago.Text = "&Borrar Pago";
            this.btnBorrarPago.UseVisualStyleBackColor = false;
            this.btnBorrarPago.Visible = false;
            this.btnBorrarPago.Click += new System.EventHandler(this.btnBorrarPago_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 86;
            this.label2.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(130, 192);
            this.txtPrecio.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(74, 25);
            this.txtPrecio.TabIndex = 85;
            // 
            // boton1
            // 
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.boton1.FlatAppearance.BorderSize = 2;
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.boton1.ForeColor = System.Drawing.Color.Black;
            this.boton1.Location = new System.Drawing.Point(292, 264);
            this.boton1.Margin = new System.Windows.Forms.Padding(10);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(143, 37);
            this.boton1.TabIndex = 87;
            this.boton1.Text = "&Cerrar Ventana";
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // pagoVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 321);
            this.Controls.Add(this.boton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.btnBorrarPago);
            this.Controls.Add(this.btnGuardarPago);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtIdPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cboMetodoPago);
            this.Controls.Add(this.txtCantidadPagada);
            this.Controls.Add(this.dtpPagoFecha);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtNombrePaciente);
            this.Name = "pagoVisita";
            this.Text = "pagoVisita";
            this.Load += new System.EventHandler(this.pagoVisita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaseErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadPagada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNombrePaciente;
        private System.Windows.Forms.DateTimePicker dtpPagoFecha;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.NumericUpDown txtCantidadPagada;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtIdPago;
        private Boton btnGuardarPago;
        private Boton btnBorrarPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtPrecio;
        private Boton boton1;
    }
}
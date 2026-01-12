
namespace FisioKH
{
    partial class MetodosPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetodosPago));
            this.dgvMetodoPago = new System.Windows.Forms.DataGridView();
            this.lblNombreMP = new System.Windows.Forms.Label();
            this.txtMetodoPago = new System.Windows.Forms.TextBox();
            this.btnGuardarMP = new FisioKH.Boton();
            this.btnBuscarMP = new FisioKH.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodoPago)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMetodoPago
            // 
            this.dgvMetodoPago.AllowUserToDeleteRows = false;
            this.dgvMetodoPago.AllowUserToOrderColumns = true;
            this.dgvMetodoPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMetodoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetodoPago.Location = new System.Drawing.Point(12, 67);
            this.dgvMetodoPago.Name = "dgvMetodoPago";
            this.dgvMetodoPago.Size = new System.Drawing.Size(468, 224);
            this.dgvMetodoPago.TabIndex = 0;
            // 
            // lblNombreMP
            // 
            this.lblNombreMP.AutoSize = true;
            this.lblNombreMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMP.Location = new System.Drawing.Point(23, 34);
            this.lblNombreMP.Name = "lblNombreMP";
            this.lblNombreMP.Size = new System.Drawing.Size(50, 20);
            this.lblNombreMP.TabIndex = 2;
            this.lblNombreMP.Text = "Pago";
            // 
            // txtMetodoPago
            // 
            this.txtMetodoPago.AcceptsReturn = true;
            this.txtMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetodoPago.Location = new System.Drawing.Point(79, 28);
            this.txtMetodoPago.Name = "txtMetodoPago";
            this.txtMetodoPago.Size = new System.Drawing.Size(146, 26);
            this.txtMetodoPago.TabIndex = 3;
            // 
            // btnGuardarMP
            // 
            this.btnGuardarMP.FlatAppearance.BorderSize = 2;
            this.btnGuardarMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarMP.Location = new System.Drawing.Point(12, 299);
            this.btnGuardarMP.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarMP.Name = "btnGuardarMP";
            this.btnGuardarMP.Size = new System.Drawing.Size(95, 30);
            this.btnGuardarMP.TabIndex = 4;
            this.btnGuardarMP.Text = "Guardar Cambios";
            this.btnGuardarMP.UseVisualStyleBackColor = true;
            this.btnGuardarMP.Click += new System.EventHandler(this.btnGuardarMP_Click);
            // 
            // btnBuscarMP
            // 
            this.btnBuscarMP.FlatAppearance.BorderSize = 2;
            this.btnBuscarMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBuscarMP.Location = new System.Drawing.Point(238, 14);
            this.btnBuscarMP.Margin = new System.Windows.Forms.Padding(10);
            this.btnBuscarMP.Name = "btnBuscarMP";
            this.btnBuscarMP.Size = new System.Drawing.Size(95, 40);
            this.btnBuscarMP.TabIndex = 1;
            this.btnBuscarMP.Text = "Buscar";
            this.btnBuscarMP.UseVisualStyleBackColor = true;
            this.btnBuscarMP.Click += new System.EventHandler(this.btnBuscarMP_Click);
            // 
            // MetodosPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 358);
            this.Controls.Add(this.btnGuardarMP);
            this.Controls.Add(this.txtMetodoPago);
            this.Controls.Add(this.lblNombreMP);
            this.Controls.Add(this.btnBuscarMP);
            this.Controls.Add(this.dgvMetodoPago);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MetodosPago";
            this.Text = "MetodosPago";
            this.Load += new System.EventHandler(this.MetodosPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodoPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMetodoPago;
        private Boton btnBuscarMP;
        private System.Windows.Forms.Label lblNombreMP;
        private System.Windows.Forms.TextBox txtMetodoPago;
        private Boton btnGuardarMP;
    }
}
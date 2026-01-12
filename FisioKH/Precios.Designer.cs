
namespace FisioKH
{
    partial class Precios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Precios));
            this.btnGuardarPrecio = new FisioKH.Boton();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnBuscarPrecio = new FisioKH.Boton();
            this.dgvPrecio = new System.Windows.Forms.DataGridView();
            this.lblNombreMP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardarPrecio
            // 
            this.btnGuardarPrecio.FlatAppearance.BorderSize = 2;
            this.btnGuardarPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarPrecio.Location = new System.Drawing.Point(11, 401);
            this.btnGuardarPrecio.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarPrecio.Name = "btnGuardarPrecio";
            this.btnGuardarPrecio.Size = new System.Drawing.Size(95, 30);
            this.btnGuardarPrecio.TabIndex = 8;
            this.btnGuardarPrecio.Text = "Guardar Cambios";
            this.btnGuardarPrecio.UseVisualStyleBackColor = true;
            this.btnGuardarPrecio.Click += new System.EventHandler(this.btnGuardarPrecio_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.AcceptsReturn = true;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(78, 18);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(146, 26);
            this.txtPrecio.TabIndex = 7;
            // 
            // btnBuscarPrecio
            // 
            this.btnBuscarPrecio.FlatAppearance.BorderSize = 2;
            this.btnBuscarPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBuscarPrecio.Location = new System.Drawing.Point(234, 6);
            this.btnBuscarPrecio.Margin = new System.Windows.Forms.Padding(10);
            this.btnBuscarPrecio.Name = "btnBuscarPrecio";
            this.btnBuscarPrecio.Size = new System.Drawing.Size(95, 40);
            this.btnBuscarPrecio.TabIndex = 6;
            this.btnBuscarPrecio.Text = "Buscar";
            this.btnBuscarPrecio.UseVisualStyleBackColor = true;
            this.btnBuscarPrecio.Click += new System.EventHandler(this.btnBuscarPrecio_Click);
            // 
            // dgvPrecio
            // 
            this.dgvPrecio.AllowUserToDeleteRows = false;
            this.dgvPrecio.AllowUserToOrderColumns = true;
            this.dgvPrecio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrecio.Location = new System.Drawing.Point(11, 51);
            this.dgvPrecio.Name = "dgvPrecio";
            this.dgvPrecio.Size = new System.Drawing.Size(479, 337);
            this.dgvPrecio.TabIndex = 5;
            // 
            // lblNombreMP
            // 
            this.lblNombreMP.AutoSize = true;
            this.lblNombreMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMP.Location = new System.Drawing.Point(12, 21);
            this.lblNombreMP.Name = "lblNombreMP";
            this.lblNombreMP.Size = new System.Drawing.Size(59, 20);
            this.lblNombreMP.TabIndex = 9;
            this.lblNombreMP.Text = "Precio";
            // 
            // Precios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 437);
            this.Controls.Add(this.lblNombreMP);
            this.Controls.Add(this.btnGuardarPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.btnBuscarPrecio);
            this.Controls.Add(this.dgvPrecio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Precios";
            this.Text = "Precios";
            this.Load += new System.EventHandler(this.Precios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Boton btnGuardarPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private Boton btnBuscarPrecio;
        private System.Windows.Forms.DataGridView dgvPrecio;
        private System.Windows.Forms.Label lblNombreMP;
    }
}

namespace FisioKH
{
    partial class Tratamientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tratamientos));
            this.btnGuardarMP = new FisioKH.Boton();
            this.txtTipoTratamiento = new System.Windows.Forms.TextBox();
            this.lblNombreMP = new System.Windows.Forms.Label();
            this.btnBuscarTT = new FisioKH.Boton();
            this.dgvTipoTratamiento = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoTratamiento)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardarMP
            // 
            this.btnGuardarMP.FlatAppearance.BorderSize = 2;
            this.btnGuardarMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarMP.Location = new System.Drawing.Point(15, 296);
            this.btnGuardarMP.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarMP.Name = "btnGuardarMP";
            this.btnGuardarMP.Size = new System.Drawing.Size(95, 30);
            this.btnGuardarMP.TabIndex = 9;
            this.btnGuardarMP.Text = "Guardar Cambios";
            this.btnGuardarMP.UseVisualStyleBackColor = true;
            this.btnGuardarMP.Click += new System.EventHandler(this.btnGuardarMP_Click);
            // 
            // txtTipoTratamiento
            // 
            this.txtTipoTratamiento.AcceptsReturn = true;
            this.txtTipoTratamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoTratamiento.Location = new System.Drawing.Point(135, 25);
            this.txtTipoTratamiento.Name = "txtTipoTratamiento";
            this.txtTipoTratamiento.Size = new System.Drawing.Size(146, 26);
            this.txtTipoTratamiento.TabIndex = 8;
            // 
            // lblNombreMP
            // 
            this.lblNombreMP.AutoSize = true;
            this.lblNombreMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMP.Location = new System.Drawing.Point(26, 31);
            this.lblNombreMP.Name = "lblNombreMP";
            this.lblNombreMP.Size = new System.Drawing.Size(105, 20);
            this.lblNombreMP.TabIndex = 7;
            this.lblNombreMP.Text = "Tratamiento";
            // 
            // btnBuscarTT
            // 
            this.btnBuscarTT.FlatAppearance.BorderSize = 2;
            this.btnBuscarTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarTT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBuscarTT.Location = new System.Drawing.Point(294, 11);
            this.btnBuscarTT.Margin = new System.Windows.Forms.Padding(10);
            this.btnBuscarTT.Name = "btnBuscarTT";
            this.btnBuscarTT.Size = new System.Drawing.Size(95, 40);
            this.btnBuscarTT.TabIndex = 6;
            this.btnBuscarTT.Text = "Buscar";
            this.btnBuscarTT.UseVisualStyleBackColor = true;
            this.btnBuscarTT.Click += new System.EventHandler(this.btnBuscarTT_Click);
            // 
            // dgvTipoTratamiento
            // 
            this.dgvTipoTratamiento.AllowUserToDeleteRows = false;
            this.dgvTipoTratamiento.AllowUserToOrderColumns = true;
            this.dgvTipoTratamiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTipoTratamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoTratamiento.Location = new System.Drawing.Point(15, 64);
            this.dgvTipoTratamiento.Name = "dgvTipoTratamiento";
            this.dgvTipoTratamiento.Size = new System.Drawing.Size(532, 224);
            this.dgvTipoTratamiento.TabIndex = 5;
            // 
            // Tratamientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 337);
            this.Controls.Add(this.btnGuardarMP);
            this.Controls.Add(this.txtTipoTratamiento);
            this.Controls.Add(this.lblNombreMP);
            this.Controls.Add(this.btnBuscarTT);
            this.Controls.Add(this.dgvTipoTratamiento);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Tratamientos";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.Text = "Tratamientos";
            this.Load += new System.EventHandler(this.Tratamientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoTratamiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Boton btnGuardarMP;
        private System.Windows.Forms.TextBox txtTipoTratamiento;
        private System.Windows.Forms.Label lblNombreMP;
        private Boton btnBuscarTT;
        private System.Windows.Forms.DataGridView dgvTipoTratamiento;
    }
}

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
            this.btnGuardarMP = new FisioKH.Boton();
            this.txtFisioTerapeuta = new System.Windows.Forms.TextBox();
            this.lblNombreMP = new System.Windows.Forms.Label();
            this.btnBuscarFT = new FisioKH.Boton();
            this.dgvFisioTerapeutas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFisioTerapeutas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardarMP
            // 
            this.btnGuardarMP.FlatAppearance.BorderSize = 2;
            this.btnGuardarMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarMP.Location = new System.Drawing.Point(4, 319);
            this.btnGuardarMP.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardarMP.Name = "btnGuardarMP";
            this.btnGuardarMP.Size = new System.Drawing.Size(95, 34);
            this.btnGuardarMP.TabIndex = 9;
            this.btnGuardarMP.Text = "Guardar Cambios";
            this.btnGuardarMP.UseVisualStyleBackColor = true;
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
            // dgvFisioTerapeutas
            // 
            this.dgvFisioTerapeutas.AllowUserToDeleteRows = false;
            this.dgvFisioTerapeutas.AllowUserToOrderColumns = true;
            this.dgvFisioTerapeutas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFisioTerapeutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFisioTerapeutas.Location = new System.Drawing.Point(4, 55);
            this.dgvFisioTerapeutas.Name = "dgvFisioTerapeutas";
            this.dgvFisioTerapeutas.Size = new System.Drawing.Size(699, 260);
            this.dgvFisioTerapeutas.TabIndex = 5;
            // 
            // FisioTerapeutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 358);
            this.Controls.Add(this.btnGuardarMP);
            this.Controls.Add(this.txtFisioTerapeuta);
            this.Controls.Add(this.lblNombreMP);
            this.Controls.Add(this.btnBuscarFT);
            this.Controls.Add(this.dgvFisioTerapeutas);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FisioTerapeutas";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.Text = "FisioTerapeutas";
            this.Load += new System.EventHandler(this.FisioTerapeutas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFisioTerapeutas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Boton btnGuardarMP;
        private System.Windows.Forms.TextBox txtFisioTerapeuta;
        private System.Windows.Forms.Label lblNombreMP;
        private Boton btnBuscarFT;
        private System.Windows.Forms.DataGridView dgvFisioTerapeutas;
    }
}

namespace FisioKH
{
    partial class pasarinfo
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
            this.btnDetenerCamara = new FisioKH.Boton();
            this.cboCamaras = new System.Windows.Forms.ComboBox();
            this.btnAbrirCamara = new FisioKH.Boton();
            this.trkZoomFT = new System.Windows.Forms.TrackBar();
            this.pbxFotoPaciente = new System.Windows.Forms.PictureBox();
            this.btnGuardarFoto = new FisioKH.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoomFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPaciente)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetenerCamara
            // 
            this.btnDetenerCamara.Enabled = false;
            this.btnDetenerCamara.FlatAppearance.BorderSize = 2;
            this.btnDetenerCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnDetenerCamara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnDetenerCamara.Location = new System.Drawing.Point(631, 51);
            this.btnDetenerCamara.Margin = new System.Windows.Forms.Padding(10);
            this.btnDetenerCamara.Name = "btnDetenerCamara";
            this.btnDetenerCamara.Size = new System.Drawing.Size(68, 30);
            this.btnDetenerCamara.TabIndex = 43;
            this.btnDetenerCamara.Text = "&Detener";
            this.btnDetenerCamara.UseVisualStyleBackColor = true;
            // 
            // cboCamaras
            // 
            this.cboCamaras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCamaras.FormattingEnabled = true;
            this.cboCamaras.Location = new System.Drawing.Point(455, 54);
            this.cboCamaras.Name = "cboCamaras";
            this.cboCamaras.Size = new System.Drawing.Size(173, 21);
            this.cboCamaras.TabIndex = 41;
            // 
            // btnAbrirCamara
            // 
            this.btnAbrirCamara.Enabled = false;
            this.btnAbrirCamara.FlatAppearance.BorderSize = 2;
            this.btnAbrirCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnAbrirCamara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnAbrirCamara.Location = new System.Drawing.Point(345, 51);
            this.btnAbrirCamara.Margin = new System.Windows.Forms.Padding(10);
            this.btnAbrirCamara.Name = "btnAbrirCamara";
            this.btnAbrirCamara.Size = new System.Drawing.Size(94, 30);
            this.btnAbrirCamara.TabIndex = 40;
            this.btnAbrirCamara.Text = "&Abrir Camara";
            this.btnAbrirCamara.UseVisualStyleBackColor = true;
            // 
            // trkZoomFT
            // 
            this.trkZoomFT.Location = new System.Drawing.Point(345, 49);
            this.trkZoomFT.Maximum = 50;
            this.trkZoomFT.Name = "trkZoomFT";
            this.trkZoomFT.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkZoomFT.Size = new System.Drawing.Size(45, 210);
            this.trkZoomFT.TabIndex = 42;
            // 
            // pbxFotoPaciente
            // 
            this.pbxFotoPaciente.ErrorImage = null;
            this.pbxFotoPaciente.Image = global::FisioKH.Properties.Resources.patient;
            this.pbxFotoPaciente.InitialImage = null;
            this.pbxFotoPaciente.Location = new System.Drawing.Point(446, 112);
            this.pbxFotoPaciente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbxFotoPaciente.Name = "pbxFotoPaciente";
            this.pbxFotoPaciente.Size = new System.Drawing.Size(255, 217);
            this.pbxFotoPaciente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFotoPaciente.TabIndex = 38;
            this.pbxFotoPaciente.TabStop = false;
            // 
            // btnGuardarFoto
            // 
            this.btnGuardarFoto.Enabled = false;
            this.btnGuardarFoto.FlatAppearance.BorderSize = 2;
            this.btnGuardarFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.btnGuardarFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnGuardarFoto.Location = new System.Drawing.Point(765, 418);
            this.btnGuardarFoto.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.btnGuardarFoto.Name = "btnGuardarFoto";
            this.btnGuardarFoto.Size = new System.Drawing.Size(99, 46);
            this.btnGuardarFoto.TabIndex = 39;
            this.btnGuardarFoto.Text = "&Captura Foto";
            this.btnGuardarFoto.UseVisualStyleBackColor = true;
            // 
            // pasarinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 512);
            this.Controls.Add(this.btnDetenerCamara);
            this.Controls.Add(this.cboCamaras);
            this.Controls.Add(this.btnAbrirCamara);
            this.Controls.Add(this.trkZoomFT);
            this.Controls.Add(this.pbxFotoPaciente);
            this.Controls.Add(this.btnGuardarFoto);
            this.Name = "pasarinfo";
            this.Text = "pasarinfo";
            ((System.ComponentModel.ISupportInitialize)(this.trkZoomFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPaciente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Boton btnDetenerCamara;
        private System.Windows.Forms.ComboBox cboCamaras;
        private Boton btnAbrirCamara;
        private System.Windows.Forms.TrackBar trkZoomFT;
        private System.Windows.Forms.PictureBox pbxFotoPaciente;
        private Boton btnGuardarFoto;
    }
}
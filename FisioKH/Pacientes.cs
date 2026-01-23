using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video.DirectShow;

namespace FisioKH
{
    public partial class Pacientes : BaseForm
    {
        private DataTable dt;
        private WebCamHelper wch;
        public Pacientes()
        {
            InitializeComponent();
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
            LoadCamaras();


            DBHelper db = new DBHelper();
            DataSet ds = db.ObtenerDatos("SELECT id,nombreCorto  FROM fisioTerapeutas","Fisios");
            this.cboEtiqueta.DataSource = EtiquetasPacienteHelper.GetBindableList();

            this.cboEtiqueta.DisplayMember = "Text"; // what user sees
            this.cboEtiqueta.ValueMember = "Key";
            this.cboEtiqueta.SelectedValue = "pm";

            wch = new WebCamHelper(pbxFotoPaciente);
            ObtenDatos(this.txtPaciente.Text, this.txtCelular.Text, this.txtEmail.Text);


            this.cboFisioTerapeuta.DataSource = ds.Tables["Fisios"];
            this.cboFisioTerapeuta.ValueMember = "id";
            this.cboFisioTerapeuta.DisplayMember = "nombreCorto";
            

        }

        private void ObtenDatos(string nombre = null, 
                                 string celular = null, 
                                 string email = null)
        {
            DataSet dsmp = new DataSet();
            string dsname = "Pacientes";

            var parameters = new Dictionary<string, object>
            { 
                { "@nombreCompleto", nombre },
                { "@celular", celular },
                { "@email", email },
                //{ "@fechaNacimiento", fechaNacimiento }
                
            };
            DBHelper sdb = new DBHelper();
            dsmp = sdb.ObtenerDatos("usp_ObtenerPacientes", dsname, parameters);

            dgvPacientes.AutoGenerateColumns = false;
            dgvPacientes.Columns.Clear();
            dgvPacientes.AutoResizeColumns();


            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "Id",
                Name = "Id"
            });

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "nombre"
            });

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Etiqueta",
                HeaderText = "Etiqueta",
                Name = "Etiqueta"
            });

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaNacimiento",
                HeaderText = "FechaNacimiento",
                Name = "FechaNacimiento"
            });

              dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedicoTratante",
                HeaderText = "MedicoTratante",
                Name = "MedicoTratante"
              });


            dt = dsmp.Tables[dsname];

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "";
            btnEdit.Text = "Editar";
            btnEdit.UseColumnTextForButtonValue = true;

            dgvPacientes.Columns.Insert(0, btnEdit);

            this.dgvPacientes.DataSource = dt;


        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            ObtenDatos(this.txtPaciente.Text, this.txtCelular.Text, this.txtEmail.Text);
        }

        private void dgvPacientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //if (e.RowIndex < 0) return;

            //if (e.ColumnIndex == 0)
            //    return;

            //if (sender is DataGridView dgv && e.Value != null)
            //{
            //    // List of columns to format
            //    string[] bitColumns = { "activo", "valora", "citaCancelableMismoDia" };

            //    if (bitColumns.Contains(dgv.Columns[e.ColumnIndex].Name))
            //    {
            //        e.Value = Convert.ToBoolean(e.Value) ? "Sí" : "No";
            //        e.FormattingApplied = true;
            //    }
            //}

        }

        private void LoadCamaras()
        {
            FilterInfoCollection videoDevices;


            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            cboCamaras.Items.Clear();

            foreach (FilterInfo device in videoDevices)
            {
                cboCamaras.Items.Add(device.Name);
            }

            if (cboCamaras.Items.Count > 0)
            {
                // cboCamaras.SelectedIndex = 0;
                btnAbrirCamara.Enabled = true;
                btnDetenerCamara.Enabled = true;
            }

        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                DataRow row = dt.Rows[e.RowIndex];

                //Id Nombre  Celular Ciudad  Sexo Edad    MedicoTratante Fisio   Etiqueta Email   Usuario FechaRegistro   Rfc DFiscal NFiscal FechaNacimiento observaciones

                this.txtId.Text = row["Id"].ToString();
                this.txtNombreCompleto.Text = row["Nombre"].ToString();
                this.txtCelularAlta.Text = row["Celular"].ToString();
                this.txtCiudad.Text = row["Ciudad"].ToString();
                this.txtRfcFiscal.Text = row["Rfc"].ToString();
                //this.txtId.Text = row["Sexo"].ToString();
                this.txtEdad.Text = row["Edad"].ToString();
                this.txtMedicoTratante.Text = row["MedicoTratante"].ToString();
                this.cboEtiqueta.SelectedValue = row["Etiqueta"].ToString();
                this.txtEmailAlta.Text = row["Email"].ToString();
                this.txtDomicilioFiscal.Text = row["DFiscal"].ToString();
                this.txtNombreFiscal.Text = row["NFiscal"].ToString();
                this.dtpFechaNacimiento.Text = row["FechaNacimiento"].ToString();
                this.txtObservaciones.Text = row["observaciones"].ToString();

                foreach (RadioButton rb in gbSexo.Controls.OfType<RadioButton>())
                {
                    rb.Checked = (rb.Text == row["Sexo"].ToString());                    
                }


                DBHelper db = new DBHelper();

                Bitmap foto = db.GetImageFromField(row, "Foto");
                db.Dispose();


                this.pbxFotoPaciente.Image = foto ?? FisioKH.Properties.Resources.patient;

                //MessageBox.Show(row[1].ToString());

            }
        }

        private void btnAbrirCamara_Click(object sender, EventArgs e)
        {
            //wch.StartCamera();
            //btnGuardarFoto.Enabled = true;
            //btnZoomIn.Enabled = true;
            //btnZoomOut.Enabled = true;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            wch.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            wch.ZoomOut();
        }

        private void btnGuardarFoto_Click(object sender, EventArgs e)
        {
            if (wch.videoSource != null && wch.videoSource.IsRunning)
            {
                wch.videoSource.SignalToStop();
                wch.videoSource.WaitForStop();
            }

            wch.currentFrame?.Dispose();
        }

        private void btnGuardarFT_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                // Focus first invalid field
                var failedControl = GetFirstInvalidControl(this);
                if (failedControl != null)
                    failedControl.Focus();

                MessageBox.Show("Capturar la informacion Marcada con Icono Rojo.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            int id = 0, qtyi = 0;

            int.TryParse(this.txtId.Text, out id);

            DBHelper sdb = new DBHelper();

            var parameters = new Dictionary<string, object>
            {
                { "@nombreCompleto", null },
                { "@celular", null },
                { "@ciudad", null },
                { "@sexo", null },
                { "@fechaNacimiento", null },
                { "@email", null },
                { "@idUsuario", Program.UsuarioLogeado.Id },
                { "@rfc", null },
                { "@domicilioFiscal", null },
                { "@nombreFiscal", null },
                { "@medicoTratante", null },
                { "@idFisioTerapeuta", null },
                { "@claveEtiqueta", null },
                { "@observaciones", null },
                { "@foto", null }
            };

             




            parameters["@nombreCompleto"] = this.txtNombreCompleto.Text;
            parameters["@celular"] = this.txtCelularAlta.Text;
            parameters["@ciudad"] = this.txtCiudad.Text;
            parameters["@sexo"] = this.gbSexo.Controls.OfType<RadioButton>().First(r => r.Checked).Text.ToString();
            parameters["@fechaNacimiento"] = this.dtpFechaNacimiento.Text.ToString();
            parameters["@email"] = this.txtEmailAlta.Text;
            parameters["@rfc"] = this.txtRfcFiscal.Text;
            parameters["@domicilioFiscal"] = this.txtDomicilioFiscal.Text;
            parameters["@nombreFiscal"] = this.txtNombreFiscal.Text;
            parameters["@medicoTratante"] = this.txtMedicoTratante.Text;
            parameters["@idFisioTerapeuta"] = Convert.ToInt64(cboFisioTerapeuta.SelectedValue);
            parameters["@claveEtiqueta"] = this.cboEtiqueta.SelectedValue;
            parameters["@observaciones"] = this.txtObservaciones.Text;
          
            parameters["@foto"] = (object)wch.ImageToByteArray(this.pbxFotoPaciente) ?? DBNull.Value;

            if (id > 0)
            {
                parameters.Add("@id", id);
                qtyi = sdb.EjecutarNonQuery("usp_UpdatePaciente", parameters);
            }
            else
            { qtyi = sdb.EjecutarNonQuery("usp_InsertPaciente", parameters); }

            if (qtyi > 0)
            { MessageBox.Show("Registro Insertado"); }


            limpiarFormulario();

            ObtenDatos(this.txtPaciente.Text, this.txtCelular.Text, this.txtEmail.Text);

        }

        private void limpiarFormulario()
        {
            this.txtId.Text = "";
            this.txtNombreCompleto.Text = "";
            this.txtCelularAlta.Text = "";
            this.txtCiudad.Text = "";
            this.txtRfcFiscal.Text = "";
            this.txtEdad.Text = "";
            this.txtMedicoTratante.Text = "";
            this.cboEtiqueta.ResetText();
            this.txtEmailAlta.Text = "";
            this.txtDomicilioFiscal.Text = "";
            this.txtNombreFiscal.Text = "";
            this.dtpFechaNacimiento.Text = "";
            this.txtObservaciones.Text = "";
            this.txtApellidoPaterno.Text = "";
            this.txtApellidoMaterno.Text = "";


            this.pbxFotoPaciente.Image = FisioKH.Properties.Resources.patient;


        }

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void cboEtiqueta_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            var combo = (ComboBox)sender;
            var item = (EtiquetaPaciente)combo.Items[e.Index];

            // Convert string → Color
            Color bgColor;
            try
            {
                bgColor = ColorTranslator.FromHtml(item.Color);
            }
            catch
            {
                bgColor = Color.FromName(item.Color);
                if (!bgColor.IsKnownColor)
                    bgColor = Color.Black;
            }

            // Selection background
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                bgColor = ControlPaint.Light(bgColor);

            using (var brush = new SolidBrush(bgColor))
                e.Graphics.FillRectangle(brush, e.Bounds);

            // Text color (auto contrast)
            Color textColor = bgColor.GetBrightness() < 0.5f ? Color.White : Color.Black;

            TextRenderer.DrawText(
                e.Graphics,
                item.Text,
                e.Font,
                e.Bounds,
                textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            e.DrawFocusRectangle();
        }

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAbrirCamara_Click_1(object sender, EventArgs e)
        {
            ActivarCamara();
        }

        private void btnDetenerCamara_Click(object sender, EventArgs e)
        {
            wch?.StopCamera();
            btnAbrirCamara.Enabled = true;
        }

        private void trkZoomFT_Scroll(object sender, EventArgs e)
        {
            wch.SetZoomFromTrackBar(trkZoomFT.Value);
        }


        private void ActivarCamara()
        {
            btnAbrirCamara.Enabled = false;
            wch?.StopCamera();

            int numCarama = cboCamaras.SelectedIndex;
            if (numCarama < 0)
            { return; }

            wch.StartCamera(numCarama);
            btnGuardarFoto.Enabled = true;

        }

        private void cboCamaras_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarCamara();
        }
    }
}

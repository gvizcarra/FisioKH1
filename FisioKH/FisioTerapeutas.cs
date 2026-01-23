using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;


using System.Windows.Forms;
using Accord.Video.DirectShow;

namespace FisioKH
{
    public partial class FisioTerapeutas : BaseForm
    {
        private DataTable dt;
        private WebCamHelper wch;

        public FisioTerapeutas()
        {
            InitializeComponent();
            
        }

        private void FisioTerapeutas_Load(object sender, EventArgs e)
        {

            LoadCamaras();
            wch = new WebCamHelper(pbxFotoFisio);

            ObtenFisioTerapeutas(this.txtFisioTerapeuta.Text);
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

        private void ObtenFisioTerapeutas(string nombre = null)
        {
            DataSet dsmp = new DataSet();
            string dsname = "fisio";

            var parameters = new Dictionary<string, object>
            {
                { "@nombre", nombre }
            };

            DBHelper sdb = new DBHelper();
            dsmp = sdb.ObtenerDatos("usp_ObtenerFisioTerapeutas", dsname, parameters);

            dgvFisioTerapeutas.AutoGenerateColumns = false;
            dgvFisioTerapeutas.Columns.Clear();
            dgvFisioTerapeutas.AutoResizeColumns();


            dgvFisioTerapeutas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "Id",
                Name = "Id"
            });

            dgvFisioTerapeutas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Nombre",
                Name = "nombre"
            });

            dgvFisioTerapeutas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "activo",
                HeaderText = "Activo",
                Name = "activo"
            });

            dgvFisioTerapeutas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "haceValoracion",
                HeaderText = "Valora",
                Name = "valora"
            });


            dt = dsmp.Tables[dsname];

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "";
            btnEdit.Text = "Editar";
            btnEdit.UseColumnTextForButtonValue = true;

            dgvFisioTerapeutas.Columns.Insert(0, btnEdit);


            this.dgvFisioTerapeutas.DataSource = dt;


        }


        private void dgvFisioTerapeutas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
                return;

            if (sender is DataGridView dgv && e.Value != null)
            {
                // List of columns to format
                string[] bitColumns = { "activo", "valora" };

                if (bitColumns.Contains(dgv.Columns[e.ColumnIndex].Name))
                {
                    e.Value = Convert.ToBoolean(e.Value) ? "Sí" : "No";
                    e.FormattingApplied = true;
                }
            }
        }


        private void btnBuscarFT_Click(object sender, EventArgs e)
        {
            ObtenFisioTerapeutas(this.txtFisioTerapeuta.Text);
        }

        private void btnGuardarFT_Click(object sender, EventArgs e)
        {
            int id = 0, qtyi =0;

            int.TryParse(this.txtId.Text, out id);

            DBHelper sdb = new DBHelper();

            var parameters = new Dictionary<string, object>
            {

                { "@nombre", null },
                { "@celular", null },
                { "@nombreCorto", null },
                { "@activo", null },
                { "@idUsuario", Program.UsuarioLogeado.Id },
                { "@haceValoracion", null },
                { "@foto", null },
            };

 
            
            parameters["@nombre"] = this.txtNombre.Text;
            parameters["@celular"] = this.txtCelular.Text;
            parameters["@nombreCorto"] = this.txtNombreCorto.Text;
            parameters["@activo"] = this.chkActivo.Checked;
            parameters["@haceValoracion"] = this.chkValora.Checked;
            parameters["@foto"] = (object)wch.ImageToByteArray(this.pbxFotoFisio) ?? DBNull.Value;

            if (id > 0)
            { 
                parameters.Add("@id", id);
                  qtyi = sdb.EjecutarNonQuery("usp_UpdateFisioterapeuta", parameters);
            
            }
            else
            {   qtyi = sdb.EjecutarNonQuery("usp_InsertFisioterapeuta", parameters); }

            if (qtyi > 0)
            { MessageBox.Show("Registro Insertado"); }

            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtNombreCorto.Text = "";
            this.txtCelular.Text = "";
            this.txtFisioTerapeuta.Text = "";
            this.chkValora.Checked = false;

            limpiarFormulario();
            ObtenFisioTerapeutas(this.txtFisioTerapeuta.Text);
        }

        private void limpiarFormulario()
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtNombreCorto.Text = "";
            this.txtCelular.Text = "";
            this.txtFisioTerapeuta.Text = "";
            this.chkValora.Checked = false;
        }

        private void dgvFisioTerapeutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvFisioTerapeutas.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                DataRow row = dt.Rows[e.RowIndex];

                this.txtId.Text = row["Id"].ToString();
                this.txtNombre.Text = row["nombre"].ToString();
                this.txtNombreCorto.Text = row["nombreCorto"].ToString();
                this.txtCelular.Text = row["celular"].ToString();
                this.chkActivo.Checked = (bool)row["activo"];
                this.chkValora.Checked = (bool)row["haceValoracion"];

                DBHelper db = new DBHelper();

                Bitmap foto = db.GetImageFromField(row, "Foto");
                db.Dispose();
                

                this.pbxFotoFisio.Image = foto ?? FisioKH.Properties.Resources.fisioTerapeuta;
 

            }
        }


       

       


        

        private void btnAbrirCamara_Click(object sender, EventArgs e)
        {
            ActivarCamara();
        }

        private void btnAGuardarFoto_Click(object sender, EventArgs e)
        {
            if (wch.videoSource != null && wch.videoSource.IsRunning)
            {
                wch.videoSource.SignalToStop();
                wch.videoSource.WaitForStop();
            }

            wch.currentFrame?.Dispose();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            wch.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            wch.ZoomOut();
        }


       

        

        private void FisioTerapeutas_FormClosing(object sender, FormClosingEventArgs e)
        {

            wch?.StopCamera();
        }

        private void dgvFisioTerapeutas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFisioTerapeutas.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                DataRow row = dt.Rows[e.RowIndex];

                this.txtId.Text = row["Id"].ToString();
                this.txtNombre.Text = row["nombre"].ToString();
                this.txtNombreCorto.Text = row["nombreCorto"].ToString();
                this.txtCelular.Text = row["celular"].ToString();
                this.chkActivo.Checked = (bool)row["activo"];
                this.chkValora.Checked = (bool)row["haceValoracion"];

                DBHelper db = new DBHelper();

                Bitmap foto = db.GetImageFromField(row, "Foto");
                db.Dispose();

                this.pbxFotoFisio.Image = foto ?? FisioKH.Properties.Resources.fisioTerapeuta;






            }
        }

        private void cboCamaras_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarCamara();
        }

        private void btnDetenerCamara_Click(object sender, EventArgs e)
        {
            wch?.StopCamera();
            btnAbrirCamara.Enabled = true;
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

        private void trkZoomFT_Scroll(object sender, EventArgs e)
        {
            wch.SetZoomFromTrackBar(trkZoomFT.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using Accord.Video;
using Accord.Video.DirectShow;


using System.Windows.Forms;

namespace FisioKH
{
    public partial class FisioTerapeutas : BaseForm
    {
        private DataTable dt;

        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;
        private Bitmap currentFrame;

        private float zoomFactor = 1.0f; // 1 = normal, >1 = zoom in, <1 = zoom out
        private const float zoomStep = 0.1f; // step for each zoom click



        public FisioTerapeutas()
        {
            InitializeComponent();
            //StartCamera();
        }

        private void FisioTerapeutas_Load(object sender, EventArgs e)
        {
            ObtenFisioTerapeutas(this.txtFisioTerapeuta.Text);
        }

        private void ObtenFisioTerapeutas(string nombre = null)
        {
            DataSet dsmp = new DataSet();
            string dsname = "fisio";

            var parameters = new Dictionary<string, object>
            {
                { "@nombre", nombre }
            };

            SqlDatabase sdb = new SqlDatabase();
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

            SqlDatabase sdb = new SqlDatabase();

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
            parameters["@foto"] = (object)ImageToByteArray(this.pbxFotoFisio) ?? DBNull.Value;

            if (id > 0)
            { 
                parameters.Add("@id", id);
                  qtyi = sdb.EjecutarNonQuery("usp_UpdateFisioterapeuta", parameters);
            
            }
            else
            {   qtyi = sdb.EjecutarNonQuery("usp_InsertFisioterapeuta", parameters); }

            if (qtyi > 0)
            { MessageBox.Show("Registro Insertado"); }

         
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

                Bitmap foto = GetImageFromField(row, "Foto");

                this.pbxFotoFisio.Image = foto ?? FisioKH.Properties.Resources.fisioTerapeuta;






            }
        }


        private Bitmap GetImageFromField(DataRow row, string columnName)
        {
            if (row == null)
                return null;

            // Use Field<byte?> to safely handle null/DBNull
            byte[] fotoBytes = row.Field<byte[]>(columnName);

            if (fotoBytes == null || fotoBytes.Length == 0)
                return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(fotoBytes))
                {
                    return new Bitmap(ms);
                }
            }
            catch
            {
                return null; // corrupted image
            }
        }

        private void StartCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No webcam detected!");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);

            // Set a reasonable resolution (e.g., 640x480)
            videoSource.VideoResolution = videoSource.VideoCapabilities
                .FirstOrDefault(vc => vc.FrameSize.Width == 640 && vc.FrameSize.Height == 480)
                ?? videoSource.VideoCapabilities[0];

            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
        }


        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            currentFrame?.Dispose();
            currentFrame = (Bitmap)eventArgs.Frame.Clone();

            // Apply zoom before showing
            Bitmap zoomedFrame = ApplyZoom(currentFrame, zoomFactor);

            this.pbxFotoFisio.Image?.Dispose();
            this.pbxFotoFisio.Image = zoomedFrame;
        }

        private void btnAbrirCamara_Click(object sender, EventArgs e)
        {
            this.StartCamera();
        }

        private void btnAGuardarFoto_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            currentFrame?.Dispose();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            zoomFactor += zoomStep;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            zoomFactor = Math.Max(1.0f, zoomFactor - zoomStep);
        }


        private Bitmap ApplyZoom(Bitmap original, float zoom)
        {
            if (zoom == 1.0f) return (Bitmap)original.Clone();

            int newWidth = (int)(original.Width / zoom);
            int newHeight = (int)(original.Height / zoom);

            int x = (original.Width - newWidth) / 2;
            int y = (original.Height - newHeight) / 2;

            Rectangle cropRect = new Rectangle(x, y, newWidth, newHeight);
            Bitmap cropped = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(cropped))
            {
                g.DrawImage(original, new Rectangle(0, 0, newWidth, newHeight), cropRect, GraphicsUnit.Pixel);
            }

            // Resize back to original size to fit PictureBox
            Bitmap resized = new Bitmap(cropped, original.Size);
            cropped.Dispose();
            return resized;
        }

        private byte[] ImageToByteArray(PictureBox picBox)
        {
            if (picBox.Image == null) return null;

            using (var ms = new System.IO.MemoryStream())
            {
                // Save image to memory stream as JPEG (or PNG)
                picBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }



        }
    }
}

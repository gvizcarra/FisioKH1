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
    public partial class Usuarios : BaseForm
    {

        Dictionary<int, string> NivelUsuario = new Dictionary<int, string>()
        {
            { 1, "Admin" },
            { 2, "Asistente" }
        };

        private DataTable dt;
        private WebCamHelper wch;

        public Usuarios()
        {
            InitializeComponent();
            
        }

     


       

        private void ObtenUsuarios(string nombre = null)
        {
            DataSet dsmp = new DataSet();
            string dsname = "fisio";

            var parameters = new Dictionary<string, object>
            {
                { "@nombre", nombre }
            };

            DBHelper sdb = new DBHelper();
            dsmp = sdb.ObtenerDatos("usp_ObtenerUsuarios", dsname, parameters);

            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.AutoResizeColumns();


            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "Id",
                Name = "Id"
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Nombre",
                Name = "nombre"
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "activo",
                HeaderText = "Activo",
                Name = "activo"
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nivel",
                HeaderText = "Nivel",
                Name = "nivel"
            });


            dt = dsmp.Tables[dsname];

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "";
            btnEdit.Text = "Editar";
            btnEdit.UseColumnTextForButtonValue = true;

            dgvUsuarios.Columns.Insert(0, btnEdit);


            this.dgvUsuarios.DataSource = dt;


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
            ObtenUsuarios(this.txtUsuario.Text);
        }

        private void btnGuardarFT_Click(object sender, EventArgs e)
        {
            //int id = 0, qtyi =0;

            //int.TryParse(this.txtId.Text, out id);

            //DBHelper sdb = new DBHelper();

            //var parameters = new Dictionary<string, object>
            //{

            //    { "@nombre", null },
            //    { "@celular", null },
            //    { "@nombreCorto", null },
            //    { "@activo", null },
            //    { "@idUsuario", Program.UsuarioLogeado.Id },
            //    { "@haceValoracion", null },
            //    { "@foto", null },
            //};

 
            
            //parameters["@nombre"] = this.txtNombre.Text;
            //parameters["@celular"] = this.txtCelular.Text;
            //parameters["@nombreCorto"] = this.txtPassword.Text;
            //parameters["@activo"] = this.chkActivo.Checked;
            //parameters["@haceValoracion"] = this.chkValora.Checked;
            //parameters["@foto"] = (object)wch.ImageToByteArray(this.pbxFotoFisio) ?? DBNull.Value;

            //if (id > 0)
            //{ 
            //    parameters.Add("@id", id);
            //      qtyi = sdb.EjecutarNonQuery("usp_UpdateFisioterapeuta", parameters);
            
            //}
            //else
            //{   qtyi = sdb.EjecutarNonQuery("usp_InsertFisioterapeuta", parameters); }

            //if (qtyi > 0)
            //{ MessageBox.Show("Registro Insertado"); }

            //this.txtId.Text = "";
            //this.txtNombre.Text = "";
            //this.txtPassword.Text = "";
            //this.txtCelular.Text = "";
            //this.txtFisioTerapeuta.Text = "";
            //this.chkValora.Checked = false;

            //limpiarFormulario();
            //ObtenFisioTerapeutas(this.txtFisioTerapeuta.Text);
        }

        private void limpiarFormulario()
        {
            //this.txtId.Text = "";
            //this.txtNombre.Text = "";
            //this.txtPassword.Text = "";
            //this.txtCelular.Text = "";
            //this.txtFisioTerapeuta.Text = "";
            //this.chkValora.Checked = false;
        }

        private void dgvFisioTerapeutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                DataRow row = dt.Rows[e.RowIndex];

                //this.txtId.Text = row["Id"].ToString();
                //this.txtNombre.Text = row["nombre"].ToString();
                //this.txtPassword.Text = row["nombreCorto"].ToString();
                //this.txtCelular.Text = row["celular"].ToString();
                //this.chkActivo.Checked = (bool)row["activo"];
                //this.chkValora.Checked = (bool)row["haceValoracion"];

                //DBHelper db = new DBHelper();

                //Bitmap foto = db.GetImageFromField(row, "Foto");
                //db.Dispose();
                

                //this.pbxFotoFisio.Image = foto ?? FisioKH.Properties.Resources.fisioTerapeuta;
 

            }
        }


       

       


        
 

        


       
 

        private void dgvFisioTerapeutas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                DataRow row = dt.Rows[e.RowIndex];

                this.txtId.Text = row["id"].ToString();
                this.txtNombre.Text = row["nombre"].ToString();
                this.txtPin.Text = row["pin"].ToString();
                this.cboNivel.SelectedValue = (int)row["nivel"];
                this.chkActivo.Checked = (bool)row["activo"];

            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            ObtenUsuarios(this.txtUsuario.Text);
            this.cboNivel.DataSource = new BindingSource(NivelUsuario, null);
            cboNivel.DisplayMember = "Value"; // What user sees
            cboNivel.ValueMember = "Key";
        }

        private void btnGuardarUsu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.cboNivel.SelectedValue.ToString());
        }
    }
}

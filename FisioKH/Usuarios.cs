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
 

        private void limpiarFormulario()
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtPassword.Text = "";
            this.txtPasswordC.Text = "";
            this.txtPin.Text = "";
            this.txtPassword.IsRequired = true;
            this.txtPasswordC.IsRequired = true;
            
            
            this.chkActivo.Checked = false;
        }

        


       

       


         
 

        private void dgvUsuarios_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                DataRow row = dt.Rows[e.RowIndex];

                this.txtId.Text = row["id"].ToString();
                this.txtNombre.Text = row["nombre"].ToString();
                this.txtPin.Text = row["pin"].ToString();
                this.cboNivel.SelectedValue = (int)row["nivel"];
                this.chkActivo.Checked = (bool)row["activo"];
                this.txtPassword.IsRequired = false;
                this.txtPasswordC.IsRequired = false;

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
            if (txtId.Text == "")
            {
                if (this.txtPassword.Text != this.txtPasswordC.Text)
                {
                    MessageBox.Show("No Coinciden las Contraseñas");
                    this.txtPassword.Focus();
                    return;
                }
            }

            int id = 0, qtyi = 0;

            int.TryParse(this.txtId.Text, out id);

            DBHelper sdb = new DBHelper();

            var parameters = new Dictionary<string, object>
            {

                { "@nombre", null },
                { "@pin", null },
                { "@nivel", null },                
                { "@password", null },               
                { "@activo", null },
                { "@idUsuario", Program.UsuarioLogeado.Id },
                
            };



            parameters["@nombre"] = this.txtNombre.Text;
            parameters["@pin"] = this.txtPin.Text;
            parameters["@nivel"] = (int)this.cboNivel.SelectedValue;
            parameters["@password"] = string.IsNullOrWhiteSpace(txtPassword.Text) ? (object)DBNull.Value : txtPassword.Text.Trim();
            parameters["@activo"] = this.chkActivo.Checked;

            if (id > 0)
            {
                parameters.Add("@id", id);
                qtyi = sdb.EjecutarNonQuery("usp_UpdateUsuarios", parameters);

            }
            else
            { qtyi = sdb.EjecutarNonQuery("usp_InsertUsuarios", parameters); }

            if (qtyi > 0)
            { MessageBox.Show("Registro Guardado"); }



            limpiarFormulario();
            ObtenUsuarios(this.txtUsuario.Text);
        }
    }
}

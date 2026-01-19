using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioKH
{
    public partial class Pacientes : Form
    {
        private DataTable dt;
        public Pacientes()
        {
            InitializeComponent();
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
            this.cboEtiquetas.DataSource = EtiquetasPacienteHelper.GetBindableList();

            this.cboEtiquetas.DisplayMember = "Text"; // what user sees
            this.cboEtiquetas.ValueMember = "Key";
            this.cboEtiquetas.SelectedValue = "pm";

            ObtenDatos(this.txtPaciente.Text, this.txtCelular.Text, this.txtEmail.Text);
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
             
                dt = dsmp.Tables[dsname];

            this.dgvPacientes.DataSource = dt;
             
                this.dgvPacientes.Columns[0].ReadOnly = true;
                this.dgvPacientes.Columns[7].ReadOnly = true;
                this.dgvPacientes.Columns[10].ReadOnly = true;
                this.dgvPacientes.Columns[11].ReadOnly = true;
             

        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            ObtenDatos(this.txtPaciente.Text, this.txtCelular.Text, this.txtEmail.Text);
        }
    }
}

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
           ObtenDatos(this.txtPaciente.Text, this.txtCelular.Text, this.txtCiudad.Text,
               this.txtRfc.Text,  this.txtEmail.Text);
        }

        private void ObtenDatos(string nombre = null, 
                                 string celular = null, 
                                 string ciudad = null,
                                  string rfc = null, 
                                 string email = null)
        {
            DataSet dsmp = new DataSet();
            string dsname = "Pacientes";

            var parameters = new Dictionary<string, object>
            { 
                { "@nombreCompleto", nombre },
                { "@celular", celular },
                { "@ciudad", ciudad },
                { "@rfc", rfc },
                { "@email", email },
                //{ "@fechaNacimiento", fechaNacimiento }
                
            };

            SqlDatabase sdb = new SqlDatabase();
            dsmp = sdb.ObtenerDatos("usp_ObtenerPacientes", dsname, parameters);
             
                dt = dsmp.Tables[dsname];

            this.dgvPacientes.DataSource = dt;
             
                this.dgvPacientes.Columns[0].ReadOnly = true;
                this.dgvPacientes.Columns[7].ReadOnly = true;
                this.dgvPacientes.Columns[9].ReadOnly = true;
                this.dgvPacientes.Columns[10].ReadOnly = true;
             

        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            ObtenDatos(this.txtPaciente.Text, this.txtCelular.Text, this.txtCiudad.Text,
               this.txtRfc.Text, this.txtEmail.Text);
        }
    }
}

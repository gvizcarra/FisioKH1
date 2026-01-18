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
    public partial class Tratamientos : BaseForm
    {
        private DataTable dtTipoTratamiento;
        public Tratamientos()
        {
            InitializeComponent();
        }

        private void Tratamientos_Load(object sender, EventArgs e)
        {
            ObtenTipoTratamiento(this.txtTipoTratamiento.Text);
        }

        private void ObtenTipoTratamiento(string nombre = null)
        {
            DataSet dsmp = new DataSet();
            string dsname = "tipoTratamiento";

            var parameters = new Dictionary<string, object>
            {
                { "@nombre", nombre }
            };

            DBHelper sdb = new DBHelper();
            dsmp = sdb.ObtenerDatos("usp_ObtenerTipoTratamiento", dsname, parameters);
            dtTipoTratamiento = dsmp.Tables[dsname];

            this.dgvTipoTratamiento.DataSource = dtTipoTratamiento;
            this.dgvTipoTratamiento.Columns[0].ReadOnly = true;
            this.dgvTipoTratamiento.Columns[3].ReadOnly = true;
            this.dgvTipoTratamiento.Columns[4].ReadOnly = true;

        }


       

        private void btnBuscarTT_Click(object sender, EventArgs e)
        {
            ObtenTipoTratamiento(this.txtTipoTratamiento.Text);

        }

        private void btnGuardarMP_Click(object sender, EventArgs e)
        {
            DBHelper sdb = new DBHelper();

            var parameters = new Dictionary<string, object>
            {

                { "@nombre", null },
                { "@idUsuario", Program.UsuarioLogeado.Id },
                { "@descripcion", null },
            };


            DataTable changedRows = dtTipoTratamiento.GetChanges();
            foreach (DataRow row in changedRows.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        parameters["@nombre"] = row[1];
                        parameters["@descripcion"] = row[2];
                        int qtyi = sdb.EjecutarNonQuery("usp_InsertTipoTratamiento", parameters);

                        if (qtyi > 0)
                        { MessageBox.Show("Registro Insertado"); }
                        break;
                    case DataRowState.Modified:
                        parameters["@id"] = row[0];
                        parameters["@nombre"] = row[1];
                        parameters["@descripcion"] = row[2];
                        int qtyu = sdb.EjecutarNonQuery("usp_UpdateTipoTratamiento", parameters);

                        if (qtyu > 0)
                        { MessageBox.Show("Registro Actualizado"); }

                        break;
                    case DataRowState.Deleted:
                        MessageBox.Show("del");

                        break;
                }
            }
        }
    }
}

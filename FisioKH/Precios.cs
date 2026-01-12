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
    public partial class Precios : Form
    {
        private DataTable dt;

        public Precios()
        {
            InitializeComponent();
        }

        private void Precios_Load(object sender, EventArgs e)
        {
            ObtenDatos(this.txtPrecio.Text);
        }

        private void ObtenDatos(string nombre = null)
        {
            DataSet dsmp = new DataSet();
            string dsname = "precios";

            var parameters = new Dictionary<string, object>
            {
                { "@nombre", nombre }
            };

            SqlDatabase sdb = new SqlDatabase();
            dsmp = sdb.ObtenerDatos("usp_ObtenerPrecios", dsname, parameters);
            dt = dsmp.Tables[dsname];

            this.dgvPrecio.DataSource = dt;
            this.dgvPrecio.Columns[0].ReadOnly = true;
            this.dgvPrecio.Columns[4].ReadOnly = true;
            this.dgvPrecio.Columns[5].ReadOnly = true;

        }

        private void btnGuardarPrecio_Click(object sender, EventArgs e)
        {
            SqlDatabase sdb = new SqlDatabase();

            var parameters = new Dictionary<string, object>
            {

                { "@nombre", null },
                { "@precio", null },
                { "@activo", null },
                { "@idUsuario", Program.UsuarioLogeado.Id },
 
            };


            DataTable changedRows = dt.GetChanges();
            foreach (DataRow row in changedRows.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        parameters["@nombre"] = row[1];
                        parameters["@precio"] = row[2];
                        parameters["@activo"] = row[3];
                        int qtyi = sdb.EjecutarNonQuery("usp_InsertPrecios", parameters);

                        if (qtyi > 0)
                        { MessageBox.Show("Registro Insertado"); }
                        break;
                    case DataRowState.Modified:
                        parameters["@id"] = row[0];
                        parameters["@nombre"] = row[1];
                        parameters["@precio"] = row[2];
                        parameters["@activo"] = row[3];
                        int qtyu = sdb.EjecutarNonQuery("usp_UpdatePrecios", parameters);

                        if (qtyu > 0)
                        { MessageBox.Show("Registro Actualizado"); }

                        break;
                    case DataRowState.Deleted:
                        MessageBox.Show("del");

                        break;
                }
            }

        }

        private void btnBuscarPrecio_Click(object sender, EventArgs e)
        {
            ObtenDatos(this.txtPrecio.Text);
        }
    }
}

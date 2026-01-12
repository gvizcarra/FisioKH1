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
    public partial class MetodosPago : Form
    {
        private DataTable dtMetodoPago;  

        public MetodosPago()
        {
            InitializeComponent();
        }

        private void MetodosPago_Load(object sender, EventArgs e)
        {
            

            ObtenMetodoPago(this.txtMetodoPago.Text);
        }

        private void ObtenMetodoPago(string nombre = null)
        {
            DataSet dsmp = new DataSet();
            string dsname = "metodoPago";

            var parameters = new Dictionary<string, object>
            {
                { "@nombre", nombre }           
            };

            SqlDatabase sdb = new SqlDatabase();
            dsmp = sdb.ObtenerDatos("usp_ObtenerMetodoPago", dsname, parameters);
            dtMetodoPago = dsmp.Tables[dsname];

            this.dgvMetodoPago.DataSource = dtMetodoPago;
            this.dgvMetodoPago.Columns[0].ReadOnly = true;
            this.dgvMetodoPago.Columns[3].ReadOnly = true;
            this.dgvMetodoPago.Columns[4].ReadOnly = true;
 
        }

        private void btnBuscarMP_Click(object sender, EventArgs e)
        {
            ObtenMetodoPago(this.txtMetodoPago.Text);
        }

        private void btnGuardarMP_Click(object sender, EventArgs e)
        {
            SqlDatabase sdb = new SqlDatabase();

            var parameters = new Dictionary<string, object>
            {
 
                { "@nombre", null },
                { "@idUsuario", Program.UsuarioLogeado.Id },
                { "@ocupaReferenciaPago", null },
            };


            DataTable changedRows = dtMetodoPago.GetChanges();
            foreach (DataRow row in changedRows.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        parameters["@nombre"] = row[1];
                        parameters["@ocupaReferenciaPago"] = row[2];
                        int qtyi =  sdb.EjecutarNonQuery("usp_InsertMetodoPago",parameters);

                        if (qtyi > 0)
                        { MessageBox.Show("Registro Insertado"); }
                        break;
                    case DataRowState.Modified:
                        parameters["@id"] = row[0];
                        parameters["@nombre"] = row[1];
                        parameters["@ocupaReferenciaPago"] = row[2];
                        int qtyu = sdb.EjecutarNonQuery("usp_UpdateMetodoPago", parameters);
                        
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

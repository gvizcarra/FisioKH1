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
    public partial class FisioTerapeutas : BaseForm
    {
        private DataTable dt;
        public FisioTerapeutas()
        {
            InitializeComponent();
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
            dt = dsmp.Tables[dsname];

            this.dgvFisioTerapeutas.DataSource = dt;
            this.dgvFisioTerapeutas.Columns[0].ReadOnly = true;
            this.dgvFisioTerapeutas.Columns[3].ReadOnly = true;
            this.dgvFisioTerapeutas.Columns[4].ReadOnly = true;

        }

        private void btnBuscarFT_Click(object sender, EventArgs e)
        {
            ObtenFisioTerapeutas(this.txtFisioTerapeuta.Text);
        }

        private void btnGuardarFT_Click(object sender, EventArgs e)
        {
            SqlDatabase sdb = new SqlDatabase();

            var parameters = new Dictionary<string, object>
            {

                { "@nombre", null },
                { "@celular", null },
                { "@nombreCorto", null },
                { "@activo", null },
                { "@idUsuario", Program.UsuarioLogeado.Id },
                { "@haceValoracion", null },
            };


            DataTable changedRows = dt.GetChanges();
            foreach (DataRow row in changedRows.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        parameters["@nombre"] = row[1];
                        parameters["@celular"] = row[2];
                        parameters["@nombreCorto"] = row[3];
                        parameters["@activo"] = row[4];                        
                        parameters["@haceValoracion"] = row[5];                        
                        
                        int qtyi = sdb.EjecutarNonQuery("usp_InsertMetodoPago", parameters);

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

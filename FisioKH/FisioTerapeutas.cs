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
    }
}

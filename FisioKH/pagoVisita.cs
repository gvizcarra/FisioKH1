using FisioKH.classes;
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
    public partial class pagoVisita : BaseForm
    {
        public pagoVisita(Dictionary<string, object> valoresVisita)
        {
            InitializeComponent();

            DBHelper dbh = new DBHelper();
            //MessageBox.Show(valoresVisita);

            var listaMetodoPago = ConvertToMetodoPagoList(dbh.obtenerMetodosPago());


            this.cboMetodoPago.DataSource = listaMetodoPago;
            this.cboMetodoPago.DisplayMember = "nombre"; // what user sees
            this.cboMetodoPago.ValueMember = "id";


            if (valoresVisita.ContainsKey("idMetodoPago") && valoresVisita["idMetodoPago"] != DBNull.Value)
            {
                this.cboMetodoPago.SelectedValue = Convert.ToInt64(valoresVisita["idMetodoPago"]);
            }

            this.txtIdPago.Text = valoresVisita["idPago"].ToString();
            this.txtNombrePaciente.Text = valoresVisita["Paciente"].ToString();
            this.txtCantidadPagada.Text = valoresVisita["cantidadPagada"].ToString();


            decimal max = 0;

            if (valoresVisita.ContainsKey("cantidadPrecio") &&
                valoresVisita["cantidadPrecio"] != DBNull.Value)
            {
                max = Convert.ToDecimal(valoresVisita["cantidadPrecio"]);
            }

            txtCantidadPagada.Maximum = max;


            this.txtPrecio.Text = valoresVisita["cantidadPrecio"].ToString();
        }

        private List<MetodoPago> ConvertToMetodoPagoList(DataTable dt)
        {
            return dt.AsEnumerable()
                     .Select(r => new MetodoPago
                     {
                         Id = r.Field<long>("id"),
                         Nombre = r.Field<string>("nombre"),
                         OcupaReferenciaPago = r.Field<bool>("ocupaReferenciaPago")
                     })
                     .ToList();
        }

        private void pagoVisita_Load(object sender, EventArgs e)
        {
           
        }

        private object GetBigIntOrNull(string text)
        {
            long value;
            return (long.TryParse(text, out value) && value != 0)
                ? (object)value
                : 0;
        }



        private void cboMetodoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int metodoPago = Convert.ToInt32(cboMetodoPago.SelectedValue);

            if(metodoPago == 10)
            {
                MessageBox.Show("Metodo Pago Saldo no Habilitada,seleccione Otro!");
                cboMetodoPago.SelectedIndex = 0;
                return;
            }
        }

        private void btnGuardarPago_Click(object sender, EventArgs e)
        {
            DBHelper sdb = new DBHelper();
            var parameters = new Dictionary<string, object>
            {
                { "@idPago", GetBigIntOrNull(txtIdPago.Text) },
                { "@idUsuario", Program.UsuarioLogeado.Id },
                { "@idMetodoPago" , cboMetodoPago.SelectedValue },
                { "@cantidadPago" , GetBigIntOrNull(txtCantidadPagada.Text) }
            };
 

             int qtyi = sdb.EjecutarNonQuery("usp_updatePagoVisitaAdmin", parameters);

            if (qtyi > 0)
            {
                MessageBox.Show("Registro Guardado,Cierre ventana y actualize expediente!");
               // cargarGridExpedientePaciente(idPaciente);
            }
            else
            {
                MessageBox.Show("Error al Guardar");
            }



        }

        private void btnBorrarPago_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                   "Desea Borrar este Pago??",
                   "Confirmar!",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                eliminarPago();
            }
        }

        private void eliminarPago()
        {

            DBHelper dbh = new DBHelper();

            var parameters = new Dictionary<string, object>
                {
                    { "@idPago",  GetBigIntOrNull(txtIdPago.Text) }
                };


            var outParams = new Dictionary<string, SqlDbType>
                {
                    { "@rowsAffected", SqlDbType.Int }
                };

            Dictionary<string, object> outValues;

            dbh.EjecutarNonQuery(
                "usp_deletePagoVisitaAdmin",
                parameters,
                outParams,
                out outValues
            );

            // read output value
            int rowsAffected = Convert.ToInt32(outValues["@rowsAffected"]);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Pago eliminado.");
            }
            else
            {
                MessageBox.Show("No se eliminó. El Pago tiene Saldos relacionados!");
            }

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

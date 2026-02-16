using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using static FisioKH.FisioKHCalendar;
using System.IO;

namespace FisioKH
{
    public partial class IngresoPaciente : BaseForm
    {
        private FisioKH.FisioKHCalendar.CalendarEventKH fce;
        private readonly DateTime _nullDate = new DateTime(1900, 1, 1);



        // REQUIRED for Designer
        public IngresoPaciente(CalendarEventKH ce)
        {
            fce = ce;
            InitializeComponent();
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            /* Event.Title = txtTitle.Text;
             Event.StartTime = dtStart.Value;
             //Event.EndTime = dtEnd.Value;
             Event.Color = pnlColor.BackColor;*/

            DialogResult = DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }


        private void EventDetailsForm_Load(object sender, EventArgs e)
        {
            DBHelper dbh = new DBHelper();


            this.cboPrecio.DataSource = dbh.obtenerPrecios();
            this.cboPrecio.DisplayMember = "nombre"; // what user sees
            this.cboPrecio.ValueMember = "id";

            this.cboFisioTerapeuta.DataSource = dbh.obtenerFisios();
            this.cboFisioTerapeuta.DisplayMember = "nombre"; // what user sees
            this.cboFisioTerapeuta.ValueMember = "id";

            this.cboMetodoPago.DataSource = dbh.obtenerMetodosPago();
            this.cboMetodoPago.DisplayMember = "nombre"; // what user sees
            this.cboMetodoPago.ValueMember = "id";
            cargarFormaDatosCitaVisita();

        }

        private void cargarFormaDatosCitaVisita()
        {
            cargarGridPacientes(this.txtBuscarPacienteIngreso.Text);

            this.txtIdGoogleCalendar.Text = fce.Id.ToString();
            this.txtIdGoogleCalendar.BackColor = Color.FromArgb(fce.Color.A, fce.Color.R, fce.Color.G, fce.Color.B);
            this.txtBuscarPacienteIngreso.Text = fce.Title.ToString();
            this.btnBuscarPaciente.PerformClick();

            this.txtNombrePaciente.Text = fce.cNombreCompletoPaciente.ToString();
            this.cboFisioTerapeuta.SelectedValue = fce.cIdFisioterapeuta ?? (object)DBNull.Value;
            this.cboPrecio.SelectedValue = fce.vIdPrecio ?? (object)DBNull.Value;
            this.dtpIngresoFecha.Text = (fce.cFechaCita != DateTime.MinValue) ? fce.cFechaCita.ToString() : fce.Start.ToString();

            this.txtNotasMedicas.Text = fce.pNotas;
            this.txtObservaciones.Text = fce.pObservaciones;
            this.chkRealizada.Checked = fce.cRealizada;
            this.chkFactura.Checked = fce.vOcupaFactura;
            this.chkPagada.Checked = fce.vPagado;

            this.txtIdPaciente.Text = fce.cIdPaciente.ToString();
            this.txtIdCita.Text = fce.cIdCita.ToString();
            this.txtIdVisita.Text = fce.vIdVisita.ToString();
            this.txtIdPago.Text = fce.vrIdPago.ToString();

            if (fce.cIdPaciente > 0)
            { cargarGridExpedientePaciente((long)fce.cIdPaciente); }


            //if ((Program.UsuarioLogeado.Nivel == 2) && (fce.cIdCita > 0))
            if ((fce.cIdCita > 0))
            {
                controlesCitaSoloLectura(true);
            }
            
            if ( (fce.vPagado) || (fce.cIdCita <= 0) )
            {
                controlesPagoSoloLectura(true);
            }


            if (Program.UsuarioLogeado.Nivel == 1)
            {
                controlesCitaSoloLectura(false);
                if (fce.cIdCita > 0)
                { controlesPagoSoloLectura(false); }
            }



        }


        private void controlesPagoSoloLectura(bool readOnly)
        {
            const string lockIcon = "🔒 ";

            txtPaga.Enabled = !readOnly;
            cboMetodoPago.Enabled = !readOnly;

            btnGuardarPago.Enabled = !readOnly;
            btnGuardarPago.Text = (readOnly) ? btnGuardarPago.Text = lockIcon + btnGuardarPago.Text : btnGuardarPago.Text = btnGuardarPago.Text.Replace(lockIcon, "");
        } 
        
        private void controlesCitaSoloLectura(bool readOnly)
        {
            const string lockIcon = "🔒 ";

            txtIdGoogleCalendar.ReadOnly = readOnly;
            txtBuscarPacienteIngreso.ReadOnly = readOnly;
            txtNombrePaciente.ReadOnly = readOnly;
            txtNotasMedicas.ReadOnly = readOnly;
            txtBuscarPacienteIngreso.ReadOnly = readOnly;

            cboFisioTerapeuta.Enabled = !readOnly;

            cboPrecio.Enabled = !readOnly;

            dtpIngresoFecha.Enabled = !readOnly;

            chkRealizada.Enabled = !readOnly;
            chkFactura.Enabled = !readOnly;
            chkPagada.Enabled = !readOnly;

            dgvBuscarPaciente.Enabled = !readOnly;
            btnBuscarPaciente.Enabled = !readOnly;
            btnBuscarPaciente.Text = (readOnly) ? btnBuscarPaciente.Text = lockIcon + btnBuscarPaciente.Text: btnBuscarPaciente.Text = btnBuscarPaciente.Text.Replace(lockIcon, "");
            btnAgregarPx.Enabled = !readOnly;
            btnAgregarPx.Text = (readOnly) ? btnAgregarPx.Text = lockIcon + btnAgregarPx.Text : btnAgregarPx.Text = btnAgregarPx.Text.Replace(lockIcon, "");
            btnGuardarCitaVisita.Enabled = !readOnly;
            btnGuardarCitaVisita.Text = (readOnly) ? btnGuardarCitaVisita.Text = lockIcon + btnGuardarCitaVisita.Text : btnGuardarCitaVisita.Text = btnGuardarCitaVisita.Text.Replace(lockIcon, "");


        }



        private void cargarGridExpedientePaciente(long idPaciente)
        {


            DataSet dsmp = new DataSet();
            string dsname = "ExpedientePaciente";

            var parameters = new Dictionary<string, object>
            {
                { "@idPaciente", idPaciente },             
                
            };
            DBHelper sdb = new DBHelper();
            dsmp = sdb.ObtenerDatos("usp_obtenExpedientePaciente", dsname, parameters);


            DataTable dtp = dsmp.Tables[dsname];


            this.dgvExpediente.Visible = false;
            this.dgvExpediente.DataSource = dtp;



            //foreach (DataGridViewColumn col in dgvBuscarPaciente.Columns)
            //{ col.Visible = false; }

            //dgvBuscarPaciente.Columns["NombreCompleto"].Visible = true;
            //dgvBuscarPaciente.Columns["NombreCompleto"].HeaderText = "Nombre";



            this.dgvExpediente.Visible = true;
        }
        
        private void cargarGridPacientes(string paciente = null)
        {


            DataSet dsmp = new DataSet();
            string dsname = "Pacientes";

            var parameters = new Dictionary<string, object>
            {
                { "@nombreCompleto", paciente },
                { "@celular", (object)DBNull.Value },
                { "@email", (object)DBNull.Value},
                //{ "@fechaNacimiento", fechaNacimiento }
                
            };
            DBHelper sdb = new DBHelper();
            dsmp = sdb.ObtenerDatos("usp_ObtenerPacientes", dsname, parameters);


            DataTable dtp = dsmp.Tables[dsname];


            this.dgvBuscarPaciente.Visible = false;
            this.dgvBuscarPaciente.DataSource = dtp;



            foreach (DataGridViewColumn col in dgvBuscarPaciente.Columns)
            { col.Visible = false; }

            dgvBuscarPaciente.Columns["NombreCompleto"].Visible = true;
            dgvBuscarPaciente.Columns["NombreCompleto"].HeaderText = "Nombre";



            this.dgvBuscarPaciente.Visible = true;
        }

        private void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            Pacientes fm = new Pacientes();
            fm.ShowDialog();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            cargarGridPacientes(this.txtBuscarPacienteIngreso.Text);


        }

    

        private void SetPictureFromVarbinary(PictureBox pb, object fotoValue)
        {
            if (pb.Image != null)
            {
                var old = pb.Image;
                pb.Image = null;
                old.Dispose();
            }

            if (fotoValue == DBNull.Value || fotoValue == null)
            {
                pb.Image = null; // or default avatar
                return;
            }

            byte[] bytes = (byte[])fotoValue;

            using (MemoryStream ms = new MemoryStream(bytes))
            using (Image img = Image.FromStream(ms))
            {
                pb.Image = new Bitmap(img);
            }

            pb.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void txtBuscarPacienteIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarGridPacientes(this.txtBuscarPacienteIngreso.Text);
            }
        }

        private void btnAgregarPx_Click(object sender, EventArgs e)
        {
            Pacientes fm = new Pacientes();
            fm.ShowDialog();
        }

        private void cboPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPrecio.SelectedIndex == -1) return;

            DataRowView row = cboPrecio.SelectedItem as DataRowView;
            if (row == null) return;

            decimal precio = Convert.ToDecimal(row["precio"]);
            Boolean pacientePaga = Convert.ToBoolean(row["pacientePaga"]);

            if (pacientePaga)
            {
                this.txtPaga.ReadOnly = false;
                this.cboMetodoPago.Enabled = true;
                this.txtPaga.Enabled = true;
                this.txtCambio.Text = "";
            }
            else
            {
                MessageBox.Show("Con Este Precio Paciente No Paga!!");
                this.cboMetodoPago.Enabled = false;
                this.txtCantidadAPagar.Text = "";
                this.txtPaga.ReadOnly = true;
                this.txtPaga.Enabled = false;
                this.txtCambio.Text = "";
                this.txtPaga.Value = 0;

            }

            txtCantidadAPagar.Text = precio.ToString("N2");
        }



        private void txtPaga_ValueChanged(object sender, EventArgs e)
        {
            DataRowView row = cboPrecio.SelectedItem as DataRowView;
            if (row == null) return;

            Boolean pacientePaga = Convert.ToBoolean(row["pacientePaga"]);

            if (pacientePaga)
            {
                decimal precio = Convert.ToDecimal(row["precio"]);
                decimal paga = this.txtPaga.Value;
                decimal cambio = precio - paga;
                this.txtCambio.Text = cambio.ToString();
            }
        }

        private void dgvBuscarPaciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            DataGridViewRow gridRow = dgvBuscarPaciente.Rows[e.RowIndex];
            DataRowView drv = gridRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            cargarGridExpedientePaciente((long)drv["Id"]);
            lblNombreCompleto.Text = (drv["Nombre"]?.ToString() ?? "") + ' ' + (drv["apellidoPaterno"]?.ToString() ?? "") + ' ' + (drv["apellidoMaterno"]?.ToString() ?? "");

            lblCelular.Text = drv["Celular"]?.ToString() ?? "";
            lblSexo.Text = drv["Sexo"]?.ToString() ?? "";
            lblEdad.Text = drv["Edad"]?.ToString() ?? "";
            lblMedicoTratante.Text = drv["MedicoTratante"]?.ToString() ?? "";
            lblFisio.Text = drv["Fisio"]?.ToString() ?? "";
            this.cboFisioTerapeuta.SelectedValue = drv["idFisioTerapeuta"].ToString();
            this.cboPrecio.SelectedValue = drv["idPrecio"]?.ToString();
            lblDob.Text = drv["FechaNacimiento"]?.ToString().Substring(0, 9) ?? "";
            txtObservaciones.Text = drv["observaciones"]?.ToString() ?? "";
            txtNotasMedicas.Text = drv["notasMedicas"]?.ToString() ?? "";
            lblEmail.Text = drv["email"]?.ToString() ?? "";
            lblTipoIngreso.Text = drv["Etiqueta"]?.ToString() ?? "";
            lblCitas.Text = drv["totalCitas"]?.ToString() ?? "";
            lblIngresos.Text = drv["totalIngresos"]?.ToString() ?? "";
            lblIngresosPagados.Text = drv["totalIngresosPagados"]?.ToString() ?? "";
            txtIdPaciente.Text = drv["Id"]?.ToString() ?? "";

            txtNombrePaciente.Text = lblNombreCompleto.Text;


            SetPictureFromVarbinary(pbxPacienteIngreso, drv["Foto"]);

        }

        private void txtNotasVisita_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarCitaVisita_Click(object sender, EventArgs e)
        {
            int idCita = 0, qtyi = 0,idVisita=0,idPago = 0;

            int.TryParse(this.txtIdCita.Text, out idCita);
            int.TryParse(this.txtIdVisita.Text, out idVisita);
            int.TryParse(this.txtIdPago.Text, out idPago);

            DBHelper sdb = new DBHelper();

            var parameters = new Dictionary<string, object>
            {
                { "@idUsuario",           Program.UsuarioLogeado.Id },                 
            };

            Dictionary<string, SqlDbType> outs = new Dictionary<string, SqlDbType>
            {
                { "@idCita", SqlDbType.BigInt },
                { "@idVisita", SqlDbType.BigInt }
            };

            Dictionary<string, object> outValues;

            parameters["@idPaciente"] = GetBigIntOrNull(txtIdPaciente.Text);
            parameters["@fechaCita"] = GetDateOrNull(dtpIngresoFecha);
            parameters["@fechaVisita"] = GetDateOrNull(dtpIngresoFecha);
            parameters["@idGoogleCalendar"] = txtIdGoogleCalendar.Text;

            parameters["@idFisioTerapeuta"] = cboFisioTerapeuta.SelectedValue;
            parameters["@idPrecio"] = cboPrecio.SelectedValue;
            parameters["@ocupaFactura"] = this.chkFactura.Checked;
            parameters["@notas"] = this.txtNotasMedicas.Text;

            idCita = 0;
            if (idCita > 0)
            {
                parameters.Add("@id", idCita);
                qtyi = sdb.EjecutarNonQuery("usp_crearCitaVisita", parameters, outs, out outValues);
            }
            else
            { qtyi = sdb.EjecutarNonQuery("usp_crearCitaVisita", parameters, outs, out outValues); }


            if (qtyi > 0)
            { MessageBox.Show("Registro Guardado"); }



        }

        private object GetBigIntOrNull(string text)
        {
            long value;
            return (long.TryParse(text, out value) && value != 0)
                ? (object)value
                : DBNull.Value;
        }


        private object GetDateOrNull(DateTimePicker dtp)
        {
            return (dtp.Value.Date != _nullDate)
                ? (object)dtp.Value
                : DBNull.Value;
        }

        private void IngresoPaciente_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}

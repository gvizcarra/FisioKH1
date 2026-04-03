using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using static FisioKH.FisioKHCalendar;
using System.IO;
using FisioKH.classes;
using System.Linq;

namespace FisioKH
{
    public partial class IngresoPaciente : BaseForm
    {
        private FisioKH.FisioKHCalendar.CalendarEventKH fce;
        private readonly DateTime _nullDate = new DateTime(1900, 1, 1);
        private DataTable dtp;

        Boolean pacientePaga = true;



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

        private List<Precio> ConvertToPrecioList(DataTable dt)
        {
            return dt.AsEnumerable()
                     .Select(r => new Precio
                     {
                         Id = r.Field<long>("id"),
                         Nombre = r.Field<string>("nombre"),
                         PacientePaga = r.Field<bool>("pacientePaga")
                     })
                     .ToList();
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

        private void EventDetailsForm_Load(object sender, EventArgs e)
        {
            DBHelper dbh = new DBHelper();

            var listaMetodoPago = ConvertToMetodoPagoList(dbh.obtenerMetodosPago());



            this.cboPrecio.DataSource = dbh.obtenerPrecios();
            this.cboPrecio.DisplayMember = "nombre"; // what user sees
            this.cboPrecio.ValueMember = "id";

            this.cboFisioTerapeuta.DataSource = dbh.obtenerFisios();
            this.cboFisioTerapeuta.DisplayMember = "nombre"; // what user sees
            this.cboFisioTerapeuta.ValueMember = "id";

            this.cboMetodoPago.DataSource = listaMetodoPago;
            this.cboMetodoPago.DisplayMember = "nombre"; // what user sees
            this.cboMetodoPago.ValueMember = "id";
            cargarFormaDatosCitaVisita();

        }

        private void cargarFormaDatosCitaVisita()
        {
            string nombrePacienteGC = "";
            DataTable dtVpsaldo;
            DBHelper dbh = new DBHelper();
            long idSaldoPago = 0;
            long cantidadPagoconSaldo = 0;
            long? idMetodoPago = (long?)fce.vrIdMetodoPago??(long?)0;

            if (!string.IsNullOrWhiteSpace(fce.Title.ToString().Trim()))
            {
                nombrePacienteGC = fce.Title.ToString().Trim()
                    .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)[0];
            }




            this.txtBuscarPacienteIngreso.Text = nombrePacienteGC;


            cargarGridPacientes(this.txtBuscarPacienteIngreso.Text);

            this.txtIdGoogleCalendar.Text = fce.Id.ToString();
            this.txtIdGoogleCalendar.BackColor = Color.FromArgb(fce.Color.A, fce.Color.R, fce.Color.G, fce.Color.B);

            this.btnBuscarPaciente.PerformClick();

            this.txtNombrePaciente.Text = fce.cNombreCompletoPaciente.ToString();
            this.cboFisioTerapeuta.SelectedValue = fce.cIdFisioterapeuta ?? (object)DBNull.Value;
            this.cboPrecio.SelectedValue = fce.vIdPrecio ?? (object)DBNull.Value;

            if (idMetodoPago != 10)
            {
                this.cboMetodoPago.SelectedValue = fce.vrIdMetodoPago ?? (object)DBNull.Value;
            }
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
            //if ( (idMetodoPago != 10) && (idMetodoPago != 0) )
            //{ 
                this.txtCantidadPagada.Text = fce.vrCantidadPago.ToString(); 
            //}

            obtenerSaldoPaciente((long)fce.cIdPaciente,1);

            dtVpsaldo = dbh.obtenVisitasPagadasConSaldo((long)fce.vIdVisita,(long)fce.vIdPaciente);

            foreach (DataRow row in dtVpsaldo.Rows)
            {
                idSaldoPago = (long)row["idSaldo"];
                cantidadPagoconSaldo = row["cantidadPago"] != DBNull.Value ? Convert.ToInt64(row["cantidadPago"]) : 0;                
            }

            this.cboSaldo.SelectedValue = idSaldoPago;
            this.cantidadSaldoUsar.Maximum = cantidadPagoconSaldo;
            this.cantidadSaldoUsar.Text = cantidadPagoconSaldo.ToString();

           if(fce.vIdVisita.ToString()!="0")
            {
                tabPxGeneralesPago.SelectedIndex = 1;
            }

            if (fce.cIdPaciente > 0)
            { cargarGridExpedientePaciente((long)fce.cIdPaciente); }


            //if ((Program.UsuarioLogeado.Nivel == 2) && (fce.cIdCita > 0))
            if ((fce.cIdCita > 0))
            {
                controlesCitaSoloLectura(true);
            }

            if ((fce.vPagado) || (fce.cIdCita <= 0))
            {
                controlesPagoSoloLectura(true);
                this.txtCambio.Text = "0";
            }


            if (Program.UsuarioLogeado.Nivel == 1)
            {
                controlesCitaSoloLectura(false);
                //if (fce.cIdCita > 0)
                //{ controlesPagoSoloLectura(false); }
            }



        }


        private void controlesPagoSoloLectura(bool readOnly)
        {
            const string lockIcon = "🔒 ";

            txtCantidadPagada.Enabled = !readOnly;
            cboMetodoPago.Enabled = !readOnly;
            this.btnIgualarPagoAprecio.Enabled = !readOnly;
            this.cboSaldo.Enabled = !readOnly;
            this.cantidadSaldoUsar.Enabled = !readOnly;
            this.btnPasarSaldoAPago.Enabled = !readOnly;
            this.btnIgualarPagoAprecio.Enabled = !readOnly;


            btnGuardarPago.Enabled = !readOnly;
            btnGuardarPago.Text = (readOnly) ? btnGuardarPago.Text = lockIcon + btnGuardarPago.Text : btnGuardarPago.Text = btnGuardarPago.Text.Replace(lockIcon, "");
        }

        private void controlesCitaSoloLectura(bool readOnly)
        {
            const string lockIcon = "🔒 ";

            txtIdGoogleCalendar.ReadOnly = readOnly;
            txtBuscarPacienteIngreso.ReadOnly = readOnly;
            //txtNombrePaciente.ReadOnly = readOnly;
            // txtNotasMedicas.ReadOnly = readOnly;
            //txtObservaciones.ReadOnly = readOnly;
            txtBuscarPacienteIngreso.ReadOnly = readOnly;

            cboFisioTerapeuta.Enabled = !readOnly;

            if (Program.UsuarioLogeado.Nivel == 1)
            { cboPrecio.Enabled = !readOnly; }

            dtpIngresoFecha.Enabled = !readOnly;

            //chkRealizada.Enabled = !readOnly;
            chkFactura.Enabled = !readOnly;
            //chkPagada.Enabled = !readOnly;

            dgvBuscarPaciente.Enabled = !readOnly;
            btnBuscarPaciente.Enabled = !readOnly;
            btnBuscarPaciente.Text = (readOnly) ? btnBuscarPaciente.Text = lockIcon + btnBuscarPaciente.Text : btnBuscarPaciente.Text = btnBuscarPaciente.Text.Replace(lockIcon, "");
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


            dtp = dsmp.Tables[dsname];


            this.dgvExpediente.Visible = false;
            this.dgvExpediente.DataSource = dtp;



            foreach (DataGridViewColumn col in dgvExpediente.Columns)
            { col.Visible = false; }

            dgvExpediente.Columns["idCita"].Visible = true;
            dgvExpediente.Columns["idCita"].HeaderText = "idCita";
            dgvExpediente.Columns["idCita"].DisplayIndex = 11;

            dgvExpediente.Columns["fechaCita"].Visible = true;
            dgvExpediente.Columns["fechaCita"].HeaderText = "Cita";
            dgvExpediente.Columns["fechaCita"].DisplayIndex = 12;

            dgvExpediente.Columns["idPago"].Visible = true;
            dgvExpediente.Columns["idPago"].HeaderText = "idPago";
            dgvExpediente.Columns["idPago"].DisplayIndex = 1;


            dgvExpediente.Columns["Fecha Pago"].Visible = true;
            dgvExpediente.Columns["Fecha Pago"].HeaderText = "Fecha Pago";
            dgvExpediente.Columns["Fecha Pago"].DisplayIndex = 2;

            dgvExpediente.Columns["Paciente"].Visible = false;
            dgvExpediente.Columns["Paciente"].HeaderText = "Paciente";

            dgvExpediente.Columns["Fisio Terapeuta"].Visible = true;
            dgvExpediente.Columns["Fisio Terapeuta"].HeaderText = "Fisio";

            dgvExpediente.Columns["Metodo Pago"].Visible = true;
            dgvExpediente.Columns["Metodo Pago"].HeaderText = "Metodo Pago";
            dgvExpediente.Columns["Metodo Pago"].DisplayIndex = 3; 

            dgvExpediente.Columns["NombrePrecio"].Visible = true;
            dgvExpediente.Columns["NombrePrecio"].HeaderText = "Tipo Precio";

            dgvExpediente.Columns["Pagado"].Visible = false;
            dgvExpediente.Columns["Pagado"].HeaderText = "Se Pagó";

            dgvExpediente.Columns["Cantidad Precio"].Visible = true;
            dgvExpediente.Columns["Cantidad Precio"].HeaderText = "Precio";
            dgvExpediente.Columns["Cantidad Precio"].DisplayIndex = 2;

            dgvExpediente.Columns["Paciente Paga"].Visible = true;
            dgvExpediente.Columns["Paciente Paga"].HeaderText = "Px Paga";
            dgvExpediente.Columns["Paciente Paga"].DisplayIndex = 4;

            dgvExpediente.Columns["Cantidad Pagada"].Visible = true;
            dgvExpediente.Columns["Cantidad Pagada"].HeaderText = "Pagó";
            dgvExpediente.Columns["Cantidad Pagada"].DisplayIndex = 5;

            if (Program.UsuarioLogeado.Nivel == 1)// si es admin agrega boton
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.Name = "btnEdit";
                btnEdit.HeaderText = "";
                btnEdit.Text = "Editar";
                btnEdit.UseColumnTextForButtonValue = true;

                dgvExpediente.Columns.Insert(0, btnEdit);
            }
            



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

            pacientePaga = false;

            var value = row["pacientePaga"];

            if (value != DBNull.Value && value != null)
            {
                bool.TryParse(value.ToString(), out pacientePaga);
            }


            decimal precio = 0m;

            var valuePrecio = row["precio"];

            if (valuePrecio != DBNull.Value && valuePrecio != null)
            {
                decimal.TryParse(valuePrecio.ToString(), out precio);
            }


            if (pacientePaga)
            {
                this.lblPrecioPago.Text = "Precio";
                this.txtCantidadPagada.ReadOnly = false;
                this.cboMetodoPago.Enabled = true;
                this.txtCantidadPagada.Enabled = true;
                this.txtCantidadAPagar.Text = precio.ToString();
               // this.txtCantidadAPagar.Enabled = true;
                this.txtCambio.Text = "";
            }
            else
            {
                //MessageBox.Show("Con Este Precio Paciente No Paga!!");
                this.lblPrecioPago.Text = "Px no Paga!";
                this.cboMetodoPago.Enabled = false;
                this.txtCantidadAPagar.Text = "";
               // this.txtCantidadAPagar.Enabled = false;
                this.txtCantidadPagada.ReadOnly = true;
                this.txtCantidadPagada.Enabled = false;
                this.txtCambio.Text = "";
                this.txtCantidadPagada.Value = 0;

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
                decimal paga = this.txtCantidadPagada.Value;
                decimal cambio = paga - precio;
                this.txtCambio.Text = cambio.ToString();
            }
        }

        private void dgvBuscarPaciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            DataGridViewRow gridRow = dgvBuscarPaciente.Rows[e.RowIndex];
            DataRowView drv = gridRow.DataBoundItem as DataRowView;


            if (drv == null) return;

            long idPaciente = (long)drv["Id"];

            obtenerSaldoPaciente(idPaciente,0);



            cargarGridExpedientePaciente(idPaciente);
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
            //this.btnGuardarCitaVisita.Enabled = true;


            SetPictureFromVarbinary(pbxPacienteIngreso, drv["Foto"]);

        }

        private void obtenerSaldoPaciente(long idPaciente,int todosSaldos)
        {
            string fechaSaldo = "";
            long saldo = 0;
            long idSaldo = 0;

            DBHelper dbh = new DBHelper();
            DataTable dtsp = dbh.dbObtenerSaldoPaciente(idPaciente, todosSaldos);

            var listaSaldo = new List<SaldoItem>();

            foreach (DataRow row in dtsp.Rows)
            {
                fechaSaldo = row["fechaSaldo"] != DBNull.Value ? Convert.ToDateTime(row["fechaSaldo"]).ToString("dd/MM/yyyy"): "";

                saldo = row["saldo"] != DBNull.Value ? Convert.ToInt32(row["saldo"]): 0;

                idSaldo = row["id"] != DBNull.Value ? Convert.ToInt32(row["id"]) : 0;

               
                    listaSaldo.Add(new SaldoItem
                    {
                        IdSaldo = idSaldo,
                        Saldo = saldo,
                        Fecha = fechaSaldo,
                        Text = $"Saldo (${saldo}) - {fechaSaldo}" // ✅ display both
                    });
                
            }

 
            if (listaSaldo.Count > 0)
            {
                foreach (var item in listaSaldo)
                {
                    this.cantidadSaldoDisponible.Value = item.Saldo;
                    this.txtSaldoId.Text = item.IdSaldo.ToString();
                }
            }

          
            cboSaldo.DataSource = null;
            cboSaldo.DataSource = listaSaldo;
            cboSaldo.DisplayMember = "Text";
            cboSaldo.ValueMember = "IdSaldo";
        }

        private void txtNotasVisita_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarCitaVisita_Click(object sender, EventArgs e)
        {
            int idCita = 0, qtyi = 0, idVisita = 0, idPago = 0;
            long idPaciente = 0;


            long.TryParse(this.txtIdPaciente.Text, out idPaciente);
            int.TryParse(this.txtIdCita.Text, out idCita);
            int.TryParse(this.txtIdVisita.Text, out idVisita);
            int.TryParse(this.txtIdPago.Text, out idPago);

            if (idPaciente <= 0)
            {
                MessageBox.Show("Seleccionar un Paciente para Guardar Cita/Visita!");
                return;
            }

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


            if (idCita > 0)
            {
                parameters.Add("@idCita", idCita);
                parameters.Add("@idVisita", idVisita);
                qtyi = sdb.EjecutarNonQuery("usp_updateCitaVisita", parameters);
            }
            else
            {
                qtyi = sdb.EjecutarNonQuery("usp_insertCitaVisita", parameters, outs, out outValues);
                this.txtIdCita.Text = outValues["@idCita"].ToString();
                this.txtIdVisita.Text = outValues["@idVisita"].ToString();
                if ((long)outValues["@idVisita"] > 0)
                {
                    this.chkRealizada.Checked = true;
                }
            }


            if (qtyi > 0)
            {
                MessageBox.Show("Visita Guardada!");
                cargarGridExpedientePaciente(idPaciente);
                tabPxGeneralesPago.SelectedIndex = 1;
                controlesPagoSoloLectura(false);

            }



        }

        private object GetBigIntOrNull(string text)
        {
            long value;
            return (long.TryParse(text, out value) && value != 0)
                ? (object)value
                : 0;
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



        private void cboMetodoPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboMetodoPago.SelectedItem is MetodoPago metodoPago)
            {

                // If you want conditional behavior:
                if (metodoPago.OcupaReferenciaPago)
                {
                    this.txtCantidadPagada.Enabled = false;
                    this.btnIgualarPagoAprecio.Enabled = false;
                    IgualarPagoAprecio();

                }
                else
                {
                    this.txtCantidadPagada.Enabled = true;
                    this.btnIgualarPagoAprecio.Enabled = true;
                }
            }

        }

        private long agregarSaldoPaciente(decimal saldoPaciente, long idPagoVisitaRealizada)
        {
            int idCita = 0, idVisita = 0;
            long idPaciente = 0;
            long idSaldoGenerado = 0;

            long.TryParse(this.txtIdPaciente.Text, out idPaciente);
            int.TryParse(this.txtIdCita.Text, out idCita);
            int.TryParse(this.txtIdVisita.Text, out idVisita);

            DBHelper sdb = new DBHelper();

            var parameters = new Dictionary<string, object>
            {
                { "@saldo", saldoPaciente },
                { "@idPaciente", idPaciente },
                { "@idCita", idCita },
                { "@idVisita", idVisita },
                { "@idPagoVisitaRealizada", idPagoVisitaRealizada },
                { "@idUsuario", Program.UsuarioLogeado.Id }
            };

            Dictionary<string, SqlDbType> outs = new Dictionary<string, SqlDbType>
            {
                { "@idSaldoGenerado", SqlDbType.BigInt }
            };

            Dictionary<string, object> outValues;

            int rows = sdb.EjecutarNonQuery(
                "usp_GuardarSaldoPacienteVisita",  
                parameters,
                outs,
                out outValues
            );

     
            if (outValues.ContainsKey("@idSaldoGenerado") && outValues["@idSaldoGenerado"] != DBNull.Value)
            {
                idSaldoGenerado = Convert.ToInt64(outValues["@idSaldoGenerado"]);
            }

            if (rows > 0 && idSaldoGenerado > 0)
            {
              //  MessageBox.Show($"Saldo guardado correctamente. ID: {idSaldoGenerado}");
                obtenerSaldoPaciente(idPaciente,1);
                cargarGridExpedientePaciente(idPaciente);
            }

            return idSaldoGenerado;
        }

        private int realizarPago()
        {

            int idCita = 0, qtyi = 0, idVisita = 0, idPago = 0, idSaldo = 0;
            decimal cantidadSaldoUsar = 0;
            long idPaciente = 0, cantidadPagada = 0, cantidadAPagar = 0;


            long.TryParse(this.txtIdPaciente.Text, out idPaciente);
            int.TryParse(this.txtIdCita.Text, out idCita);
            int.TryParse(this.txtIdVisita.Text, out idVisita);
            int.TryParse(this.txtIdPago.Text, out idPago);
             
            long.TryParse(this.txtCantidadPagada.Text, out cantidadPagada);
            long.TryParse(this.txtCantidadAPagar.Text, out cantidadAPagar);

            cantidadSaldoUsar = this.cantidadSaldoUsar.Value;

            if (cboSaldo.SelectedValue != null)
            {
                int.TryParse(cboSaldo.SelectedValue.ToString(), out idSaldo);
            }


            if (cantidadPagada > cantidadAPagar)
            {
                long Cambio = cantidadPagada - cantidadAPagar;
               // MessageBox.Show("Regresar al Cliente $" + Cambio.ToString());
                cantidadPagada = cantidadPagada - Cambio;
                this.txtCantidadPagada.Text = cantidadPagada.ToString();

            }

            DBHelper sdb = new DBHelper();

            var parameters = new Dictionary<string, object>
            {
                { "@idUsuario", Program.UsuarioLogeado.Id },
                { "@idVisita", idVisita },
                { "@idMetodoPago" , cboMetodoPago.SelectedValue },
                { "@idPrecio" , cboPrecio.SelectedValue },
                { "@idSaldo" , idSaldo },
                { "@cantidadSaldoUsar" , cantidadSaldoUsar },
                { "@cantidadPago" , GetBigIntOrNull(txtCantidadPagada.Text) }
            };

            Dictionary<string, SqlDbType> outs = new Dictionary<string, SqlDbType>
            {
               { "@idPago", SqlDbType.BigInt }
            };

            Dictionary<string, object> outValues;




            if (idPago > 0)
            {
                parameters.Remove("@idPago");
                parameters.Add("@idPago", idPago);
                qtyi = sdb.EjecutarNonQuery("usp_updatePagoVisita", parameters);
            }
            else
            {
                qtyi = sdb.EjecutarNonQuery("usp_insertPagoVisita", parameters, outs, out outValues);
                //this.txtIdCita.Text = outValues["@idCita"].ToString();

                if ((long)outValues["@idPago"] > 0)
                {
                    this.chkPagada.Checked = true;
                    this.txtIdPago.Text = outValues["@idPago"].ToString();
                    int.TryParse(this.txtIdPago.Text, out idPago);
                }
            }


            if (qtyi > 0)
            {
                MessageBox.Show("Registro Guardado");
                cargarGridExpedientePaciente(idPaciente);
            }

            return idPago;
        }

        private void btnGuardarPago_Click(object sender, EventArgs e)
        {
            int idPago = 0;

            if (this.cboMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Metodo de Pago!!");
                return;
            }

            if (!pacientePaga)
            {
                idPago = realizarPago();
                return;
            }

            // Validar montos
            if (!decimal.TryParse(txtCantidadPagada.Text, out decimal cantidadPagada) ||
                !decimal.TryParse(txtCantidadAPagar.Text, out decimal cantidadAPagar))
            {
                MessageBox.Show("Valores inválidos. Verifique los montos.");
                return;
            }

            decimal saldoDisponible = cantidadSaldoDisponible.Value; // saldo total
            decimal saldoUsar = cantidadSaldoUsar.Value;             // saldo que quiere usar

            
            if (saldoUsar > saldoDisponible)
            {
                MessageBox.Show("El saldo a usar es mayor al saldo disponible.");
                return;
            }

            // 💰 Total efectivo (saldo + pago)
            decimal totalCubierto = saldoUsar + cantidadPagada;

            // ❌ No alcanza (ni con saldo)
            if (totalCubierto < cantidadAPagar)
            {
                decimal falta = cantidadAPagar - totalCubierto;
                MessageBox.Show($"No alcanza el pago. Falta cubrir: ${falta}");
                return;
            }

            // ✅ Calcular diferencia
            decimal diferencia = totalCubierto - cantidadAPagar;

            // 🔄 Si el saldo cubre todo o sobra → ajustar pago en efectivo
            if (saldoUsar >= cantidadAPagar)
            {
                decimal sobranteSaldo = saldoUsar - cantidadAPagar;

                // Ajustar lo que paga en efectivo (puede ser 0)
                txtCantidadPagada.Text = "0";

                if (sobranteSaldo > 0)
                {
                    this.cantidadSaldoUsar.Value = saldoUsar - sobranteSaldo;
                    MessageBox.Show($"El saldo cubre el pago completo,se ajusta pago con saldo. Sobrante: ${sobranteSaldo}");
                }

                idPago = realizarPago();
                return;
            }

            // 🔄 Si combinado da excedente
            if (diferencia > 0)
            {
               

                DialogResult result = MessageBox.Show(
                    $"El pago excede por ${diferencia}.\n ¿Desea guardar como saldo?",
                    "Pago excedente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    idPago = realizarPago();
                    long idSaldoAbonado = agregarSaldoPaciente((long)diferencia, idPago);

                    MessageBox.Show($"Saldo ${diferencia} guardado correctamente. ID: {idSaldoAbonado}");
                }
                else
                {
                    txtCantidadPagada.Text = (cantidadPagada - diferencia).ToString("0.00");
                    idPago = realizarPago();
                    MessageBox.Show($"Regresar al paciente: ${diferencia}");
                }

                return;
            }

            // ✅ Pago exacto (usando saldo + efectivo)
            idPago = realizarPago();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            IgualarPagoAprecio();
        }
        private void IgualarPagoAprecio()
        {
            this.txtCantidadPagada.Value = decimal.Parse(this.txtCantidadAPagar.Text);
        }

        private void cboPrecio_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void btnPasarSaldoAPago_Click(object sender, EventArgs e)
        {
            this.cantidadSaldoUsar.Value = this.cantidadSaldoDisponible.Value;
        }

        private void cboSaldo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.cantidadSaldoDisponible.Value = 0;
            //this.cantidadSaldoUsar.Value = 0;
            //this.txtSaldoId.Text = "";

            //if (cboSaldo.SelectedItem != null)
            //{
            //    var selected = (SaldoItem)cboSaldo.SelectedItem;

            //    if(selected.IdSaldo != 0)
            //    {
            //        cboMetodoPago.SelectedValue = (long)10;
            //    }
 
            //    cantidadSaldoDisponible.Value = selected.Saldo;
            //    txtSaldoId.Text = selected.IdSaldo.ToString();
            //}
        }

        private void cantidadSaldoDisponible_ValueChanged(object sender, EventArgs e)
        {
            cantidadSaldoUsar.Maximum = cantidadSaldoDisponible.Value;

            if (cantidadSaldoUsar.Value > cantidadSaldoDisponible.Value)
            {
                cantidadSaldoUsar.Value = cantidadSaldoDisponible.Value;
            }
        }

        private void cantidadSaldoUsar_ValueChanged(object sender, EventArgs e)
        {
            //if (cantidadSaldoUsar.Value > cantidadSaldoDisponible.Value)
            //{
            //    cantidadSaldoUsar.Value = cantidadSaldoDisponible.Value;
            //}
        }

        private void cboSaldo_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cantidadSaldoDisponible.Value = 0;
            this.cantidadSaldoUsar.Value = 0;
            this.txtSaldoId.Text = "";

            if (cboSaldo.SelectedItem != null)
            {
                var selected = (SaldoItem)cboSaldo.SelectedItem;

                if (selected.IdSaldo != 0 && (cboMetodoPago.SelectedValue == null || cboMetodoPago.SelectedValue == DBNull.Value))
                {
                   // cboMetodoPago.SelectedValue = (long)10;
                }

                cantidadSaldoDisponible.Value = selected.Saldo;
                txtSaldoId.Text = selected.IdSaldo.ToString();
            }

        }

        private void dgvExpediente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvExpediente.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                DataRow row = dtp.Rows[e.RowIndex];

                var parameters = new Dictionary<string, object>();

                parameters["idPago"] = row["idPago"].ToString();
                parameters["Paciente"] = row["Paciente"].ToString();
                parameters["idMetodoPago"] = row["idMetodoPago"].ToString();
                parameters["fechaPago"] = row["Fecha Pago"].ToString();
                parameters["cantidadPagada"] = row["Cantidad Pagada"].ToString();
                parameters["cantidadPrecio"] = row["Cantidad Precio"].ToString();
                //parameters["cantidadPago"] = 10;
                //parameters["cantidadPago"] = 10;

                if(parameters["idMetodoPago"].ToString() == "10")
                {
                    MessageBox.Show("Edicion de Pago con Saldo no Habilitada!");
                    return;
                }



                pagoVisita pv = new pagoVisita(parameters);
                pv.ShowDialog();


                //this.txtNombreCompleto.Text = row["Nombre"].ToString();
            }

        }
    }



}

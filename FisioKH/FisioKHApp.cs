using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FisioKH
{
    public partial class FisioKHApp : BaseForm
    {
        private readonly GoogleCalendarService calendar = new GoogleCalendarService();

        // NEW: prevent wiring multiple times when tab is re-selected
        private bool _calendarWired = false;

        // NEW: prevent overlapping reloads
        private bool _isReloadingCalendar = false;

        public FisioKHApp()
        {
            InitializeComponent();
        }

        private Array ObtentabsSeguras()
        {
            Array tabsSeguras = configSettings.ObtenTabsSeguras;
            return tabsSeguras;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lstBoxLogs.ContextMenuStrip = contextMenuStrip1;
            this.Text = configSettings.ObtenNombreApp;

            DesHabilitaTabs(ObtentabsSeguras());
        }

        /// <summary>
        /// This is the ONLY data path: it returns a DataTable already merged (Google + DB extras)
        /// </summary>
        private async Task<DataTable> LoadCalendarDataAsync(DateTime from, DateTime to)
        {
            if (!EnsureCalendar())
                return null;

            try
            {
                // ONE call. GoogleCalendarService.GetEventsTableAsync() already merges DB columns.
                return await calendar.GetEventsTableAsync(from, to);
            }
            catch (Exception ex)
            {
                this.lstBoxLogs.Items.Add(DateTime.Now + " - Error cargando calendario: " + ex.Message);
                return null;
            }
        }

        // NEW: refresh helper that forces the calendar control to re-request data
        private async Task RefreshCalendarFromDbAsync()
        {
            if (_isReloadingCalendar) return;
            _isReloadingCalendar = true;

            if (!EnsureCalendar())
            {
                _isReloadingCalendar = false;
                return;
            }

            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await fisioKHCalendar1.ReloadDataFromFormAsync();
            }
            catch (Exception ex)
            {
                lstBoxLogs.Items.Add(DateTime.Now + " - Error refrescando calendario: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.Enabled = true;
                _isReloadingCalendar = false;
            }
        }

        // IMPORTANT: must match event signature => async void is correct here
        private async void MyCalendar_EventClick(object sender, FisioKHCalendar.CalendarEventKH e)
        {
            try
            {
                using (var edt = new IngresoPaciente(e))
                {
                    // Modal: blocks until closed
                    edt.ShowDialog(this);
                }

                // KEY: your DBHelper caches DB extras for 5 minutes (including "null"/negative cache)
                // so you MUST invalidate the cache for this event id.
                if (!string.IsNullOrWhiteSpace(e?.Id))
                    DBHelperAsync.InvalidateCacheForEventId(e.Id);

                // If IngresoPaciente changes more than one event or you want brute-force:
                // DBHelperAsync.ClearCache();

                await RefreshCalendarFromDbAsync();
            }
            catch (Exception ex)
            {
                lstBoxLogs.Items.Add(DateTime.Now + " - Error al abrir IngresoPaciente/refrescar: " + ex.Message);
            }
        }

        private async void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name != "tbIngresos")
                return;

            if (!Program.UsuarioLogeado.Autenticado)
                return;

            // Wire ONLY ONCE (your previous code wires every time the tab is selected)
            if (!_calendarWired)
            {
                fisioKHCalendar1.RequestDataAsync += LoadCalendarDataAsync;
                fisioKHCalendar1.EventClick += MyCalendar_EventClick;
                _calendarWired = true;
            }

            bool ok = await calendar.AuthenticateAsync();

            if (ok)
                MostrarCalendario();
            else
                MessageBox.Show("No Se Puede Conectar a Google Calendar!");
        }

        private async void MostrarCalendario()
        {
            if (!EnsureCalendar())
                return;

            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await fisioKHCalendar1.ReloadDataFromFormAsync();
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.Enabled = true;
            }
        }

        private bool EnsureCalendar()
        {
            if (calendar?.Service == null)
            {
                MessageBox.Show("No Está Autenticado a Google Calendar.");
                return false;
            }
            return true;
        }

        private void ColorRows(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["ColorId"].Value == null) continue;

                string color = row.Cells["ColorId"].Value.ToString();

                switch (color)
                {
                    case "1": row.DefaultCellStyle.BackColor = Color.Lavender; break;
                    case "2": row.DefaultCellStyle.BackColor = Color.LightGreen; break;
                    case "3": row.DefaultCellStyle.BackColor = Color.MediumPurple; break;
                    case "4": row.DefaultCellStyle.BackColor = Color.LightPink; break;
                    case "5": row.DefaultCellStyle.BackColor = Color.LightYellow; break;
                    case "6": row.DefaultCellStyle.BackColor = Color.Orange; break;
                    case "7": row.DefaultCellStyle.BackColor = Color.LightBlue; break;
                    case "8": row.DefaultCellStyle.BackColor = Color.LightGray; break;
                    case "9": row.DefaultCellStyle.BackColor = Color.CornflowerBlue; break;
                    case "10": row.DefaultCellStyle.BackColor = Color.LightGreen; break;
                    case "11": row.DefaultCellStyle.BackColor = Color.LightCoral; break;
                }
            }
        }

        private void DesHabilitaTabs(Array tbs)
        {
            foreach (int n in tbs)
            {
                tabPrincipal.TabPages[n].Enabled = false;
            }
        }

        private void HabilitaTabs(Array tbs)
        {
            foreach (int n in tbs)
            {
                tabPrincipal.TabPages[n].Enabled = true;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private async Task Login()
        {
            if (!ValidateChildren())
            {
                var failedControl = GetFirstInvalidControl(this);
                if (failedControl != null)
                    failedControl.Focus();
                return;
            }

            string usuario = this.txtUsuario.Text.Trim();
            string passPin = this.txtPassPin.Text.Trim();

            this.txtPassPin.Text = "";

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Proporcione Usuario");
                this.txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passPin))
            {
                MessageBox.Show("Proporcione Password o Pin");
                this.txtPassPin.Focus();
                return;
            }

            this.btnLogin.Text = "Conectando a BD...";
            this.btnLogin.Enabled = false;

            try
            {
                using (var db = new DBHelperAsync())
                {
                    Program.UsuarioLogeado = await db.AutenticarUsuarioAsync(usuario, passPin);
                }

                if (!string.IsNullOrEmpty(Program.UsuarioLogeado.ErrorLogin))
                {
                    MessageBox.Show("Error, revisar log de errores!");
                    this.lstBoxLogs.Items.Add(Program.UsuarioLogeado.ErrorLogin);
                    this.btnLogin.Enabled = true;

                    this.txtPassPin.Focus();
                    return;
                }

                if (Program.UsuarioLogeado.Autenticado && Program.UsuarioLogeado.Activo)
                {
                    this.lstBoxLogs.Items.Add(DateTime.Now + " - Bienvenido : " + Program.UsuarioLogeado.Nombre);
                    this.Text = $"{configSettings.ObtenNombreApp} - Usuario: {Program.UsuarioLogeado.Nombre}";
                    this.txtUsuario.Enabled = false;
                    this.txtPassPin.Enabled = false;
                    this.txtPassPin.IsRequired = false;
                    this.btnLogin.Enabled = false;
                    this.btnCerrarSesion.Enabled = true;

                    if (Program.UsuarioLogeado.Nivel == 1)
                    {
                        this.btnUsuarios.Enabled = true;
                        this.btnPrecios.Enabled = true;
                        this.btnFisios.Enabled = true;
                        this.btnTratamientos.Enabled = true;
                        this.btnMetodosPago.Enabled = true;
                    }

                    HabilitaTabs(ObtentabsSeguras());
                    this.tabPrincipal.SelectedIndex = 1;
                }
                else
                {
                    if (!Program.UsuarioLogeado.Activo)
                        MessageBox.Show("Usuario no Activo!");
                    else
                        MessageBox.Show("Credenciales Invalidas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante login: " + ex.Message);
            }
            finally
            {
                this.btnLogin.Text = "Ingresar";
                Program.UsuarioLogeado.ErrorLogin = "";
            }
        }

        private void lstBoxLogs_Click(object sender, EventArgs e)
        {
            if (lstBoxLogs.SelectedItem != null)
            {
                MessageBox.Show("Se Copio Error al Portapapeles!");
                Clipboard.SetText(lstBoxLogs.SelectedItem.ToString());
            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Limpiar log?", "Pregunta: ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.lstBoxLogs.Items.Clear();
            }
        }

        private void preciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click usuarios");
        }

        private void btnTratamientos_Click(object sender, EventArgs e)
        {
            Tratamientos fm = new Tratamientos();
            fm.ShowDialog();
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            Precios fm = new Precios();
            fm.ShowDialog();
        }

        private void btnMetodosPago_Click(object sender, EventArgs e)
        {
            MetodosPago fm = new MetodosPago();
            fm.ShowDialog();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            Pacientes fm = new Pacientes();
            fm.ShowDialog();
        }

        private void btnFisios_Click(object sender, EventArgs e)
        {
            FisioTerapeutas fm = new FisioTerapeutas();
            fm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir del Sistema?", "Pregunta: ",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DesHabilitaTabs(ObtentabsSeguras());
                this.lstBoxLogs.Items.Clear();
                this.txtUsuario.Enabled = true;
                this.txtPassPin.Enabled = true;
                this.btnLogin.Enabled = true;
                this.Text = $"{configSettings.ObtenNombreApp}";
                this.btnCerrarSesion.Enabled = false;

                this.btnUsuarios.Enabled = false;
                this.btnPrecios.Enabled = false;
                this.btnFisios.Enabled = false;
                this.btnTratamientos.Enabled = false;
                this.btnMetodosPago.Enabled = false;

                Program.UsuarioLogeado.Autenticado = false;
                Program.UsuarioLogeado.Nivel = 0;
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios();
            u.ShowDialog();
        }

        private async void txtPassPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Login();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Desea Salir del Sistema?",
                "Confirmar salir!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            this.AutoValidate = AutoValidate.Disable;
            DisableValidationRecursive(this);

            this.Close();
        }

        private void DisableValidatedTextboxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is ValidatedNumericTextBox v)
                    v.SuppressValidation = true;

                if (c.HasChildren)
                    DisableValidatedTextboxes(c);
            }
        }

        private void FisioKHApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            DisableValidatedTextboxes(this);
            DisableValidationRecursive(this);
        }

        private void DisableValidationRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is ValidatedNumericTextBox v)
                    v.SuppressValidation = true;

                if (c.HasChildren)
                    DisableValidationRecursive(c);
            }
        }

        private void btnObtenerVisitasRealizadas_Click(object sender, EventArgs e)
        {
            DataSet dsmp = new DataSet();
            string dsname = "Pacientes";

            var parameters = new Dictionary<string, object>
            {
                { "@fechaInicio",this.dtpFechaInicio.Text},
                { "@fechaFin",this.dtpFechaFin.Text},
                
            };
            DBHelper sdb = new DBHelper();
            dsmp = sdb.ObtenerDatos("usp_obtenerVisitasRealizadas", dsname, parameters);


            DataTable dtp = dsmp.Tables[dsname];


            this.dgvVisitasRealizadas.Visible = false;
            this.dgvVisitasRealizadas.DataSource = dtp;



            foreach (DataGridViewColumn col in dgvVisitasRealizadas.Columns)
            { col.Visible = false; }

            dgvVisitasRealizadas.Columns["fechaCita"].Visible = true;
            dgvVisitasRealizadas.Columns["fechaCita"].HeaderText = "Cita";
            
            dgvVisitasRealizadas.Columns["Fecha Pago"].Visible = true;
            dgvVisitasRealizadas.Columns["Fecha Pago"].HeaderText = "Fecha Pago";

            dgvVisitasRealizadas.Columns["Paciente"].Visible = true;
            dgvVisitasRealizadas.Columns["Paciente"].HeaderText = "Paciente";
            
            dgvVisitasRealizadas.Columns["Fisio Terapeuta"].Visible = true;
            dgvVisitasRealizadas.Columns["Fisio Terapeuta"].HeaderText = "Fisio";          

            dgvVisitasRealizadas.Columns["Metodo Pago"].Visible = true;
            dgvVisitasRealizadas.Columns["Metodo Pago"].HeaderText = "Metodo Pago";
           
            dgvVisitasRealizadas.Columns["NombrePrecio"].Visible = true;
            dgvVisitasRealizadas.Columns["NombrePrecio"].HeaderText = "Tipo Precio";
            
            dgvVisitasRealizadas.Columns["Pagado"].Visible = true;
            dgvVisitasRealizadas.Columns["Pagado"].HeaderText = "Se Pago";
            
            dgvVisitasRealizadas.Columns["Cantidad Precio"].Visible = true;
            dgvVisitasRealizadas.Columns["Cantidad Precio"].HeaderText = "Precio";

            dgvVisitasRealizadas.Columns["Paciente Paga"].Visible = true;
            dgvVisitasRealizadas.Columns["Paciente Paga"].HeaderText = "Px Paga";

            dgvVisitasRealizadas.Columns["Cantidad Pagada"].Visible = true;
            dgvVisitasRealizadas.Columns["Cantidad Pagada"].HeaderText = "Pago";



            this.dgvVisitasRealizadas.Visible = true;

        }
    }
}

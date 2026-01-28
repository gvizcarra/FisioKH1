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

            // Calendar control
            fisioKHCalendar1.RequestDataAsync += LoadCalendarDataAsync;
            fisioKHCalendar1.EventClick += MyCalendar_EventClick;

            //DesHabilitaTabs(ObtentabsSeguras());
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
                // optional logging
                this.lstBoxLogs.Items.Add(DateTime.Now + " - Error cargando calendario: " + ex.Message);
                return null;
            }
        }

        private void MyCalendar_EventClick(object sender, FisioKHCalendar.CalendarEventKH e)
        {
            EventDetailsForm edt = new EventDetailsForm(e);
            edt.ShowDialog();
            // Fixed: show correct properties (GoogleId vs IdCita)
            //MessageBox.Show(
                //$"GoogleId: {e.Id}\n" +
                //$"Cita: {e.Title}\n" +
                //$"Fisio: {e.CodigoCita}\n" +
                //$"Inicio: {e.Start}\n" +
                //$"Fin: {e.End}\n" +
                //$"IdCita: {e.CitaID}");
        }

        private async void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name != "tbIngresos")
                return;

            // Authenticate async to avoid UI freeze
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
            // Avoid hitting Google every time (IsConnected does a network call)
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
                tabControl1.TabPages[n].Enabled = false;
            }
        }

        private void HabilitaTabs(Array tbs)
        {
            foreach (int n in tbs)
            {
                tabControl1.TabPages[n].Enabled = true;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                var failedControl = GetFirstInvalidControl(this);
                if (failedControl != null)
                    failedControl.Focus();

                MessageBox.Show("Capturar la informacion Marcada con Icono Rojo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.btnLogin.Enabled = false;
                    this.btnCerrarSesion.Enabled = true;
                    HabilitaTabs(ObtentabsSeguras());
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

                Program.UsuarioLogeado = null;
            }
        }
    }
}

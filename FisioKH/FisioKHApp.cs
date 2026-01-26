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
        GoogleCalendarService calendar = new GoogleCalendarService();


        public FisioKHApp()
        {
            InitializeComponent();

        }

        private Array ObtentabsSeguras()
        {
            Array tabsSeguras = configSettings.ObtenTabsSeguras;
            return tabsSeguras;
        }



        private static async Task<DataTable> InitStaticDataSetAsync(DataTable dt)
        {
            // Output table (Google + DB extras)
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));           // Google EventId
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Start", typeof(DateTime));
            table.Columns.Add("End", typeof(DateTime));
            table.Columns.Add("ColorId", typeof(string));

            // DB extras (from your SP)
            table.Columns.Add("idCita", typeof(long));
            table.Columns.Add("codigoCita", typeof(string));
            table.Columns.Add("realizada", typeof(bool));
            table.Columns.Add("nombreCompletoPaciente", typeof(string));
            table.Columns.Add("nombreTratamiento", typeof(string));
            table.Columns.Add("nombreFisioterapeuta", typeof(string));
            table.Columns.Add("claveEtiqueta", typeof(string));

            // Flag
            table.Columns.Add("HasDbMatch", typeof(bool));

            if (dt == null || dt.Rows.Count == 0)
                return table;

            // 1) Collect Google EventIds from incoming dt
            var eventIds = dt.AsEnumerable()
                .Select(r => r["Id"]?.ToString())
                .Where(id => !string.IsNullOrWhiteSpace(id))
                .Distinct()
                .ToList();

            // 2) Load DB rows (ONE call) using your async helper
            var db = new FisioKH.DBHelperAsync();
            var dbRows = await db.GetCitasByGoogleEventIdsAsync(eventIds).ConfigureAwait(false);

            // Map: idGoogleCalendar (EventId) -> DataRow
            var map = new Dictionary<string, DataRow>(StringComparer.Ordinal);
            if (dbRows != null && dbRows.Columns.Contains("idGoogleCalendar"))
            {
                foreach (DataRow r in dbRows.Rows)
                {
                    var key = r["idGoogleCalendar"] == DBNull.Value ? null : r["idGoogleCalendar"].ToString();
                    if (!string.IsNullOrWhiteSpace(key))
                        map[key] = r;
                }
            }

            // 3) Build final table + attach db fields by match
            foreach (DataRow row in dt.Rows)
            {
                string googleId = row["Id"]?.ToString() ?? "";

                var newRow = table.NewRow();
                newRow["Id"] = googleId;
                newRow["Title"] = row["Title"]?.ToString() ?? "";
                newRow["Start"] = Convert.ToDateTime(row["Start"]);
                newRow["End"] = Convert.ToDateTime(row["End"]);
                newRow["ColorId"] = row["ColorId"]?.ToString() ?? "";

                bool matched = false;

                if (!string.IsNullOrWhiteSpace(googleId) && map.TryGetValue(googleId, out var dbRow))
                {
                    matched = true;

                    // IMPORTANT: your SP returns idCita (NOT id)
                    CopyIfExists(newRow, "idCita", dbRow, "idCita");
                    CopyIfExists(newRow, "codigoCita", dbRow, "codigoCita");
                    CopyIfExists(newRow, "realizada", dbRow, "realizada");
                    CopyIfExists(newRow, "nombreCompletoPaciente", dbRow, "nombreCompletoPaciente");
                    CopyIfExists(newRow, "nombreTratamiento", dbRow, "nombreTratamiento");
                    CopyIfExists(newRow, "nombreFisioterapeuta", dbRow, "nombreFisioterapeuta");
                    CopyIfExists(newRow, "claveEtiqueta", dbRow, "claveEtiqueta");
                }

                newRow["HasDbMatch"] = matched;

                table.Rows.Add(newRow);
            }

            return table;
        }

        private static void CopyIfExists(DataRow target, string targetCol, DataRow src, string srcCol)
        {
            if (!src.Table.Columns.Contains(srcCol)) return;
            var v = src[srcCol];
            if (v == null || v == DBNull.Value) return;
            target[targetCol] = v;
        }

        private static DataTable InitStaticDataSet(DataTable dt)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Start", typeof(DateTime));
            table.Columns.Add("End", typeof(DateTime));
            table.Columns.Add("ColorId", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                table.Rows.Add(
                    row["Id"].ToString(),
                    row["Title"].ToString(),
                    Convert.ToDateTime(row["Start"]),   
                    Convert.ToDateTime(row["End"]),     
                    row["ColorId"].ToString()
                );
            }

            return table;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.lstBoxLogs.ContextMenuStrip = contextMenuStrip1;
            this.Text = configSettings.ObtenNombreApp;

            fisioKHCalendar1.RequestDataAsync += LoadCalendarDataAsync;

            this.fisioKHCalendar1.EventClick += MyCalendar_EventClick;
 
            //DesHabilitaTabs(ObtentabsSeguras());
        }


        private async Task<DataTable> LoadCalendarDataAsync(DateTime from, DateTime to)
        {
            if (!EnsureCalendar())
                return null;

            // 1) Get Google events (already async in your flow)
            var table = await calendar.GetEventsTableAsync(from, to);

            // 2) Match with DB using async DBHelper
            return await InitStaticDataSetAsync(table);
        }



        private void MyCalendar_EventClick(object sender, FisioKHCalendar.CalendarEventKH e)
        {
       
            MessageBox.Show($"Id: {e.NombreFisioterapeuta}\nCita: {e.Title}\nInicio: {e.Start}\nFin: {e.End}\nIdCita: {e.Id}");
        }


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int tabid = e.TabPageIndex;

            if(e.TabPage.Name.ToString()== "tbIngresos")
            {
                if (calendar.Authenticate())
                { MostrarCalendario(); }                
                else

                { MessageBox.Show("No Se Puede Conectar a Google Calendar!"); }
            }
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

            if (calendar == null || !calendar.IsConnected())
            {
                MessageBox.Show("No Esta Conectado a Google Calendar,Revisar Acceso a Red/Internet!");
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
            foreach(int n in tbs)
            {
                tabControl1.TabPages[n].Enabled = false;
            }
            
        }
        private void HabilitaTabs(Array tbs)
        {
            foreach(int n in tbs)
            {
                tabControl1.TabPages[n].Enabled = true;
            }
            
        }


        private async void btnLogin_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                // Focus first invalid field
                var failedControl = GetFirstInvalidControl(this);
                if (failedControl != null)
                    failedControl.Focus();

                MessageBox.Show("Capturar la informacion Marcada con Icono Rojo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (var db = new DBHelperAsync())  // <- constructor is called here
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
                    // MessageBox.Show("Bienvenido!", "Anuncio!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.lstBoxLogs.Items.Add(DateTime.Now.ToString()+ " - Bienvenido : "+ Program.UsuarioLogeado.Nombre);                    
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
                    { MessageBox.Show("Usuario no Activo!"); }
                    else
                    { MessageBox.Show("Credenciales Invalidas"); }
                         
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante login: " + ex.Message);
            }
            finally
            {
                // Reset button in any case
                this.btnLogin.Text = "Ingresar";

               // this.btnLogin.Enabled = true;
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
            if( (MessageBox.Show("Desea Limpiar log?","Pregunta: ",MessageBoxButtons.YesNo) == DialogResult.Yes ))
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
            if ((MessageBox.Show("Desea Salir del Sistema?", "Pregunta: ", MessageBoxButtons.YesNo) == DialogResult.Yes))
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

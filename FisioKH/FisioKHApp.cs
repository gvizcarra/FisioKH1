using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Configuration;

namespace FisioKH
{
    public partial class FisioKHApp : BaseForm
    {
        
        public FisioKHApp()
        {
            InitializeComponent();
        }

        private Array ObtentabsSeguras()
        {
            Array tabsSeguras = configSettings.ObtenTabsSeguras;
            return tabsSeguras;
        }

        private static DataTable InitStaticDataSet()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(Guid));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("StartTime", typeof(DateTime));
            table.Columns.Add("EndTime", typeof(DateTime));
            table.Columns.Add("Color", typeof(string));
            table.Columns.Add("IdCita", typeof(int)); // custom property

            Random rnd = new Random();
            string[] titles = { "Consulta", "Terapia", "Masaje", "Evaluación", "Revisión" };
            string[] colors = { "LightCoral", "LightGreen", "LightBlue", "Khaki", "Plum" };

            DateTime today = DateTime.Today;
            for (int i = 0; i < 25; i++)
            {
                int dayOffset = rnd.Next(0, 28);  // Random day in current month
                int hourStart = rnd.Next(7, 19);  // Start between 7 AM and 7 PM
                int duration = rnd.Next(1, 3);    // 1–2 hours

                table.Rows.Add(
                    Guid.NewGuid(),
                    titles[rnd.Next(titles.Length)],
                    today.AddDays(dayOffset).AddHours(hourStart),
                    today.AddDays(dayOffset).AddHours(hourStart + duration),
                    colors[rnd.Next(colors.Length)],
                    i + 1 // IdCita
                );
            }




            return table;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.lstBoxLogs.ContextMenuStrip = contextMenuStrip1;
            this.Text = configSettings.ObtenNombreApp;
            this.fisioKHCalendar1.EventClick += MyCalendar_EventClick;

            this.fisioKHCalendar1.DataSource = InitStaticDataSet();
            this.fisioKHCalendar1.RefreshCurrentView();
           // DesHabilitaTabs(ObtentabsSeguras());
        }

        private void MyCalendar_EventClick(object sender, FisioKHCalendar.CalendarEventKH e)
        {
            // Handle the event when an event is clicked in the calendar
            MessageBox.Show($"Cita: {e.Title}\nInicio: {e.StartTime}\nFin: {e.EndTime}\nIdCita: {e.IdCita}");
        }


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int tabid = e.TabPageIndex;
           
                    //MessageBox.Show("Elemento: " + e.TabPage.Name.ToString());
                   

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
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            string usuario = this.txtUsuario.Text;
            string passPin = this.txtPassPin.Text;

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

            this.btnLogin.Text = "Conectando a BD!";
            this.btnLogin.Enabled = false;

            FisioKH.SqlDatabase sqlDatabasex = new SqlDatabase();
            Program.UsuarioLogeado = sqlDatabasex.AutenticarUsuario(usuario,passPin);
            if (Program.UsuarioLogeado.ErrorLogin !="")
            {
                MessageBox.Show("Error, revisar log de errores!");
                this.lstBoxLogs.Items.Add(Program.UsuarioLogeado.ErrorLogin);
                this.btnLogin.Text = "Ingresar";
                this.btnLogin.Enabled = true;
                Program.UsuarioLogeado.ErrorLogin = "";
                this.lstBoxLogs.Focus();
                return;

            }

            if (Program.UsuarioLogeado.Autenticado && Program.UsuarioLogeado.Activo)
            {
                MessageBox.Show("Bienvenido!","Anuncio!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Text = configSettings.ObtenNombreApp + " - Usuario: "+ Program.UsuarioLogeado.Nombre;
                HabilitaTabs(ObtentabsSeguras());
                this.btnLogin.Text = "Ingresar";
                this.btnLogin.Enabled = true;
            }
            else
            {
                if (!Program.UsuarioLogeado.Activo)
                {
                    MessageBox.Show("Usuario no Activo!");
                }
                else
                    {
                        MessageBox.Show("Credenciales Invalidas");
                    }

                this.btnLogin.Text = "Ingresar";
                this.btnLogin.Enabled = true;
            }
            
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

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

       
    }
}

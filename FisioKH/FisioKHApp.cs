using System;
using System.Windows.Forms;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lstBoxLogs.ContextMenuStrip = contextMenuStrip1;
            this.Text = configSettings.ObtenNombreApp;
             
            DesHabilitaTabs(ObtentabsSeguras());
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
            Usuario usr = sqlDatabasex.AutenticarUsuario(usuario,passPin);
            if (usr.ErrorLogin !="")
            {
                MessageBox.Show("Error, revisar log de errores!");
                this.lstBoxLogs.Items.Add(usr.ErrorLogin);
                this.btnLogin.Text = "Ingresar";
                this.btnLogin.Enabled = true;
                usr.ErrorLogin = "";
                this.lstBoxLogs.Focus();
                return;

            }

            if (usr.Autenticado && usr.Activo)
            {
                MessageBox.Show("Bienvenido!","Anuncio!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Text = configSettings.ObtenNombreApp + " - Usuario: "+usr.Nombre;
                HabilitaTabs(ObtentabsSeguras());
                this.btnLogin.Text = "Ingresar";
                this.btnLogin.Enabled = true;
            }
            else
            {
                if (!usr.Activo)
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
    }
}

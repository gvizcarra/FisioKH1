using System;
using System.Windows.Forms;
using System.Linq;
using System.Configuration;

namespace FisioKH
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Array ObtentabsSeguras()
        {
            Array tabsSeguras = configSettings.ObtenTabsSeguras();
            return tabsSeguras;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.Text = configSettings.ObtenNombreApp();
             
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
            string passPin = this.txtxPassPin.Text;

            if(string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Proporcione Usuario");
                this.txtxPassPin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passPin))
            {
                MessageBox.Show("Proporcione Password o Pin");
                this.txtxPassPin.Focus();
                return;
            }
     
            FisioKH.SqlDatabase sqlDatabasex = new SqlDatabase();
            bool autenticado = sqlDatabasex.AutenticarUsuario(usuario,passPin);

            if (autenticado)
            {
                MessageBox.Show("Bienvenido!");
                this.Text = configSettings.ObtenNombreApp() + " - Usuario: "+usuario;
                HabilitaTabs(ObtentabsSeguras());
            }
            else
            { MessageBox.Show("Credenciales Invalidas"); }
            
        }
    }
}

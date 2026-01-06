using System;
using System.Windows.Forms;

namespace FisioKH
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableTabByIndex(1);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int tabid = e.TabPageIndex;
           // DisableTabByIndex(tabid);
                    MessageBox.Show("Elemento: " + e.TabPage.Name.ToString());
                   

        }


        private void DisableTabByIndex(int tabIndex)
        {
             tabControl1.TabPages[tabIndex].Enabled = false;
        }
        private void EnableTabByIndex(int tabIndex)
        {
             tabControl1.TabPages[tabIndex].Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FisioKH.SqlDatabase sqlDatabasex = new SqlDatabase();
            string x = sqlDatabasex.GetData();
            MessageBox.Show(x);
        }
    }
}

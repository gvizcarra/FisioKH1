using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using static FisioKH.FisioKHCalendar;


namespace FisioKH
{
    public partial class IngresoPaciente : BaseForm
    {
        private FisioKH.FisioKHCalendar.CalendarEventKH fce;
       

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
            Event.EndTime = dtEnd.Value;
            Event.Color = pnlColor.BackColor;*/

            DialogResult = DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.OK;
        }

     
        private void EventDetailsForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("PatientHistory");

            // Columns
            dt.Columns.Add("PatientID", typeof(int));
            dt.Columns.Add("PatientName", typeof(string));
            dt.Columns.Add("VisitDate", typeof(DateTime));
            dt.Columns.Add("Doctor", typeof(string));
            dt.Columns.Add("Diagnosis", typeof(string));
            dt.Columns.Add("Treatment", typeof(string));
            dt.Columns.Add("Prescription", typeof(string));
            dt.Columns.Add("FollowUpDate", typeof(DateTime));

            // Rows (sample data)
            dt.Rows.Add(1001, "John Carter", new DateTime(2026, 1, 5), "Dr. Smith", "Lower Back Pain", "Physical Therapy", "Ibuprofen 400mg", new DateTime(2026, 1, 20));
            dt.Rows.Add(1001, "John Carter", new DateTime(2026, 2, 2), "Dr. Smith", "Improving Mobility", "Stretching Program", "None", new DateTime(2026, 2, 28));
            dt.Rows.Add(1002, "Maria Lopez", new DateTime(2026, 1, 12), "Dr. Adams", "Neck Strain", "Manual Therapy", "Muscle Relaxant", new DateTime(2026, 1, 26));
            dt.Rows.Add(1003, "Daniel Kim", new DateTime(2026, 1, 18), "Dr. Brown", "Knee Injury", "Strength Rehab", "Ice + Rest", new DateTime(2026, 2, 15));
            dt.Rows.Add(1002, "Maria Lopez", new DateTime(2026, 2, 10), "Dr. Adams", "Follow-up Check", "Posture Exercises", "None", new DateTime(2026, 3, 10));
            dt.Rows.Add(1004, "Sophia Turner", new DateTime(2026, 3, 1), "Dr. Green", "Shoulder Pain", "Ultrasound Therapy", "Topical NSAID", new DateTime(2026, 3, 22));



            this.dgvExpediente.DataSource = dt;


            cargarGridPacientes(this.txtBuscarPacienteIngreso.Text);


            //dgvBuscarPaciente.Columns["ApellidoMaterno"].Visible = true;


            this.txtTitle.Text = fce.Id.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                col.Visible = false;

            dgvBuscarPaciente.Columns["Nombre"].Visible = true;
            dgvBuscarPaciente.Columns["ApellidoPaterno"].Visible = true;

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
    }
}

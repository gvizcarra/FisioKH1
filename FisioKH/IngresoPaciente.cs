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

            DBHelper dbh = new DBHelper();


            this.cboTratamiento.DataSource = dbh.obtenerTratamientos();
            this.cboTratamiento.DisplayMember = "nombre"; // what user sees
            this.cboTratamiento.ValueMember = "id";

            this.cboPrecio.DataSource = dbh.obtenerPrecios();
            this.cboPrecio.DisplayMember = "nombre"; // what user sees
            this.cboPrecio.ValueMember = "id";

            this.cboFisioTerapeuta.DataSource = dbh.obtenerFisios();
            this.cboFisioTerapeuta.DisplayMember = "nombre"; // what user sees
            this.cboFisioTerapeuta.ValueMember = "id";

            this.cboMetodoPago.DataSource = dbh.obtenerMetodosPago();
            this.cboMetodoPago.DisplayMember = "nombre"; // what user sees
            this.cboMetodoPago.ValueMember = "id";


            cargarGridPacientes(this.txtBuscarPacienteIngreso.Text);


            this.txtIdGoogleCalendar.Text = fce.Id.ToString();
            this.txtIdGoogleCalendar.BackColor = Color.FromArgb(fce.Color.A, fce.Color.R, fce.Color.G, fce.Color.B);
            this.txtBuscarPacienteIngreso.Text = fce.Title.ToString();
            this.txtIdCita.Text = fce.CitaID.ToString();
            this.txtIdPaciente.Text = fce.NombreFisioterapeuta.ToString();
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

            dtp.Columns.Add("Apellidos", typeof(string), "apellidoPaterno + ' ' + apellidoMaterno");

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

        private void dgvBuscarPaciente_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            DataGridViewRow gridRow = dgvBuscarPaciente.Rows[e.RowIndex];
            DataRowView drv = gridRow.DataBoundItem as DataRowView;
            if (drv == null) return;


            lblNombreCompleto.Text = (drv["Nombre"]?.ToString() ?? "") + ' ' + (drv["apellidoPaterno"]?.ToString() ?? "") + ' ' + (drv["apellidoMaterno"]?.ToString() ?? "");

            lblCelular.Text = drv["Celular"]?.ToString() ?? "";
            lblSexo.Text = drv["Sexo"]?.ToString() ?? "";
            lblEdad.Text = drv["Edad"]?.ToString() ?? "";
            lblMedicoTratante.Text = drv["MedicoTratante"]?.ToString() ?? "";
            lblFisio.Text = drv["Fisio"]?.ToString() ?? "";
            lblDob.Text = drv["FechaNacimiento"]?.ToString().Substring(0, 9) ?? "";
            txtObservaciones.Text = drv["observaciones"]?.ToString() ?? "";
            lblEmail.Text = drv["email"]?.ToString() ?? "";
            lblTipoIngreso.Text = drv["Etiqueta"]?.ToString() ?? "";
            lblCitas.Text = drv["totalCitas"]?.ToString() ?? "";
            lblIngresos.Text = drv["totalIngresos"]?.ToString() ?? "";
            lblIngresosPagados.Text = drv["totalIngresosPagados"]?.ToString() ?? "";

            txtNombrePaciente.Text = lblNombreCompleto.Text;


            SetPictureFromVarbinary(pbxPacienteIngreso, drv["Foto"]);


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
    }
}

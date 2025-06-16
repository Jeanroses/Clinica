using capa_Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClinica.Formularios
{
    public partial class frmInforme : Form
    {
        private List<Paciente> pacientes;

        public frmInforme()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            pacientes = new List<Paciente>();
        }

        private void frmInforme_Load(object sender, EventArgs e)
        {
            // Cargar los estados en el ComboBox
            cboCitas.Items.Add("Atendido");
            cboCitas.Items.Add("Cancelado");
            cboCitas.SelectedIndex = 0; 

            // Cargar los pacientes desde el archivo
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            try
            {
                string rutaArchivo = "atenciones.json";
                if (System.IO.File.Exists(rutaArchivo))
                {
                    string contenido = System.IO.File.ReadAllText(rutaArchivo);
                    pacientes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Paciente>>(contenido) ?? new List<Paciente>();
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo de atenciones.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filtrar los pacientes según el estado seleccionado
            string estadoSeleccionado = cboCitas.SelectedItem.ToString();
            var pacientesFiltrados = pacientes.Where(p => p.Estado == estadoSeleccionado).ToList();

            // Mostrar los pacientes filtrados en el DataGridView
            dgvInforme.DataSource = null;
            dgvInforme.DataSource = pacientesFiltrados;

            if (dgvInforme.Columns.Contains("Id"))
            {
                dgvInforme.Columns["Id"].Visible = false; // Ocultar columna ID si existe
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el estado seleccionado en el ComboBox
                string estadoSeleccionado = cboCitas.SelectedItem.ToString();

                // Filtrar los pacientes según el estado seleccionado
                var pacientesFiltrados = pacientes.Where(p => p.Estado == estadoSeleccionado).ToList();

                // Mostrar los pacientes filtrados en el DataGridView
                dgvInforme.DataSource = null;
                dgvInforme.DataSource = pacientesFiltrados;

                // Configurar columnas del DataGridView
                if (dgvInforme.Columns.Contains("Id"))
                {
                    dgvInforme.Columns["Id"].Visible = false; // Ocultar columna ID si existe
                }

                if (dgvInforme.Columns.Contains("Estado"))
                {
                    dgvInforme.Columns["Estado"].Visible = true; // Mostrar columna Estado
                }

                if (pacientesFiltrados.Count == 0)
                {
                    MessageBox.Show("No hay pacientes con el estado seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

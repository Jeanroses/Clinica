using capa_Datos;
using capa_Logica;
using capa_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AppClinica.Formularios
{
    public partial class frmAtenderPaciente : Form
    {
        private ColaAtencionLN colaAtencionLN;
        private List<Paciente> pacientesEnCola;
        private List<Paciente> datosCita;

        public frmAtenderPaciente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            colaAtencionLN = new ColaAtencionLN();
            pacientesEnCola = new List<Paciente>();
            datosCita = new List<Paciente>();
        }

        private void frmAtenderPaciente_Load(object sender, EventArgs e)
        {
            CargarPacientesEnCola();
            ActualizarContadores();
            DeshabilitarBotonesAtencion();
        }

        private void CargarPacientesEnCola()
        {
            try
            {
                PacienteADO pacienteADO = new PacienteADO();
                pacientesEnCola = pacienteADO.ObtenerPacientes();

                // Ordenar pacientes por prioridad y luego por orden de llegada
                pacientesEnCola = pacientesEnCola
                    .OrderByDescending(p => p.Prioridad) // Prioridad (Urgente > Media > Baja)
                    .ThenBy(p => p.Id) // Orden de llegada
                    .ToList();

                dgvDatos.DataSource = null;
                dgvDatos.DataSource = pacientesEnCola;

                if (dgvDatos.Columns.Contains("Id"))
                {
                    dgvDatos.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarContadores()
        {
            // Calcular cantidades por prioridad
            txtUrgente.Text = pacientesEnCola.Count(p => p.Prioridad == EstadoPrioridad.Urgente).ToString();
            txtMedia.Text = pacientesEnCola.Count(p => p.Prioridad == EstadoPrioridad.Media).ToString();
            txtBaja.Text = pacientesEnCola.Count(p => p.Prioridad == EstadoPrioridad.Baja).ToString();
        }
        private void btnComenzarAtencion_Click(object sender, EventArgs e)
        {
            if (pacientesEnCola.Count > 0)
            {
                var pacienteAtendido = pacientesEnCola.First();
                datosCita.Add(pacienteAtendido);
                pacientesEnCola.Remove(pacienteAtendido);

                // Mostrar datos del paciente en el panel de atención
                txtPaciente.Text = pacienteAtendido.Nombre;
                txtEdad.Text = pacienteAtendido.Edad.ToString();
                txtSintomas.Text = pacienteAtendido.Sintomas;

                CargarPacientesEnCola();
                ActualizarContadores();
                HabilitarBotonesAtencion();
            }
            else
            {
                MessageBox.Show("No hay pacientes en la cola.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (datosCita.Count > 0)
            {
                var pacienteAtendido = datosCita.First();
                MessageBox.Show($"Paciente atendido: {pacienteAtendido.Nombre}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Remover paciente de datos de cita
                datosCita.Remove(pacienteAtendido);

                // Deshabilitar botones si no hay más pacientes
                if (datosCita.Count == 0)
                {
                    DeshabilitarBotonesAtencion();
                }
            }
            else
            {
                MessageBox.Show("No hay pacientes en atención.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (datosCita.Count > 0)
            {
                var pacienteCancelado = datosCita.First();
                MessageBox.Show($"Atención cancelada para: {pacienteCancelado.Nombre}", "Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Remover paciente de datos de cita y devolverlo a la cola
                datosCita.Remove(pacienteCancelado);
                pacientesEnCola.Add(pacienteCancelado);

                // Actualizar DataGridView y contadores
                CargarPacientesEnCola();
                ActualizarContadores();

                // Deshabilitar botones si no hay más pacientes
                if (datosCita.Count == 0)
                {
                    DeshabilitarBotonesAtencion();
                }
            }
            else
            {
                MessageBox.Show("No hay pacientes en atención.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HabilitarBotonesAtencion()
        {
            btnAtender.Enabled = true;
            btnCancelar.Enabled = true;
            btnFinalizarAtencion.Enabled = true;
        }

        private void DeshabilitarBotonesAtencion()
        {
            btnAtender.Enabled = false;
            btnCancelar.Enabled = false;
            btnFinalizarAtencion.Enabled = false;
        }

        private void btnFinalizarAtencion_Click(object sender, EventArgs e)
        {
            if (datosCita.Count > 0)
            {
                var pacienteAtendido = datosCita.First();
                datosCita.Remove(pacienteAtendido);

                MessageBox.Show($"Atención finalizada para: {pacienteAtendido.Nombre}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar panel de atención
                txtPaciente.Text = string.Empty;
                txtEdad.Text = string.Empty;
                txtSintomas.Text = string.Empty;

                DeshabilitarBotonesAtencion();
            }
            else
            {
                MessageBox.Show("No hay pacientes en atención.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
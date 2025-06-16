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

                // Filtrar pacientes que ya fueron atendidos
                string rutaArchivo = "atenciones.json";
                if (System.IO.File.Exists(rutaArchivo))
                {
                    string contenido = System.IO.File.ReadAllText(rutaArchivo);
                    var pacientesAtendidos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Paciente>>(contenido) ?? new List<Paciente>();
                    pacientesEnCola = pacientesEnCola.Where(p => !pacientesAtendidos.Any(a => a.Id == p.Id)).ToList();
                }

                // Ordenar pacientes por prioridad (Urgente > Media > Baja) y luego por orden de llegada
                pacientesEnCola = pacientesEnCola
                    .OrderByDescending(p => p.Prioridad) // Prioridad (Urgente > Media > Baja)
                    .ThenBy(p => p.Id) // Orden de llegada
                    .ToList();

                // Actualizar el DataGridView
                dgvDatos.DataSource = null;
                dgvDatos.DataSource = pacientesEnCola;

                if (dgvDatos.Columns.Contains("Id"))
                {
                    dgvDatos.Columns["Id"].Visible = false; // Ocultar columna ID si existe
                }

                if (dgvDatos.Columns.Contains("Estado"))
                {
                    dgvDatos.Columns["Estado"].Visible = true; // Mostrar columna Estado
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarContadores()
        {
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

                // Registrar como "Atendido"
                RegistrarAtencionEnArchivo(pacienteAtendido, "Atendido");

                // Deshabilitar los botones "Cancelar" y "Atender"
                btnCancelar.Enabled = false;
                btnAtender.Enabled = false;

                // Habilitar el botón "Finalizar Atención"
                btnFinalizarAtencion.Enabled = true;
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

                // Registrar como "Cancelado"
                RegistrarAtencionEnArchivo(pacienteCancelado, "Cancelado");

                // Remover paciente de datos de cita
                datosCita.Remove(pacienteCancelado);

                // Actualizar la cola y cargar el siguiente paciente
                if (pacientesEnCola.Count > 0)
                {
                    var siguientePaciente = pacientesEnCola.First();
                    datosCita.Add(siguientePaciente);
                    pacientesEnCola.Remove(siguientePaciente);

                    // Mostrar datos del siguiente paciente en el panel de atención
                    txtPaciente.Text = siguientePaciente.Nombre;
                    txtEdad.Text = siguientePaciente.Edad.ToString();
                    txtSintomas.Text = siguientePaciente.Sintomas;
                }
                else
                {
                    // Limpiar panel de atención si no hay más pacientes
                    txtPaciente.Text = string.Empty;
                    txtEdad.Text = string.Empty;
                    txtSintomas.Text = string.Empty;
                }

                // Actualizar DataGridView y contadores
                CargarPacientesEnCola();
                ActualizarContadores();

                // Deshabilitar el botón "Cancelar" y "Atender"
                btnCancelar.Enabled = false;
                btnAtender.Enabled = false;

                // Habilitar solo el botón "Finalizar Atención"
                btnFinalizarAtencion.Enabled = true;

                // Deshabilitar botones si no hay más pacientes en atención
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

        private void RegistrarAtencionEnArchivo(Paciente paciente, string estado)
        {
            try
            {
                string rutaArchivo = "atenciones.json";
                List<Paciente> atenciones = new List<Paciente>();

                // Leer archivo existente
                if (System.IO.File.Exists(rutaArchivo))
                {
                    string contenido = System.IO.File.ReadAllText(rutaArchivo);
                    atenciones = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Paciente>>(contenido) ?? new List<Paciente>();
                }

                // Asignar estado al paciente
                paciente.Estado = estado;

                // Agregar nueva atención
                atenciones.Add(paciente);

                // Guardar en archivo
                string nuevoContenido = Newtonsoft.Json.JsonConvert.SerializeObject(atenciones, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(rutaArchivo, nuevoContenido);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar atención: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnFinalizarAtencion_Click(object sender, EventArgs e)
        {
            if (datosCita.Count > 0)
            {
                var pacienteAtendido = datosCita.First();
                datosCita.Remove(pacienteAtendido);

                // Registrar atención en archivo con el estado "Finalizado"
                RegistrarAtencionEnArchivo(pacienteAtendido, "Finalizado");

                MessageBox.Show($"Atención finalizada para: {pacienteAtendido.Nombre}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar panel de atención
                txtPaciente.Text = string.Empty;
                txtEdad.Text = string.Empty;
                txtSintomas.Text = string.Empty;

                // Actualizar la cola y contadores
                CargarPacientesEnCola();
                ActualizarContadores();

                // Deshabilitar botones si no hay más pacientes
                if (pacientesEnCola.Count == 0)
                {
                    DeshabilitarBotonesAtencion();
                }
            }
            else
            {
                MessageBox.Show("No hay pacientes en atención.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
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
        private System.Windows.Forms.Timer timer;
        private int tiempoRestante;

        public frmAtenderPaciente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            colaAtencionLN = new ColaAtencionLN();
            pacientesEnCola = new List<Paciente>();
            datosCita = new List<Paciente>();

           
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000; 
            timer.Tick += Timer_Tick;
        }

        private void frmAtenderPaciente_Load(object sender, EventArgs e)
        {
            CargarPacientesEnCola();
            ActualizarContadores();
            DeshabilitarBotonesAtencion();

           
            tiempoRestante = pacientesEnCola.Count * 10; // 10 minutos por paciente
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante--; // Reducir el tiempo restante
                lblTiempoEstimado.Text = $"Tiempo estimado de espera: {tiempoRestante} minutos";
            }
            else
            {
                timer.Stop(); // Detener el temporizador si el tiempo llega a 0
                lblTiempoEstimado.Text = "No hay pacientes en espera.";
            }
        }

        private void CargarPacientesEnCola()
        {
            try
            {
                PacienteADO pacienteADO = new PacienteADO();
                pacientesEnCola = pacienteADO.ObtenerPacientes();

             
                string rutaArchivo = "atenciones.json";
                if (System.IO.File.Exists(rutaArchivo))
                {
                    string contenido = System.IO.File.ReadAllText(rutaArchivo);
                    var pacientesAtendidos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Paciente>>(contenido) ?? new List<Paciente>();
                    pacientesEnCola = pacientesEnCola.Where(p => !pacientesAtendidos.Any(a => a.Id == p.Id)).ToList();
                }

                
                pacientesEnCola = pacientesEnCola
                    .OrderByDescending(p => p.Prioridad)
                    .ThenBy(p => p.Id)
                    .ToList();

               
                dgvDatos.DataSource = null;
                dgvDatos.DataSource = pacientesEnCola;

                if (dgvDatos.Columns.Contains("Id"))
                {
                    dgvDatos.Columns["Id"].Visible = false;
                }

                if (dgvDatos.Columns.Contains("Estado"))
                {
                    dgvDatos.Columns["Estado"].Visible = true;
                }

                
                ActualizarTiempoEstimado();
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

        private void ActualizarTiempoEstimado()
        {
            tiempoRestante = pacientesEnCola.Count * 10; 
            lblTiempoEstimado.Text = $"Tiempo estimado de espera: {tiempoRestante} minutos";
        }

        private void btnComenzarAtencion_Click(object sender, EventArgs e)
        {
            if (pacientesEnCola.Count > 0)
            {
                var pacienteAtendido = pacientesEnCola.First();
                datosCita.Add(pacienteAtendido);
                pacientesEnCola.Remove(pacienteAtendido);

               
                txtPaciente.Text = pacienteAtendido.Nombre;
                txtEdad.Text = pacienteAtendido.Edad.ToString();
                txtSintomas.Text = pacienteAtendido.Sintomas;

                CargarPacientesEnCola();
                ActualizarContadores();
                ActualizarTiempoEstimado(); 
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

                RegistrarAtencionEnArchivo(pacienteAtendido, "Atendido");

                btnCancelar.Enabled = false;
                btnAtender.Enabled = false;

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

                RegistrarAtencionEnArchivo(pacienteCancelado, "Cancelado");

                datosCita.Remove(pacienteCancelado);

                if (pacientesEnCola.Count > 0)
                {
                    var siguientePaciente = pacientesEnCola.First();
                    datosCita.Add(siguientePaciente);
                    pacientesEnCola.Remove(siguientePaciente);

                    txtPaciente.Text = siguientePaciente.Nombre;
                    txtEdad.Text = siguientePaciente.Edad.ToString();
                    txtSintomas.Text = siguientePaciente.Sintomas;
                }
                else
                {
                    // Limpiar panel
                    txtPaciente.Text = string.Empty;
                    txtEdad.Text = string.Empty;
                    txtSintomas.Text = string.Empty;
                }

                // Actualizar DataGridView y contadores
                CargarPacientesEnCola();
                ActualizarContadores();

                btnCancelar.Enabled = false;
                btnAtender.Enabled = false;

                btnFinalizarAtencion.Enabled = true;

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

                
                RegistrarAtencionEnArchivo(pacienteAtendido, "Finalizado");

                MessageBox.Show($"Atención finalizada para: {pacienteAtendido.Nombre}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                txtPaciente.Text = string.Empty;
                txtEdad.Text = string.Empty;
                txtSintomas.Text = string.Empty;

                // Actualizar la cola y contadores
                CargarPacientesEnCola();
                ActualizarContadores();

                
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
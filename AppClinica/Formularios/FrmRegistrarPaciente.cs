using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_Logica;
using capa_Modelo;
using capa_Datos;

namespace AppClinica.Formularios
{
    public partial class FrmRegistrarPaciente : Form
    {
        private PacienteADO pacienteADO;

        public FrmRegistrarPaciente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
            pacienteADO = new PacienteADO();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar los campos
                if (string.IsNullOrWhiteSpace(txtNombres.Text))
                {
                    MessageBox.Show("El nombre del paciente es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0)
                {
                    MessageBox.Show("La edad debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSintoma.Text))
                {
                    MessageBox.Show("Los síntomas son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear el objeto Paciente
                Paciente nuevoPaciente = new Paciente
                {
                    Id = pacienteADO.ObtenerPacientes().Count + 1, 
                    Nombre = txtNombres.Text.Trim(),
                    Edad = edad,
                    Sintomas = txtSintoma.Text.Trim()
                };

                // Asignar la prioridad correcta
                PacienteLN pacienteLN = new PacienteLN();
                pacienteLN.AsignarPrioridad(nuevoPaciente);

                // Guardar el paciente en el archivo JSON
                pacienteADO.CrearPaciente(nuevoPaciente);

                MessageBox.Show($"Paciente {nuevoPaciente.Nombre} registrado exitosamente con prioridad {nuevoPaciente.Prioridad}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtNombres.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtSintoma.Text = string.Empty;
        }

        private void FrmRegistrarPaciente_Load(object sender, EventArgs e)
        {

        }
    }
}

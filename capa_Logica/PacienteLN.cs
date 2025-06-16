using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_Modelo;

namespace capa_Logica
{
    public class PacienteLN
    {
        private PriorityQueue<Paciente, EstadoPrioridad> colaAtencion;

        public PacienteLN()
        {
            colaAtencion = new PriorityQueue<Paciente, EstadoPrioridad>();
        }

        // Asignar prioridad con manejo de errores
        public void AsignarPrioridad(Paciente paciente)
        {
            try
            {
                if (string.IsNullOrEmpty(paciente.Sintomas))
                {
                    Console.WriteLine($"El paciente {paciente.Nombre} no tiene síntomas especificados.");
                    paciente.Prioridad = EstadoPrioridad.Baja; // Asignar prioridad baja por defecto
                    return;
                }

                if (paciente.Sintomas.ToLower().Contains("Fiebre alta") ||
                    paciente.Sintomas.ToLower().Contains("Sangrado") ||
                    paciente.Sintomas.ToLower().Contains("Convulsiones"))
                {
                    paciente.Prioridad = EstadoPrioridad.Urgente;
                }
                else if (paciente.Sintomas.ToLower().Contains("Fiebre leve") ||
                         paciente.Sintomas.ToLower().Contains("Dolor fuerte"))
                {
                    paciente.Prioridad = EstadoPrioridad.Media;
                }
                else
                {
                    paciente.Prioridad = EstadoPrioridad.Baja;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asignar prioridad al paciente {paciente.Nombre}: {ex.Message}");
            }
        }

        // Agregar paciente a la cola con manejo de errores
        public void AgregarPaciente(Paciente paciente)
        {
            try
            {
                AsignarPrioridad(paciente);
                colaAtencion.Enqueue(paciente, paciente.Prioridad); // Añade el paciente a la cola de atención
                Console.WriteLine($"Paciente {paciente.Nombre} agregado a la cola con prioridad {paciente.Prioridad}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar paciente {paciente.Nombre} a la cola: {ex.Message}");
            }
        }

        // Gestionar la cola de atención con manejo de errores
        public void GestionarCola()
        {
            try
            {
                if (colaAtencion.Count > 0)
                {
                    var paciente = colaAtencion.Dequeue(); // El paciente con mayor prioridad es atendido
                    Console.WriteLine($"Paciente atendido: {paciente.Nombre} con prioridad {paciente.Prioridad}");
                }
                else
                {
                    Console.WriteLine("No hay pacientes en espera.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al gestionar la cola de atención: {ex.Message}");
            }
        }

        // Cancelación de turno con manejo de errores
        public void CancelarTurno(int idPaciente)
        {
            try
            {
                List<Paciente> pacientesTemp = new List<Paciente>();

                // Extraer los pacientes de la cola en una lista temporal
                while (colaAtencion.Count > 0)
                {
                    pacientesTemp.Add(colaAtencion.Dequeue());
                }

                var pacienteCancelado = pacientesTemp.Find(p => p.Id == idPaciente);
                if (pacienteCancelado != null)
                {
                    Console.WriteLine($"El paciente {pacienteCancelado.Nombre} ha cancelado su cita.");
                }

                // Volver a agregar los pacientes restantes a la cola
                foreach (var paciente in pacientesTemp)
                {
                    if (paciente != pacienteCancelado)
                    {
                        colaAtencion.Enqueue(paciente, paciente.Prioridad);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cancelar turno para el paciente {idPaciente}: {ex.Message}");
            }
        }
    }
}

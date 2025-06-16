using capa_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_Logica
{
    public class ColaAtencionLN
    {
        private PriorityQueue<Paciente, EstadoPrioridad> colaAtencion;

        public ColaAtencionLN()
        {
            // Inicializamos la cola de atención con PriorityQueue
            colaAtencion = new PriorityQueue<Paciente, EstadoPrioridad>();
        }

        // Agregar un paciente a la cola de atención según su prioridad
        public void AgregarPaciente(Paciente paciente)
        {
            try
            {
                // Asignamos prioridad y luego agregamos a la cola
                PacienteLN pacienteLN = new PacienteLN();
                pacienteLN.AsignarPrioridad(paciente);
                colaAtencion.Enqueue(paciente, paciente.Prioridad); // Usamos PriorityQueue (Heap) para insertar según la prioridad
                Console.WriteLine($"Paciente {paciente.Nombre} agregado a la cola con prioridad {paciente.Prioridad}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar paciente a la cola: {ex.Message}");
            }
        }

        // Gestionar la cola de atención y reasignar cuando un paciente se atiende
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

        // Cancelación de un paciente de la cola
        public void CancelarTurno(int idPaciente)
        {
            try
            {
                // Crear una lista temporal para manipular los pacientes
                List<Paciente> pacientesTemp = new List<Paciente>();

                // Extraer los pacientes de la cola en una lista temporal
                while (colaAtencion.Count > 0)
                {
                    pacientesTemp.Add(colaAtencion.Dequeue());
                }

                // Buscar y eliminar el paciente cancelado
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

        // Ver el estado actual de la cola
        public void VerColaDeAtencion()
        {
            try
            {
                Console.WriteLine("Estado actual de la cola de atención:");
                foreach (var paciente in colaAtencion.UnorderedItems)
                {
                    Console.WriteLine($"Paciente: {paciente.Element.Nombre}, Prioridad: {paciente.Priority}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ver la cola de atención: {ex.Message}");
            }
        }
    }
}

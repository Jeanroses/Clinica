using capa_Modelo;
using System;
using System.Collections.Generic;

namespace capa_Logica
{
    public class ColaAtencionLN
    {
        private PriorityQueue<Paciente, EstadoPrioridad> colaAtencion;

        public ColaAtencionLN()
        {
            colaAtencion = new PriorityQueue<Paciente, EstadoPrioridad>();
        }

        // Se agrega al paciente a la cola de atención con su prioridad asignada
        public void AgregarPaciente(Paciente paciente)
        {
            try
            {
                PacienteLN pacienteLN = new PacienteLN();
                pacienteLN.AsignarPrioridad(paciente);
                colaAtencion.Enqueue(paciente, paciente.Prioridad);
                Console.WriteLine($"Paciente {paciente.Nombre} agregado con prioridad {paciente.Prioridad}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar paciente: {ex.Message}");
            }
        }

        // Gestion de la cola de atención
        public void GestionarCola()
        {
            try
            {
                if (colaAtencion.Count > 0)
                {
                    var paciente = colaAtencion.Dequeue();
                    Console.WriteLine($"Paciente atendido: {paciente.Nombre} con prioridad {paciente.Prioridad}");
                }
                else
                {
                    Console.WriteLine("No hay pacientes en espera.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al gestionar la cola: {ex.Message}");
            }
        }

        // Se cancela el turno de un paciente específico
        public void CancelarTurno(int idPaciente)
        {
            try
            {
                List<Paciente> pacientesTemp = new List<Paciente>();
                while (colaAtencion.Count > 0)
                {
                    pacientesTemp.Add(colaAtencion.Dequeue());
                }

                var pacienteCancelado = pacientesTemp.Find(p => p.Id == idPaciente);
                if (pacienteCancelado != null)
                {
                    Console.WriteLine($"Paciente {pacienteCancelado.Nombre} canceló su cita.");
                }

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
                Console.WriteLine($"Error al cancelar turno: {ex.Message}");
            }
        }

        // Ver el estado actual de la cola de atención
        public void VerColaDeAtencion()
        {
            try
            {
                Console.WriteLine("Estado actual de la cola:");
                foreach (var paciente in colaAtencion.UnorderedItems)
                {
                    Console.WriteLine($"Paciente: {paciente.Element.Nombre}, Prioridad: {paciente.Priority}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ver la cola: {ex.Message}");
            }
        }

      public List<Paciente> ObtenerPacientesOrdenadosPorPrioridad()
{
    try
    {
        // Extraer los pacientes de la cola y ordenarlos por prioridad
        var pacientesOrdenados = colaAtencion.UnorderedItems
            .OrderByDescending(p => p.Priority) 
            .Select(p => p.Element) 
            .ToList();

        return pacientesOrdenados;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al obtener pacientes ordenados por prioridad: {ex.Message}");
        return new List<Paciente>(); 
    }
}
    }
}
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
    }
}
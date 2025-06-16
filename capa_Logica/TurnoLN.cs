using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_Modelo;

namespace capa_Logica
{
    public class TurnoLN
    {
        private List<Turno> turnos;

        public TurnoLN()
        {
            turnos = new List<Turno>();
        }

        // Asigna un turno a un paciente según su prioridad
        public void AsignarTurno(Paciente paciente)
        {
            try
            {
                Turno nuevoTurno = new Turno
                {
                    Id = turnos.Count + 1, // Incrementa el ID del turno
                    Prioridad = paciente.Prioridad,
                    EstaActivo = true
                };

                turnos.Add(nuevoTurno);
                Console.WriteLine($"Turno asignado a {paciente.Nombre} con prioridad {paciente.Prioridad}. Turno ID: {nuevoTurno.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asignar turno a {paciente.Nombre}: {ex.Message}");
            }
        }

        // Obtener todos los turnos activos
        public List<Turno> ObtenerTurnosActivos()
        {
            try
            {
                return turnos.FindAll(t => t.EstaActivo); // Filtra solo los turnos activos
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener turnos activos: {ex.Message}");
                return new List<Turno>(); // Retorna una lista vacía en caso de error
            }
        }

        // Cancelar un turno
        public void CancelarTurno(int idTurno)
        {
            try
            {
                var turno = turnos.Find(t => t.Id == idTurno);
                if (turno != null)
                {
                    turno.EstaActivo = false;
                    Console.WriteLine($"El turno {idTurno} ha sido cancelado.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el turno con ID: {idTurno}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cancelar turno: {ex.Message}");
            }
        }
    }
}

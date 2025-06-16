using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using capa_Modelo;  
using capa_Logica; 

namespace capa_Datos
{
    public class TurnoADO
    {
        private string filePath = "turnos.json";  

        
        public void CrearTurno(Turno turno, int pacienteId)
        {
            List<Turno> turnos = ObtenerTurnos(); 

            turno.Id = turnos.Count + 1;  
            turnos.Add(turno);  

            try
            {
                // Serializar la lista de turnos a formato JSON
                string json = JsonConvert.SerializeObject(turnos, Formatting.Indented);

                // Guardar los datos en el archivo JSON
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Turno asignado y guardado en el archivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el turno: {ex.Message}");
            }
        }

        // Obtener todos los turnos desde el archivo JSON
        public List<Turno> ObtenerTurnos()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);  // Leer el contenido del archivo
                    return JsonConvert.DeserializeObject<List<Turno>>(json) ?? new List<Turno>();  // Deserializar el JSON a lista de turnos
                }
                return new List<Turno>();  // Si no existe el archivo, retornamos una lista vacía
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener turnos: {ex.Message}");
                return new List<Turno>();
            }
        }

        // Actualizar un turno en el archivo JSON
        public void ActualizarTurno(Turno turno)
        {
            List<Turno> turnos = ObtenerTurnos();

            // Buscar el turno y actualizarlo
            var turnoExistente = turnos.Find(t => t.Id == turno.Id);
            if (turnoExistente != null)
            {
                turnoExistente.Prioridad = turno.Prioridad;
                turnoExistente.EstaActivo = turno.EstaActivo;

                // Guardar la lista actualizada de turnos en el archivo
                GuardarTurnos(turnos);
                Console.WriteLine($"Turno con ID {turno.Id} actualizado.");
            }
            else
            {
                Console.WriteLine($"Turno con ID {turno.Id} no encontrado.");
            }
        }

        // Eliminar un turno del archivo JSON
        public void EliminarTurno(int idTurno)
        {
            List<Turno> turnos = ObtenerTurnos();

            // Buscar el turno a eliminar
            var turnoEliminado = turnos.Find(t => t.Id == idTurno);
            if (turnoEliminado != null)
            {
                turnos.Remove(turnoEliminado);  
                GuardarTurnos(turnos);  
                Console.WriteLine($"Turno con ID {idTurno} eliminado.");
            }
            else
            {
                Console.WriteLine($"Turno con ID {idTurno} no encontrado.");
            }
        }

        // Guardar la lista de turnos en el archivo JSON
        private void GuardarTurnos(List<Turno> turnos)
        {
            try
            {
                string json = JsonConvert.SerializeObject(turnos, Formatting.Indented);  // Serializar la lista a JSON
                File.WriteAllText(filePath, json);  // Guardar el JSON en el archivo
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar turnos: {ex.Message}");
            }
        }
    }
}

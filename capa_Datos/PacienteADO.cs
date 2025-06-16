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
    public class PacienteADO
    {
        private string filePath = "pacientes.json";  

       
        public void CrearPaciente(Paciente paciente)
        {
            
            List<Paciente> pacientes = ObtenerPacientes();  

            pacientes.Add(paciente);  

            try
            {
                // Serializar la lista de pacientes a formato JSON
                string json = JsonConvert.SerializeObject(pacientes, Formatting.Indented);

                // Guardar los datos en el archivo JSON
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Paciente {paciente.Nombre} creado y guardado en el archivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el paciente: {ex.Message}");
            }
        }

        // Obtener todos los pacientes desde el archivo JSON
        public List<Paciente> ObtenerPacientes()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath); // Leer el contenido del archivo
                    return JsonConvert.DeserializeObject<List<Paciente>>(json) ?? new List<Paciente>(); // Deserializar el JSON a lista de pacientes
                }
                return new List<Paciente>(); // Si no existe el archivo, retornamos una lista vacía
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener pacientes: {ex.Message}");
                return new List<Paciente>();
            }
        }
        // Actualizar los datos de un paciente en el archivo JSON
        public void ActualizarPaciente(Paciente paciente)
        {
            List<Paciente> pacientes = ObtenerPacientes();

            // Buscar el paciente y actualizarlo
            var pacienteExistente = pacientes.Find(p => p.Id == paciente.Id);
            if (pacienteExistente != null)
            {
                pacienteExistente.Nombre = paciente.Nombre;
                pacienteExistente.Edad = paciente.Edad;
                pacienteExistente.Sintomas = paciente.Sintomas;
                pacienteExistente.Prioridad = paciente.Prioridad;

                // Guardar la lista actualizada de pacientes en el archivo
                GuardarPacientes(pacientes);
                Console.WriteLine($"Paciente {paciente.Nombre} actualizado.");
            }
            else
            {
                Console.WriteLine($"Paciente con ID {paciente.Id} no encontrado.");
            }
        }

        // Eliminar un paciente del archivo JSON
        public void EliminarPaciente(int idPaciente)
        {
            List<Paciente> pacientes = ObtenerPacientes();

            // Buscar el paciente a eliminar
            var pacienteEliminado = pacientes.Find(p => p.Id == idPaciente);
            if (pacienteEliminado != null)
            {
                pacientes.Remove(pacienteEliminado);  // Eliminar el paciente de la lista
                GuardarPacientes(pacientes);  // Guardar la lista actualizada en el archivo
                Console.WriteLine($"Paciente {pacienteEliminado.Nombre} eliminado.");
            }
            else
            {
                Console.WriteLine($"Paciente con ID {idPaciente} no encontrado.");
            }
        }

        // Guardar la lista de pacientes en el archivo JSON
        private void GuardarPacientes(List<Paciente> pacientes)
        {
            try
            {
                string json = JsonConvert.SerializeObject(pacientes, Formatting.Indented);  // Serializar la lista a JSON
                File.WriteAllText(filePath, json);  // Guardar el JSON en el archivo
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar pacientes: {ex.Message}");
            }
        }
    }
}

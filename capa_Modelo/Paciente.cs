using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_Modelo
{
    public class Paciente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public string? Sintomas { get; set; }
        public EstadoPrioridad Prioridad { get; set; }
    }
}

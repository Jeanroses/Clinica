using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_Modelo
{
    public class Turno
    {
        public int Id { get; set; }
        public EstadoPrioridad Prioridad { get; set; }
        public bool EstaActivo { get; set; }
    }
}

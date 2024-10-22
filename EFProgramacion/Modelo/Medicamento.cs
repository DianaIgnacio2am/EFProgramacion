using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProgramacion.Modelo
{
    public class Medicamento
    {
        public int Id { get; set; } // Clave primaria
        public string Nombre { get; set; } // Nombre del medicamento
        public int DrogueriaId { get; set; } // Clave foránea a Droguería

        // Navegación a la entidad Droguería
        public Drogueria Drogueria { get; set; }
    }
}

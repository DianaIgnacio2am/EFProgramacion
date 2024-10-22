using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProgramacion.Modelo
{
    public class Drogueria
    {
        public int Id { get; set; } // Clave primaria
        public string Nombre { get; set; } // Nombre de la droguería

        // Relación uno a muchos con Medicamento
        public ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>(); // Inicializa la colección
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mod5Core.Models
{
    public class ColeccionDeRecursos<T>: Recurso where T:Recurso
    {
        public List<T> Valores { get; set; }
        public ColeccionDeRecursos(List<T> valores)
        {
            Valores = valores;
        }

    }
}

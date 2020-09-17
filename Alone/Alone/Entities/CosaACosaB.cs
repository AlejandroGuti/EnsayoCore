using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone.Entities
{
    public class CosaACosaB
    {
        public int id { get; set; }
        public int CosaId { get; set; }
        public int CosaBId { get; set; }
        public int Cantidad { get; set; }
        public Cosa CosaA { get; set; }
        public CosaB CosaB { get; set; }
    }
}

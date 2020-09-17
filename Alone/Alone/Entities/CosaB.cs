using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone.Entities
{
    public class CosaB
    {
        public int id { get; set; }
        public string NameB { get; set; }
        public int TotalB { get; set; }
        public List<CosaACosaB> CosaACosaB { get; set; }
    }
}

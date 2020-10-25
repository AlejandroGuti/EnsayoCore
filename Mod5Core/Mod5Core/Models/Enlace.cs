using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mod5Core.Models
{
    public class Enlace
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }

        public Enlace(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}

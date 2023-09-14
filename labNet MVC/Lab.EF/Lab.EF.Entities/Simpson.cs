using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Entities
{
    public class Simpson
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Historia { get; set; }
        public Uri Imagen { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }
        public string Ocupacion { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

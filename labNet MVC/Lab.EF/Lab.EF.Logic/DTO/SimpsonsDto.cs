﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.DTO
{
    public class SimpsonsDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Historia { get; set; }
        public string Imagen { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }
        public string Ocupacion { get; set; }
        public string UpdatedAt { get; set; }
    }
}

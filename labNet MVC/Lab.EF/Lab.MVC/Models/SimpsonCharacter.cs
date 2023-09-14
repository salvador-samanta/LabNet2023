using Lab.EF.Logic.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models
{
    public class ResponseContainer
    {
        public List<SimpsonView> Docs { get; set; }
    }
    public class SimpsonView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Historia { get; set; }
        public Uri Imagen { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }
        public string Ocupacion { get; set; }
        public string UpdatedAt { get; set; }
    }
}
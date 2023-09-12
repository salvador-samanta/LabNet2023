using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Lab.MVC.Models
{
    public class ShippersView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la compañía es obligatorio.")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "El nombre de la compañía debe tener entre 2 y 40 caracteres.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [RegularExpression(@"^[0-9()+\- ]+$", ErrorMessage = "Sólo se permiten números, (), + y -.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        public bool IsInsert { get; set; }
    }
}
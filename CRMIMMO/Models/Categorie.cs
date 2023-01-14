using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMIMMO.Models
{
    public class Categorie
    {
        [Required]
        [Key]
        public int CategorieId { get; set; }

        [Required]
        [Display(Name = "Nom de categorie :")]
        public string Nom_categorie { get; set; }

    }
}
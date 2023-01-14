using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMIMMO.Models
{
    public class Immobilier
    {
        [Required]
        [Display(Name = "ID Immobilier")]
        [Key]
        public string ImmobilierId { get; set; }
        [Required]
        [Display(Name = "Type Immobilier ")]
        public string typeImmobilierr { get; set; }

        [Required]
        [Display(Name = "Local Immobilier ")]
        public string localimmobilier { get; set; }

        [Required]
        [Display(Name = "Surface du l'immobilier ")]
        public Double surfaceimmobilier { get; set; }

        [Required]
        [Display(Name = "Prix ")]
        public Double prix { get; set; }
        [Required]
        [Display(Name = "Description ")]
        public String description { get; set; }
        

      
        public virtual ICollection<Categorie> Categories { get; set; }
    }
}
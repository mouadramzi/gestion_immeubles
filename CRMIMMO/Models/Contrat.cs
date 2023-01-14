using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMIMMO.Models
{
    public class Contrat
    {
        [Required]
        [Key]
        public string idcontrat { get; set; }

        [Display(Name = "Immobilier ID ")]
        public string idImmobilier { get; set; }
        [Display(Name = "Client CIN  ")]
        public string clientcin { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de contrats")]
        public DateTime datecontrat { get; set; }
        [Required]
        [Display(Name = "ID Client")]
        public string ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
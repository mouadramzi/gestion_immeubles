using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRMIMMO.Models
{
    public class CRMContext22 : DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Contrat> contrats { get; set; }
        public DbSet<Register> registers { get; set; }
        public DbSet<Log> logins { get; set; }

        public System.Data.Entity.DbSet<CRMIMMO.Models.Immobilier> Immobiliers { get; set; }

        public System.Data.Entity.DbSet<CRMIMMO.Models.Categorie> Categories { get; set; }
        
    }
}
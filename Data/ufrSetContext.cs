using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ufrSet.Models;

namespace ufrSet.Data
{
    public class ufrSetContext : DbContext
    {
        public ufrSetContext (DbContextOptions<ufrSetContext> options)
            : base(options)
        {
        }

        public DbSet<ufrSet.Models.Ufr> Ufr { get; set; } = default!;

        public DbSet<ufrSet.Models.Departement> Departement { get; set; }

        public DbSet<ufrSet.Models.Filiere> Filiere { get; set; }

        public DbSet<ufrSet.Models.Administration> Administration { get; set; }

        public DbSet<ufrSet.Models.Pers> Pers { get; set; }

   
    }
}

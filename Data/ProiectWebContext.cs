using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Models;

namespace ProiectWeb.Data
{
    public class ProiectWebContext : DbContext
    {
        public ProiectWebContext (DbContextOptions<ProiectWebContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectWeb.Models.Client> Client { get; set; }

        public DbSet<ProiectWeb.Models.Comanda> Comanda { get; set; }

        public DbSet<ProiectWeb.Models.Foodtruck> Foodtruck { get; set; }
    }
}

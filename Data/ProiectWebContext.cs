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

        public DbSet<ProiectWeb.Models.Contact> Contact { get; set; }

        public DbSet<ProiectWeb.Models.Factura> Factura { get; set; }

        public DbSet<ProiectWeb.Models.Proprietate> Proprietate { get; set; }
    }
}

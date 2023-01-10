using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Facturi
{
    public class IndexModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public IndexModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        public IList<Comanda> Comanda { get;set; }

        public async Task OnGetAsync()
        {
            Comanda = await _context.Comanda
                .Include(b => b.Client)
                .Include(c => c.Foodtruck)
                .ToListAsync();

        }
       
    }
}

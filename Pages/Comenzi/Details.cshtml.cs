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
    public class DetailsModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public DetailsModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        public Comanda Comanda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comanda = await _context.Comanda.Include(b => b.Client).Include(c => c.Foodtruck).FirstOrDefaultAsync(m => m.ID == id);


            if (Comanda == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

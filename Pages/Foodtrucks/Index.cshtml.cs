using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Foodtrucks;

public class IndexModel : PageModel
{
    private readonly ProiectWebContext _context;

    public IndexModel(ProiectWebContext context)
    {
        _context = context;
    }

    public IList<Foodtruck> Foodtruck { get; set; }

    public async Task OnGetAsync()
    {
        Foodtruck = await _context.Foodtruck.ToListAsync();
    }
}
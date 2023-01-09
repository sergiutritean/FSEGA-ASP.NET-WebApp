using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Proprietati;

public class IndexModel : PageModel
{
    private readonly ProiectWebContext _context;

    public IndexModel(ProiectWebContext context)
    {
        _context = context;
    }

    public IList<Proprietate> Proprietate { get; set; }

    public async Task OnGetAsync()
    {
        Proprietate = await _context.Proprietate.ToListAsync();
    }
}
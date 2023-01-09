using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Proprietati;

public class DetailsModel : PageModel
{
    private readonly ProiectWebContext _context;

    public DetailsModel(ProiectWebContext context)
    {
        _context = context;
    }

    public Proprietate Proprietate { get; set; }
    public Contact Contact { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        Proprietate = await _context.Proprietate.FirstOrDefaultAsync(m => m.ID == id);
        Contact = await _context.Contact.FirstOrDefaultAsync(m => m.ID == id);

        if (Proprietate == null) return NotFound();

        return Page();
    }
}
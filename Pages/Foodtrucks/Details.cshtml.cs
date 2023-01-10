using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Foodtrucks;

public class DetailsModel : PageModel
{
    private readonly ProiectWebContext _context;

    public DetailsModel(ProiectWebContext context)
    {
        _context = context;
    }

    public Foodtruck Foodtruck { get; set; }
    public Client Client { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        Foodtruck = await _context.Foodtruck.FirstOrDefaultAsync(m => m.ID == id);
        Client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);

        if (Foodtruck == null) return NotFound();

        return Page();
    }
}
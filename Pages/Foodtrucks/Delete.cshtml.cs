using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Foodtrucks;

public class DeleteModel : PageModel
{
    private readonly ProiectWebContext _context;

    public DeleteModel(ProiectWebContext context)
    {
        _context = context;
    }

    [BindProperty] public Foodtruck Foodtruck { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        Foodtruck = await _context.Foodtruck.FirstOrDefaultAsync(m => m.ID == id);

        if (Foodtruck == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        Foodtruck = await _context.Foodtruck.FindAsync(id);

        if (Foodtruck != null)
        {
            _context.Foodtruck.Remove(Foodtruck);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Foodtrucks;

public class EditModel : PageModel
{
    private readonly ProiectWebContext _context;

    public EditModel(ProiectWebContext context)
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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Foodtruck).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FoodtruckExists(Foodtruck.ID))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool FoodtruckExists(int id)
    {
        return _context.Foodtruck.Any(e => e.ID == id);
    }
}
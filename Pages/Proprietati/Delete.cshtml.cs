using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Proprietati;

public class DeleteModel : PageModel
{
    private readonly ProiectWebContext _context;

    public DeleteModel(ProiectWebContext context)
    {
        _context = context;
    }

    [BindProperty] public Proprietate Proprietate { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        Proprietate = await _context.Proprietate.FirstOrDefaultAsync(m => m.ID == id);

        if (Proprietate == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        Proprietate = await _context.Proprietate.FindAsync(id);

        if (Proprietate != null)
        {
            _context.Proprietate.Remove(Proprietate);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
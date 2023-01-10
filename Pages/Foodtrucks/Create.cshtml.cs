using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Foodtrucks;

public class CreateModel : PageModel
{
    private readonly ProiectWebContext _context;

    public CreateModel(ProiectWebContext context)
    {
        _context = context;
    }

    [BindProperty] public Foodtruck Foodtruck { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Foodtruck.Add(Foodtruck);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
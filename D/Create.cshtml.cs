using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ken_PS1.Data;

namespace Ken_PS1.Pages.D
{
    public class CreateModel : PageModel
    {
        private readonly Ken_PS1.Data.ApplicationDbContext _context;

        public CreateModel(Ken_PS1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PSID"] = new SelectList(_context.Set<PetStore>(), "PSID", "PSID");
            return Page();
        }

        [BindProperty]
        public Dogs Dogs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dogs.Add(Dogs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
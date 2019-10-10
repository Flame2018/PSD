using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ken_PS1.Data;

namespace Ken_PS1.Pages.PS
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
            return Page();
        }

        [BindProperty]
        public PetStore PetStore { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PetStore.Add(PetStore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
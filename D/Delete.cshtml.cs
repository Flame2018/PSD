using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ken_PS1.Data;

namespace Ken_PS1.Pages.D
{
    public class DeleteModel : PageModel
    {
        private readonly Ken_PS1.Data.ApplicationDbContext _context;

        public DeleteModel(Ken_PS1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dogs Dogs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dogs = await _context.Dogs
                .Include(d => d.PsID).FirstOrDefaultAsync(m => m.DID == id);

            if (Dogs == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dogs = await _context.Dogs.FindAsync(id);

            if (Dogs != null)
            {
                _context.Dogs.Remove(Dogs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

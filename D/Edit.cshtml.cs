﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ken_PS1.Data;

namespace Ken_PS1.Pages.D
{
    public class EditModel : PageModel
    {
        private readonly Ken_PS1.Data.ApplicationDbContext _context;

        public EditModel(Ken_PS1.Data.ApplicationDbContext context)
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
           ViewData["PSID"] = new SelectList(_context.Set<PetStore>(), "PSID", "PSID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogsExists(Dogs.DID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DogsExists(int id)
        {
            return _context.Dogs.Any(e => e.DID == id);
        }
    }
}

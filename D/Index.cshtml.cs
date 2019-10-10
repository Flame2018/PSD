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
    public class IndexModel : PageModel
    {
        private readonly Ken_PS1.Data.ApplicationDbContext _context;

        public IndexModel(Ken_PS1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dogs> Dogs { get;set; }

        public async Task OnGetAsync()
        {
            Dogs = await _context.Dogs
                .Include(d => d.PsID).ToListAsync();
        }
    }
}

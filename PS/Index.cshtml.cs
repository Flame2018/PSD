using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ken_PS1.Data;

namespace Ken_PS1.Pages.PS
{
    public class IndexModel : PageModel
    {
        private readonly Ken_PS1.Data.ApplicationDbContext _context;

        public IndexModel(Ken_PS1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PetStore> PetStore { get;set; }

        public async Task OnGetAsync()
        {
            PetStore = await _context.PetStore.ToListAsync();
        }
    }
}

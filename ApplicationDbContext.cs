using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ken_PS1.Data;

namespace Ken_PS1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ken_PS1.Data.Dogs> Dogs { get; set; }
        public DbSet<Ken_PS1.Data.PetStore> PetStore { get; set; }
    }
}

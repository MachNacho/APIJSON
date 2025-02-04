using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data
{
    public class ApplicationDBcontext: DbContext // Inherit DbContext
    {
        public ApplicationDBcontext(DbContextOptions dbContextOptions):base(dbContextOptions) { }// Constructor
        public DbSet<User> user {  get; set; } // Table
    }
}

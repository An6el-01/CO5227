using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlfaBookStore.model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AlfaBookStore.Data
{
    public class AlfaBookStoreContext : IdentityDbContext
    {

        public AlfaBookStoreContext (DbContextOptions<AlfaBookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Books>().ToTable("Books");
        }

    }
}

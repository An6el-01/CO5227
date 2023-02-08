using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlfaBookStore.model;

namespace AlfaBookStore.Data
{
    public class AlfaBookStoreContext : DbContext
    {
        public AlfaBookStoreContext (DbContextOptions<AlfaBookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithClasses
{
    internal class LibraryContext : DbContext
    {
        public LibraryContext() : base("name:LibraryContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LibraryContext>());
        } 
        public DbSet <Libro> Libri { get; set; }
        public DbSet <Author> Autori { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasRequired(l => l.Autore)
                .WithMany(a => a.Libri)
                .HasForeignKey(l => l.AutoreId);
            base.OnModelCreating(modelBuilder);
        }

    }
}

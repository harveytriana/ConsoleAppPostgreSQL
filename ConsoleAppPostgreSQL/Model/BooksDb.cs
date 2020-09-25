using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppPostgreSQL.Model
{
    class BooksDb : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BooksDb()
        {
           
        }

        // Sql Server
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        // postgreSql
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseNpgsql("Host=localhost;Database=BooksDb;Username=postgres;Password=Pragma$2020");
            }
        }

        // SQLite
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlite(@"Data Source=C:\_study\ConsoleAppPostgreSQL\ConsoleAppPostgreSQL\BooksDb.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity => {
                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R00");
            });
        }
    }
}

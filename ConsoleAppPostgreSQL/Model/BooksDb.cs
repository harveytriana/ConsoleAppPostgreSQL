using Microsoft.EntityFrameworkCore;

namespace ConsoleAppPostgreSQL.Model
{
    class BooksDb : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BooksDb() { }

        // Sql Server
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        // postgreSql
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured) {
        //        optionsBuilder.UseLazyLoadingProxies();
        //        optionsBuilder.UseNpgsql("Host=localhost;Database=BooksDb;Username=postgres;Password=Pragma$2020");
        //    }
        //}

        // SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlite(@"Data Source=C:\_study\Python\ConsoleAppPostgreSQL\ConsoleAppPostgreSQL\Books.db");
        }

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

using Microsoft.EntityFrameworkCore;

namespace ConsoleAppPostgreSQL.Model
{
    class BooksDb : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        // Sql Server
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        // postgreSql
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured) {
        //        optionsBuilder.UseNpgsql("Host=localhost;Database=BooksDb;Username=postgres;Password=Pragma$2020");
        //    }
        //}


        // SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                 => options.UseSqlite("Data Source=BooksDb.db");

    }
}

using DBLib.Models;
using Microsoft.EntityFrameworkCore;


namespace DBLib
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// kolekcja książek
        /// <summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// kolekcja użytkowników
        /// <summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// kolekcja kategorii
        /// <summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// kolekcja autorów
        /// <summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Pusty konstruktor
        /// <summary>
        public AppDbContext()
        {
        }
        /// <summary>
        /// Konstruktor z parametrem
        /// <summary>
        ///  /// <param name="options"></param>
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        /// <summary>
        /// Upewnia się że rekordy ksiązek mają odpowiednie relacje i klucze
        /// Upewnai się że dane są stworzone poprawnie
        /// Upewnia się o poprawnych relacjach
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(p => p.Author)
                .WithMany(b => b.AuthoredBooks)
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);
            modelBuilder.Entity<Book>()
                .Property(b => b.UserId).IsRequired(false);
        }
    }
}

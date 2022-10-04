using DBLib.Models;
using DBLib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBLib.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly AppDbContextFactory contextFactory;
        /// <summary>
        /// konstruktor przypisuje dbcontext 
        /// <summary>
        public BookService(AppDbContextFactory context) : base(context)
        {
            contextFactory = context;
        }
        /// <summary>
        /// metoda pobierająca po Id, dla książek
        /// <summary>
        public override Book GetById(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                return appConext.Books
                    .Include(b => b.Author)
                    .Include(b => b.User)
                    .Include(b => b.Category)
                    .FirstOrDefault(b => b.BookId == id);
            }
        }
        /// <summary>
        /// metoda usuwająca po Id, dla książek
        /// <summary>
        public override void RemoveById(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                var book = appConext.Books.FirstOrDefault(b => b.BookId == id);
                appConext.Books.Remove(book);
                appConext.SaveChanges();
            }
        }
        /// <summary>
        /// metoda usuwająca po Id, dla książek
        /// <summary>
        public override bool RemoveByIdStatus(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                var book = appConext.Books.FirstOrDefault(b => b.BookId == id);
                appConext.Books.Remove(book);
                appConext.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// pobierz wszystkie
        /// <summary>
        public override List<Book> GetAll()
        {
            using AppDbContext appContext = contextFactory.CreateDbContext();
            {
                var books = appContext.Books
                    .Include(b => b.Author)
                    .Include(b => b.User)
                    .Include(b => b.Category)
                    .ToList();
                return books;
            }
        }
    }
}

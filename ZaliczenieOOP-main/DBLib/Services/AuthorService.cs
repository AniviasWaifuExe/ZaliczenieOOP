using DBLib.Models;
using DBLib.Services.Interfaces;


namespace DBLib.Services
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        private readonly AppDbContextFactory contextFactory;
        /// <summary>
        /// konstruktor przypisuje dbcontext 
        /// <summary>
        public AuthorService(AppDbContextFactory context) : base(context)
        {
            contextFactory = context;
        }
        /// <summary>
        /// metoda pobierająca po Id, dla użytkowniów
        /// <summary>
        public override Author GetById(int id)
        {
            using AppDbContext appContext = contextFactory.CreateDbContext();
            {
                return appContext.Authors.FirstOrDefault(a => a.AuthorId == id);
            }
        }
        /// <summary>
        /// metoda usuwająca po Id, dla użytkowniów
        /// <summary>
        public override void RemoveById(int id)
        {
            using AppDbContext appContext = contextFactory.CreateDbContext();
            {
                var author = appContext.Authors.FirstOrDefault(a => a.AuthorId == id);
                appContext.Authors.Remove(author);
                appContext.SaveChanges();
            }
        }

        /// <summary>
        /// metoda usuwająca po Id, dla użytkowniów
        /// <summary>
        public override bool RemoveByIdStatus(int id)
        {
            using AppDbContext appContext = contextFactory.CreateDbContext();
            {
                var author = appContext.Authors.FirstOrDefault(a => a.AuthorId == id);
                var books = appContext.Books.Where(b => b.AuthorId == id);
                if (books.Count() != 0)
                {
                    return false;
                }
                appContext.Authors.Remove(author);
                appContext.SaveChanges();
                return true;

            }
        }
    }
}

using DBLib.Models;
using DBLib.Services.Interfaces;

namespace DBLib.Services
{
    /// <summary>
    /// UserService implementuje generyczny BaseMethods i pozwala nadpisywac specyficzne metody pod konkretny model
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    {
        private readonly AppDbContextFactory contextFactory;
        /// <summary>
        /// konstruktor przypisuje dbcontext 
        /// <summary>
        public UserService(AppDbContextFactory context) : base(context)
        {
            contextFactory = context;
        }
        /// <summary>
        /// metoda pobierająca po Id, dla użytkowniów
        /// <summary>
        public override User GetById(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                return appConext.Users.FirstOrDefault(b => b.UserId == id);
            }
        }
        /// <summary>
        /// metoda usuwająca po Id, dla użytkowniów
        /// <summary>
        public override void RemoveById(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                var user = appConext.Users.FirstOrDefault(b => b.UserId == id);
                appConext.Users.Remove(user);
                appConext.SaveChanges();
            }
        }
        /// <summary>
        /// metoda usuwająca po Id, dla użytkowniów
        /// <summary>
        public override bool RemoveByIdStatus(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                var user = appConext.Users.FirstOrDefault(b => b.UserId == id);
                var book = appConext.Books.FirstOrDefault(b => b.User == user);
                if (book != null)
                {
                    return false;
                }
                appConext.Users.Remove(user);
                appConext.SaveChanges();
                return true;
            }
        }
    }
}

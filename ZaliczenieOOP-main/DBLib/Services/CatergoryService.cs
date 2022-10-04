using DBLib.Models;
using DBLib.Services.Interfaces;


namespace DBLib.Services
{
    /// <summary>
    /// CategoryService implementuje generyczny BaseMethods i pozwala nadpisywac specyficzne metody pod konkretny model
    /// </summary>
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly AppDbContextFactory contextFactory;
        /// <summary>
        /// konstruktor przypisuje dbcontext 
        /// <summary>
        public CategoryService(AppDbContextFactory context) : base(context)
        {
            contextFactory = context;
        }
        /// <summary>
        /// metoda pobierająca po Id, dla kategorii
        /// <summary>
        public override Category GetById(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                return appConext.Categories.FirstOrDefault(b => b.CategoryId == id);
            }
        }
        /// <summary>
        /// metoda usuwająca po Id, dla kategorii
        /// <summary>
        public override void RemoveById(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                var category = appConext.Categories.FirstOrDefault(b => b.CategoryId == id);
                appConext.Categories.Remove(category);
                appConext.SaveChanges();
            }
        }
        /// <summary>
        /// metoda usuwająca po Id, dla kategorii
        /// <summary>
        public override bool RemoveByIdStatus(int id)
        {
            using AppDbContext appConext = contextFactory.CreateDbContext();
            {
                var category = appConext.Categories.FirstOrDefault(b => b.CategoryId == id);
                var books = appConext.Books.Where(b => b.CategoryId == id);
                if (books.Count() != 0)
                {
                    return false;
                }
                appConext.Categories.Remove(category);
                appConext.SaveChanges();
                return true;
            }
        }
    }
}

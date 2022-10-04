using DBLib.Services.Interfaces;

namespace DBLib.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, new()
    {
        /// <summary>
        /// Bazowy servie pokrywa więszkośc generycznych metod dostępu do danych
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private readonly AppDbContextFactory contextFactory;


        /// <summary>
        /// konstruktor przypisuje dbcontext 
        /// <summary>
        public BaseService(AppDbContextFactory context)
        {
            contextFactory = context;
        }

        /// <summary>
        /// dodaje asynchronicznie
        /// <summary>
        public void AddAsync(T entity)
        {
            using AppDbContext appContext = contextFactory.CreateDbContext();
            {
                appContext.Set<T>().Add(entity);
                appContext.SaveChanges();
            }
        }

        /// <summary>
        /// pboiera wszsytkie obiekty typu T
        /// <summary>
        public virtual List<T> GetAll()
        {
            using AppDbContext appContext = contextFactory.CreateDbContext();
            {
                return appContext.Set<T>().ToList();
            }
        }

        /// <summary>
        /// pobiera po Id
        /// <summary>
        public abstract T GetById(int id);
        /// <summary>
        /// usuwa po id, zwraca status
        /// <summary>
        /// 
        public abstract bool RemoveByIdStatus(int id);
        /// <summary>
        /// usuwa po id
        /// <summary>
        /// 
        public abstract void RemoveById(int id);
        /// <summary>
        /// aktualizuje T
        /// <summary>
        public void Update(T entity)
        {
            using AppDbContext appContext = contextFactory.CreateDbContext();
            {
                appContext.Set<T>().Update(entity);
                appContext.SaveChanges();
            }
        }
    }
}

namespace DBLib.Services.Interfaces
{

    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Dodaje generyczne T do bazy danych
        /// </summary>
        /// <param name = "entity"></param>
        void AddAsync(T entity);
        /// <summary>
        /// Pobierz listę elementów T
        /// </summary>
        List<T> GetAll();
        /// <summary>
        /// Pobierz T po id
        /// </summary>
        /// <param name = "id"></param>
        T GetById(int id);
        /// <summary>
        /// usuń obiekt po id
        /// </summary>
        /// <param name = "id"></param>
        void RemoveById(int id);
        /// <summary>
        /// usuń obiekt po id with status
        /// </summary>
        /// <param name = "id"></param>
        bool RemoveByIdStatus(int id);
        /// <summary>
        /// aktualizuj obiekt po obiekcie
        /// </summary>
        /// <param name = "entity"></param>
        void Update(T entity);
    }
}

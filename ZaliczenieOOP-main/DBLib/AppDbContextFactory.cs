using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBLib
{
    /// <summary>
    /// Fabryczka zwracająca i tworząca połączenie do bazy 
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=LibraryDB;  Trusted_Connection=True");
            return new AppDbContext(options.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class MyDBContext : DbContext
    {
        public static string ConnectionString = "";

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseOracle(ConnectionString);
        }
    }
}

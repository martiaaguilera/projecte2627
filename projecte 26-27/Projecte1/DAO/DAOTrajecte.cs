using IDAO;

namespace DAO
{
    public class DAOTrajecte : IDAOTrajecte
    {
        private MyDBContext context;

        public DAOTrajecte(MyDBContext context)
        {
            this.context = context;
        }
    }
}
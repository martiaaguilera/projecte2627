using IDAO;

namespace DAO
{
    public class DAOUsuari : IDAOUsuari
    {
        private MyDBContext context;

        public DAOUsuari(MyDBContext context)
        {
            this.context = context;
        }
    }
}
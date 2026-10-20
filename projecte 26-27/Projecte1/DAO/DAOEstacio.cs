using IDAO;

namespace DAO
{
    public class DAOEstacio : IDAOEstacio
    {
        private MyDBContext context;

        public DAOEstacio(MyDBContext context)
        {
            this.context = context;
        }
    }
}
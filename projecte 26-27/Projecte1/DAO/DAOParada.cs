using IDAO;

namespace DAO
{
    public class DAOParada : IDAOParada
    {
        private MyDBContext context;

        public DAOParada(MyDBContext context)
        {
            this.context = context;
        }
    }
}
using IDAO;

namespace DAO
{
    public class DAOMitjaTransport : IDAOMitjaTransport
    {
        private MyDBContext context;

        public DAOMitjaTransport(MyDBContext context)
        {
            this.context = context;
        }
    }
}
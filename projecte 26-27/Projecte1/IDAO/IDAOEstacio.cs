using Model;
using System.Collections.ObjectModel;

namespace IDAO
{
    public interface IDAOEstacio
    {
        public Estacio GetEstacio(int id);

        public ObservableCollection<Estacio> GetEstacions(string nom_filtre,int offset = 0,int rows_per_page = -1);

        public void AddEstacio(Estacio estacio);

        public void UpdateEstacio(Estacio estacio);

        public void DeleteEstacio(int id);
    }
}
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IDAO
{
    public interface IDAOCiutat
    {
        public Ciutat GetCiutat(int id);
        public ObservableCollection<Ciutat> GetCiutats(string nom_filtre, int offset = 0, int rows_per_page = -1);


    }
}

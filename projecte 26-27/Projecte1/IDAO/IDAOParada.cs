using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IDAO
{
    public interface IDAOParada
    {
        public Parada GetParada(int idTrajecte, int ordre);

        public ObservableCollection<Parada> GetParades(string nom_filtre, int offset = 0, int rows_per_page = -1);

        public void AddParada(Parada parada);

        public void UpdateParada(Parada parada);

        public void DeleteParada(int id);
    }
}

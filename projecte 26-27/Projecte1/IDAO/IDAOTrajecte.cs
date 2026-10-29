using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IDAO
{
    public interface IDAOTrajecte
    {
        public Trajecte GetTrajecte(int id);

        public ObservableCollection<Trajecte> GetTrajectes(string nom_filtre, int offset = 0, int rows_per_page = -1);

        public void AddTrajecte(Trajecte trajecte);

        public void UpdateTrajecte(Trajecte trajecte);

        public void DeleteTrajecte(int id);

        public ObservableCollection<Trajecte> GetTrajectesUsuari(int idUsuari);

        public void ValidarTrajecte(int id, int validat);

        public ObservableCollection<Trajecte> CercarTrajectes(int idEstacioOrigen, int idEstacioDesti, string horaSortida);
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IDAO
{
    public interface IDAOUsuari
    {
        public Usuari GetUsuari(int id);

        public ObservableCollection<Usuari> GetUsuaris(string nom_filtre, int offset = 0, int rows_per_page = -1);

        public void AddUsuari(Usuari usuari);

        public void UpdateUsuari(Usuari usuari);

        public void DeleteUsuari(int id);
    }
}

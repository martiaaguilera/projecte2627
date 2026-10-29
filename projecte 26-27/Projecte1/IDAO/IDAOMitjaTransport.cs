using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IDAO
{
    public interface IDAOMitjaTransport
    {
        public MitjaTransport GetMitjaTransport(int id);

        public ObservableCollection<MitjaTransport> GetMitjansTransport(string nom_filtre, int offset = 0, int rows_per_page = -1);    }
}

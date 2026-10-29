using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model
{
    public class Trajecte : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private DateTime dataCreacio;
        private int validat;
        private int idMitjaTransport;
        private int idUsuariCreador;

        public Trajecte(int id, string nom, DateTime dataCreacio, int validat, int idMitjaTransport, int idUsuariCreador)
        {
            Id = id;
            Nom = nom;
            DataCreacio = dataCreacio;
            Validat = validat;
            IdMitjaTransport = idMitjaTransport;
            IdUsuariCreador = idUsuariCreador;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DataCreacio { get => dataCreacio; set => dataCreacio = value; }
        public int Validat { get => validat; set => validat = value; }
        public int IdMitjaTransport { get => idMitjaTransport; set => idMitjaTransport = value; }
        public int IdUsuariCreador { get => idUsuariCreador; set => idUsuariCreador = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return "Nom: " + Nom + " | Data Creacio:" + DataCreacio + " | Validat: " + Validat + " | Mitja Transport: " + IdMitjaTransport + " | Usuari Creador: " + IdUsuariCreador;
        }
    }
}

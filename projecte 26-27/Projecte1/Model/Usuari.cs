using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Usuari : INotifyPropertyChanged
    {
        private int id;
        private string email;
        private string nom;
        private string password;
        private char tipus;
        private DateTime dataRegistre;

        public Usuari(int id, string email, string nom, string password, char tipus, DateTime dataRegistre)
        {
            Id = id;
            Email = email;
            Nom = nom;
            Password = password;
            Tipus = tipus;
            DataRegistre = dataRegistre;
        }

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Password { get => password; set => password = value; }
        public char Tipus { get => tipus; set => tipus = value; }
        public DateTime DataRegistre { get => dataRegistre; set => dataRegistre = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return "Id: " + Id + " | Nom:" + Nom + " | Email: " + Email + " | Password: " + Password + " | Tipus: " + Tipus + " | DataRegistre: " + DataRegistre;
        }
    }
}

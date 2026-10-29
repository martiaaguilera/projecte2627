using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model
{
    public class Parada : INotifyPropertyChanged
    {
        private int idTrajecte;
        private int ordre;
        private string nom;
        private string horaPas;
        private int idEstacio;

        public Parada(int idTrajecte, int ordre, string nom, string horaPas, int idEstacio)
        {
            IdTrajecte = idTrajecte;
            Ordre = ordre;
            Nom = nom;
            HoraPas = horaPas;
            IdEstacio = idEstacio;
        }

        public int IdTrajecte { get => idTrajecte; set => idTrajecte = value; }
        public int Ordre { get => ordre; set => ordre = value; }
        public string Nom { get => nom; set => nom = value; }
        public string HoraPas { get => horaPas; set => horaPas = value; }
        public int IdEstacio { get => idEstacio; set => idEstacio = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return "Id Trajecte: " + IdTrajecte + " | Ordre: " + Ordre + " | Nom: " + Nom + " | Hora pas: " + HoraPas;
        }
    }
}

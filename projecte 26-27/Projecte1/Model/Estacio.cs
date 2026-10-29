using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model
{
    public class Estacio : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private decimal latitud;
        private decimal longitud;
        private int idCiutat;

        public Estacio(int id, string nom, decimal latitud, decimal longitud, int idCiutat)
        {
            Id = id;
            Nom = nom;
            Latitud = latitud;
            Longitud = longitud;
            IdCiutat = idCiutat;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal Latitud { get => latitud; set => latitud = value; }
        public decimal Longitud { get => longitud; set => longitud = value; }
        public int IdCiutat { get => idCiutat; set => idCiutat = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return "Id: " + Id + " | Nom: " + Nom + " | Latitud: " + Latitud + " | Longitud: " + Longitud;
        }
    }
}

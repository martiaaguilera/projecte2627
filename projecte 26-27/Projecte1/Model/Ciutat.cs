using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Ciutat
    {
        private int id;
        private string nom;

        public Ciutat(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }


        public override string ToString()
        {
            return "Id: " + Id + " | Nom: " + Nom;
        }
    }
}

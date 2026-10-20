using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public  class MitjaTransport
    {
        private int id;
        private string nom;

        public MitjaTransport(int id, string nom)
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

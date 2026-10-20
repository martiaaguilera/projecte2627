using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Trajecte
    {
        private int id;
        private string nom;
        private DateTime dataCreacio;
        private int validat;
        private int mitjaTransport;
        private int usuariCreador;

        public Trajecte(int id, string nom, DateTime dataCreacio, int validat, int mitjaTransport, int usuariCreador)
        {
            Id = id;
            Nom = nom;
            DataCreacio = dataCreacio;
            Validat = validat;
            MitjaTransport = mitjaTransport;
            UsuariCreador = usuariCreador;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DataCreacio { get => dataCreacio; set => dataCreacio = value; }
        public int Validat { get => validat; set => validat = value; }
        public int MitjaTransport { get => mitjaTransport; set => mitjaTransport = value; }
        public int UsuariCreador { get => usuariCreador; set => usuariCreador = value; }

        public override string ToString()
        {
            return "Nom: " + Nom + " | Data Creacio:" + DataCreacio + " | Validat: " + Validat + " | Mitja Transport: " + MitjaTransport + " | Usuari Creador: " + UsuariCreador;
        }
    }
}

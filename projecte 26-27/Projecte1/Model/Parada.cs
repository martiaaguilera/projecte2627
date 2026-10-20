using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Parada
    {
        private int idTraj;
        private int ordre;
        private string nom;
        private string horaPas;
        private int idEstacio;

        public Parada(int idTraj, int ordre, string nom, string horaPas, int idEstacio)
        {
            IdTraj = idTraj;
            Ordre = ordre;
            Nom = nom;
            HoraPas = horaPas;
            IdEstacio = idEstacio;
        }

        public int IdTraj { get => idTraj; set => idTraj = value; }
        public int Ordre { get => ordre; set => ordre = value; }
        public string Nom { get => nom; set => nom = value; }
        public string HoraPas { get => horaPas; set => horaPas = value; }
        public int IdEstacio { get => idEstacio; set => idEstacio = value; }

        public override string ToString()
        {
            return "Id Trajecte: " + IdTraj + " | Ordre: " + Ordre + " | Nom: " + Nom + " | Hora pas: " + HoraPas;
        }
    }
}

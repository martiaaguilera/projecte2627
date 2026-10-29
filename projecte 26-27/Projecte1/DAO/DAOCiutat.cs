using IDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Model;
using System.Collections.ObjectModel;

namespace DAO
{
    public class DAOCiutat : IDAOCiutat
    {
        private readonly MyDBContext _context;

        public DAOCiutat(MyDBContext c)
        {
            _context = c;
        }

        public Ciutat GetCiutat(int id)
        {
            Ciutat ciutat = null;

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM CIUTAT
                    WHERE id = :ID";

                Utils.CrearParametre(consulta, id, "ID", System.Data.DbType.Int32);

                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                using (var reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idCiutat = reader.GetInt32(reader.GetOrdinal("id"));
                        string nom = reader.GetString(reader.GetOrdinal("nom"));

                        ciutat = new Ciutat(idCiutat, nom);
                    }
                }
            }

            return ciutat;
        }

        public ObservableCollection<Ciutat> GetCiutats(string nom_filtre, int offset = 0, int rows_per_page = -1)
        {

            ObservableCollection<Ciutat> resultat = new ObservableCollection<Ciutat>();

            var connexio = _context.Database.GetDbConnection();

            // Obrir la connexió a la BD (només si fa falta)
            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }
            // Crear una consulta SQL
            using (var consulta = connexio.CreateCommand())
            {

                // query SQL
                consulta.CommandText =
                    @"SELECT * FROM CIUTAT
                    WHERE (:NOM_TEXT = '%%' OR UPPER(nom) LIKE UPPER(:NOM_TEXT))
                    ORDER BY nom";

                if (rows_per_page > 0)
                {
                    consulta.CommandText += $" OFFSET {offset} ROWS FETCH NEXT {rows_per_page} ROWS ONLY";
                }

                Utils.CrearParametre(consulta, "%" + nom_filtre + "%", "NOM_TEXT", System.Data.DbType.String);



                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction(); // IMPORTANT !!! NO us ho deixeu <--------------------!!!!!!!


                int id = 0;
                string nom = " ";
                using (var reader = consulta.ExecuteReader())
                {
                    while (reader.Read()) // per cada Read() avancem una fila en els resultats de la consulta.
                    {
                        // Descarreguem les dades de cada columna de la taula
                        id = reader.GetInt32(reader.GetOrdinal("id"));
                        nom = reader.GetString(reader.GetOrdinal("nom"));

                        Ciutat c = new Ciutat(id, nom);

                        resultat.Add(c);
                    }


                }
            }
            return resultat;
        }
    }
}

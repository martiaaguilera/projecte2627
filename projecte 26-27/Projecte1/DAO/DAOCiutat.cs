using IDAO;
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
            ObservableCollection<Ciutat> ciutats = GetCiutats("" + id, "");
            if (ciutats.Count == 0) return null;
            else return ciutats[0];
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
                    @"select * from ciutat 
                                where 
                                ( @NOM_TEXT='%%' OR nom_filtre like @NOM_TEXT)";

                if (rows_per_page > 0)
                {
                    consulta.CommandText += $" limit {rows_per_page} offset {offset}";
                }

                Utils.CrearParametre(consulta, "%" + nom_filtre + "%", "NOM_TEXT", System.Data.DbType.String);



                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction(); // IMPORTANT !!! NO us ho deixeu <--------------------!!!!!!!


                using (var reader = consulta.ExecuteReader())
                {
                    while (reader.Read()) // per cada Read() avancem una fila en els resultats de la consulta.
                    {

                        // Descarreguem les dades de cada columna de la taula
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string nom = reader.GetString(reader.GetOrdinal("nom"));
                        }

                        Ciutat c = new Ciutat(id, nom);

                        resultat.Add(c);
                    }
                }

            }

            return resultat;
        }
    }
}
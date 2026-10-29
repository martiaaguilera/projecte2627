using IDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Model;
using System.Collections.ObjectModel;

namespace DAO
{
    public class DAOMitjaTransport : IDAOMitjaTransport
    {
        private readonly MyDBContext _context;

        public DAOMitjaTransport(MyDBContext c)
        {
            _context = c;
        }

        public MitjaTransport GetMitjaTransport(int id)
        {
            MitjaTransport mitjaTransport = null;

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM MITJA_TRANSPORT
                    WHERE id = :ID";

                Utils.CrearParametre(consulta, id, "ID", System.Data.DbType.Int32);

                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                using (var reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idMitja = reader.GetInt32(reader.GetOrdinal("id"));
                        string nom = reader.GetString(reader.GetOrdinal("nom"));

                        mitjaTransport = new MitjaTransport(idMitja, nom);
                    }
                }
            }

            return mitjaTransport;
        }

        public ObservableCollection<MitjaTransport> GetMitjansTransport(string nom_filtre, int offset = 0, int rows_per_page = -1)
        {
            ObservableCollection<MitjaTransport> resultat = new ObservableCollection<MitjaTransport>();

            var connexio = _context.Database.GetDbConnection();

            // Obrir la connexió a la BD (només si fa falta)
            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            // Crear una consulta SQL
            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM MITJA_TRANSPORT
                    WHERE (:NOM_TEXT = '%%' OR UPPER(nom) LIKE UPPER(:NOM_TEXT))
                    ORDER BY nom";


                if (rows_per_page > 0)
                {
                    consulta.CommandText += $" OFFSET {offset} ROWS FETCH NEXT {rows_per_page} ROWS ONLY";
                }


                Utils.CrearParametre(consulta, "%" + nom_filtre + "%", "NOM_TEXT", System.Data.DbType.String);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();


                int id = 0;
                string nom = " ";


                using (var reader = consulta.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id"));
                        nom = reader.GetString(reader.GetOrdinal("nom"));

                        MitjaTransport m = new MitjaTransport(id, nom);

                        resultat.Add(m);
                    }
                }
            }

            return resultat;
        }
    }
}

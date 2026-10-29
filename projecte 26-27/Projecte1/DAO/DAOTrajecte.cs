using IDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Model;
using System.Collections.ObjectModel;

namespace DAO
{
    public class DAOTrajecte : IDAOTrajecte
    {
        private readonly MyDBContext _context;

        public DAOTrajecte(MyDBContext c)
        {
            _context = c;
        }

        public Trajecte GetTrajecte(int id)
        {
            Trajecte trajecte = null;

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM TRAJECTE
                    WHERE id = :ID";

                Utils.CrearParametre(consulta, id, "ID", System.Data.DbType.Int32);

                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                using (var reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idTrajecte = reader.GetInt32(reader.GetOrdinal("id"));
                        string nom = reader.GetString(reader.GetOrdinal("nom"));
                        DateTime dataCreacio = reader.GetDateTime(reader.GetOrdinal("datacreacio"));
                        int validat = reader.GetInt32(reader.GetOrdinal("validat"));
                        int idMitjaTransport = reader.GetInt32(reader.GetOrdinal("mitjatransport"));
                        int idUsuariCreador = reader.GetInt32(reader.GetOrdinal("usuaricreador"));

                        trajecte = new Trajecte(idTrajecte, nom, dataCreacio, validat, idMitjaTransport, idUsuariCreador);
                    }
                }
            }

            return trajecte;
        }

        public ObservableCollection<Trajecte> GetTrajectes(string nom_filtre, int offset = 0, int rows_per_page = -1)
        {
            ObservableCollection<Trajecte> resultat = new ObservableCollection<Trajecte>();

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM TRAJECTE
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
                DateTime dataCreacio;
                int validat = 0, idMitjaTransport = 0, idUsuariCreador = 0;


                using (var reader = consulta.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id"));
                        nom = reader.GetString(reader.GetOrdinal("nom"));
                        dataCreacio = reader.GetDateTime(reader.GetOrdinal("datacreacio"));
                        validat = reader.GetInt32(reader.GetOrdinal("validat"));
                        idMitjaTransport = reader.GetInt32(reader.GetOrdinal("mitjatransport"));
                        idUsuariCreador = reader.GetInt32(reader.GetOrdinal("usuaricreador"));

                        Trajecte t = new Trajecte(id, nom, dataCreacio, validat, idMitjaTransport, idUsuariCreador);

                        resultat.Add(t);
                    }
                }
            }

            return resultat;
        }

        public void AddTrajecte(Trajecte trajecte)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"INSERT INTO TRAJECTE
                    (nom, datacreacio, validat, mitjatransport, usuaricreador)
                    VALUES
                    (:NOM, :DATACREACIO, :VALIDAT, :MITJATRANSPORT, :USUARICREADOR)";


                Utils.CrearParametre(consulta, trajecte.Nom, "NOM", System.Data.DbType.String);

                Utils.CrearParametre(consulta, trajecte.DataCreacio, "DATACREACIO", System.Data.DbType.DateTime);

                Utils.CrearParametre(consulta, trajecte.Validat, "VALIDAT", System.Data.DbType.Int32);

                Utils.CrearParametre(consulta, trajecte.IdMitjaTransport, "MITJATRANSPORT", System.Data.DbType.Int32);

                Utils.CrearParametre(consulta, trajecte.IdUsuariCreador, "USUARICREADOR", System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }

        public void UpdateTrajecte(Trajecte trajecte)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"UPDATE TRAJECTE
                    SET nom = :NOM,
                        datacreacio = :DATACREACIO,
                        validat = :VALIDAT,
                        mitjatransport = :MITJATRANSPORT,
                        usuaricreador = :USUARICREADOR
                    WHERE id = :ID";


                Utils.CrearParametre(consulta, trajecte.Nom, "NOM", System.Data.DbType.String);

                Utils.CrearParametre(consulta, trajecte.DataCreacio, "DATACREACIO", System.Data.DbType.DateTime);

                Utils.CrearParametre(consulta, trajecte.Validat, "VALIDAT", System.Data.DbType.Int32);

                Utils.CrearParametre(consulta, trajecte.IdMitjaTransport, "MITJATRANSPORT", System.Data.DbType.Int32);

                Utils.CrearParametre(consulta, trajecte.IdUsuariCreador, "USUARICREADOR", System.Data.DbType.Int32);

                Utils.CrearParametre(consulta, trajecte.Id, "ID", System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }

        public void DeleteTrajecte(int id)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"DELETE FROM TRAJECTE
                    WHERE id = :ID";


                Utils.CrearParametre(consulta, id, "ID", System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Trajecte> GetTrajectesUsuari(int idUsuari)
        {
            ObservableCollection<Trajecte> resultat = new ObservableCollection<Trajecte>();

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM TRAJECTE
                    WHERE usuaricreador = :ID_USUARI
                    ORDER BY nom";



                Utils.CrearParametre(consulta,idUsuari,"ID_USUARI", System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();


                int id = 0;
                string nom = " ";
                DateTime dataCreacio;
                int validat = 0, idMitjaTransport = 0, idUsuariCreador = 0;


                using (var reader = consulta.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id"));
                        nom = reader.GetString(reader.GetOrdinal("nom"));
                        dataCreacio = reader.GetDateTime(reader.GetOrdinal("datacreacio"));
                        validat = reader.GetInt32(reader.GetOrdinal("validat"));
                        idMitjaTransport = reader.GetInt32(reader.GetOrdinal("mitjatransport"));
                        idUsuariCreador = reader.GetInt32(reader.GetOrdinal("usuaricreador"));

                        Trajecte t = new Trajecte(id, nom, dataCreacio, validat, idMitjaTransport, idUsuariCreador);

                        resultat.Add(t);
                    }
                }
            }

            return resultat;
        }

        public void ValidarTrajecte(int id, int validat)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"UPDATE TRAJECTE
                    SET validat = :VALIDAT
                        WHERE id = :ID";


                Utils.CrearParametre(consulta, validat, "VALIDAT", System.Data.DbType.Int32);
                Utils.CrearParametre(consulta, id, "ID", System.Data.DbType.Int32);

                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();

            }
        }

        public ObservableCollection<Trajecte> CercarTrajectes(int idEstacioOrigen, int idEstacioDesti, string horaSortida)
        {
            ObservableCollection<Trajecte> resultat = new ObservableCollection<Trajecte>();

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                      //volem tots els camps del trajecte
                      "SELECT TRAJECTE.id, TRAJECTE.nom, TRAJECTE.dataCreacio, TRAJECTE.validat, TRAJECTE.mitjaTransport, TRAJECTE.usuariCreador " +

                      //fem servir la taula PARADA dos cops: una per a la parada on puja l'usuari (ORIGEN) i l'altra on baixa (DESTI)
                      "FROM TRAJECTE, PARADA ORIGEN, PARADA DESTI " +

                      //la parada d'origen ha de ser d'aquest trajecte
                      "WHERE ORIGEN.id_traj = TRAJECTE.id " +

                      //la parada de destí també ha de ser d'aquest trajecte
                      "AND DESTI.id_traj = TRAJECTE.id " +

                      //la parada d'origen ha de ser a l'estació d'on surt l'usuari
                      "AND ORIGEN.idEstacio = :ID_ORIGEN " +

                      //la parada de destí ha de ser a l'estació on vol arribar l'usuari
                      "AND DESTI.idEstacio = :ID_DESTI " +

                      //l'origen ha d'anar abans que el destí, si no el trajecte aniria al revés
                      "AND ORIGEN.ordre < DESTI.ordre " +

                      //el trajecte ha de passar per l'origen a l'hora que diu l'usuari o més tard
                      "AND ORIGEN.horaPas >= :HORA_SORTIDA " +

                      //només ensenyem els trajectes que l'admin ja ha validat
                      "AND TRAJECTE.validat = 1 " +

                      //els ordenem perquè surtin primer els que passen abans
                      "ORDER BY ORIGEN.horaPas";


                Utils.CrearParametre(consulta, idEstacioOrigen, "ID_ORIGEN", System.Data.DbType.Int32);
                Utils.CrearParametre(consulta, idEstacioDesti, "ID_DESTI", System.Data.DbType.Int32);
                Utils.CrearParametre(consulta, horaSortida, "HORA_SORTIDA", System.Data.DbType.String);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();


                int id = 0;
                string nom = " ";
                DateTime dataCreacio;
                int validat = 0, idMitjaTransport = 0, idUsuariCreador = 0;


                using (var reader = consulta.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id"));
                        nom = reader.GetString(reader.GetOrdinal("nom"));
                        dataCreacio = reader.GetDateTime(reader.GetOrdinal("datacreacio"));
                        validat = reader.GetInt32(reader.GetOrdinal("validat"));
                        idMitjaTransport = reader.GetInt32(reader.GetOrdinal("mitjatransport"));
                        idUsuariCreador = reader.GetInt32(reader.GetOrdinal("usuaricreador"));

                        Trajecte t = new Trajecte(id, nom, dataCreacio, validat, idMitjaTransport, idUsuariCreador);

                        resultat.Add(t);
                    }
                }
            }

            return resultat;
        }
    }
}

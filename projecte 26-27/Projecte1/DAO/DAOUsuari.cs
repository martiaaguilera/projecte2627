using IDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Model;
using System.Collections.ObjectModel;

namespace DAO
{
    public class DAOUsuari : IDAOUsuari
    {
        private readonly MyDBContext _context;

        public DAOUsuari(MyDBContext c)
        {
            _context = c;
        }

        public Usuari GetUsuari(int id)
        {
            Usuari usuari = null;

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM USUARI
                    WHERE id = :ID";

                Utils.CrearParametre(consulta, id, "ID", System.Data.DbType.Int32);

                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                using (var reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idEstacio = reader.GetInt32(reader.GetOrdinal("id"));
                        string nom = reader.GetString(reader.GetOrdinal("nom"));
                        string email = reader.GetString(reader.GetOrdinal("email"));
                        string password = reader.GetString(reader.GetOrdinal("password"));
                        Char tipus = reader.GetString(reader.GetOrdinal("tipus"))[0];
                        DateTime dataRegistre = reader.GetDateTime(reader.GetOrdinal("dataregistre"));

                        usuari = new Usuari(id, email, nom, password, tipus, dataRegistre);
                    }
                }
            }

            return usuari;
        }

        public ObservableCollection<Usuari> GetUsuaris(string nom_filtre, int offset = 0, int rows_per_page = -1)
        {
            ObservableCollection<Usuari> resultat = new ObservableCollection<Usuari>();

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
                    @"SELECT * FROM USUARI
                    WHERE (:NOM_TEXT = '%%' OR UPPER(nom) LIKE UPPER(:NOM_TEXT))
                    ORDER BY nom";


                if (rows_per_page > 0)
                {
                    consulta.CommandText += $" OFFSET {offset} ROWS FETCH NEXT {rows_per_page} ROWS ONLY";
                }


                Utils.CrearParametre(consulta, "%" + nom_filtre + "%", "NOM_TEXT", System.Data.DbType.String);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();


                int id = 0;
                string nom = " ", email =  " ", password = " ";
                char tipus = ' ';
                DateTime dataRegistre;


                using (var reader = consulta.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id"));
                        email = reader.GetString(reader.GetOrdinal("email"));
                        nom = reader.GetString(reader.GetOrdinal("nom"));
                        password = reader.GetString(reader.GetOrdinal("password"));
                        tipus = reader.GetString(reader.GetOrdinal("tipus"))[0];
                        dataRegistre = reader.GetDateTime(reader.GetOrdinal("dataregistre"));

                        Usuari u = new Usuari(id, email, nom, password, tipus, dataRegistre);

                        resultat.Add(u);
                    }
                }
            }

            return resultat;
        }

        public void AddUsuari(Usuari usuari)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"INSERT INTO USUARI
                    (email, nom, password, tipus, dataregistre)
                    VALUES
                    (:EMAIL, :NOM, :PASSWORD, :TIPUS, :DATAREGISTRE)";


                Utils.CrearParametre(consulta, usuari.Email, "EMAIL", System.Data.DbType.String);

                Utils.CrearParametre(consulta, usuari.Nom, "NOM", System.Data.DbType.String);

                Utils.CrearParametre(consulta, usuari.Password, "PASSWORD", System.Data.DbType.String);

                Utils.CrearParametre(consulta, usuari.Tipus.ToString(), "TIPUS", System.Data.DbType.String);

                Utils.CrearParametre(consulta, usuari.DataRegistre, "DATAREGISTRE", System.Data.DbType.DateTime);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }

        public void DeleteUsuari(int id)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"DELETE FROM USUARI
                    WHERE id = :ID";


                Utils.CrearParametre(consulta, id, "ID", System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }

        

        public void UpdateUsuari(Usuari usuari)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"UPDATE USUARI
                    SET email = :EMAIL,
                        nom = :NOM,
                        password = :PASSWORD,
                        tipus = :TIPUS,
                        dataregistre = :DATAREGISTRE
                    WHERE id = :ID";


                Utils.CrearParametre(consulta, usuari.Email, "EMAIL", System.Data.DbType.String);

                Utils.CrearParametre(consulta, usuari.Nom, "NOM", System.Data.DbType.String);

                Utils.CrearParametre(consulta, usuari.Password, "PASSWORD", System.Data.DbType.String);

                Utils.CrearParametre(consulta, usuari.Tipus.ToString(), "TIPUS", System.Data.DbType.String);

                Utils.CrearParametre(consulta, usuari.DataRegistre, "DATAREGISTRE", System.Data.DbType.DateTime);

                Utils.CrearParametre(consulta, usuari.Id, "ID", System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }
    }
}

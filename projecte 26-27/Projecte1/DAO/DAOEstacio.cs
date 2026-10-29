using IDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Model;
using System.Collections.ObjectModel;
using System.Data;

namespace DAO
{
    public class DAOEstacio : IDAOEstacio
    {
        private readonly MyDBContext _context;

        public DAOEstacio(MyDBContext c)
        {
            _context = c;
        }


        public Estacio GetEstacio(int id)
        {
            Estacio estacio = null;

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM ESTACIO
                    WHERE id = :ID";

                Utils.CrearParametre(consulta,id,"ID",System.Data.DbType.Int32);

                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                using (var reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idEstacio = reader.GetInt32(reader.GetOrdinal("id"));
                        string nom = reader.GetString(reader.GetOrdinal("nom"));
                        decimal latitud = reader.GetDecimal(reader.GetOrdinal("latitud"));
                        decimal longitud = reader.GetDecimal(reader.GetOrdinal("longitud"));
                        int idCiutat = reader.GetInt32(reader.GetOrdinal("id_ciutat"));

                        estacio = new Estacio(idEstacio,nom,latitud,longitud,idCiutat);
                    }
                }
            }

            return estacio;
        }


        public ObservableCollection<Estacio> GetEstacions(string nom_filtre,int offset = 0,int rows_per_page = -1)
        {
            ObservableCollection<Estacio> resultat = new ObservableCollection<Estacio>();

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
                    @"SELECT * FROM ESTACIO
                    WHERE (:NOM_TEXT = '%%' OR UPPER(nom) LIKE UPPER(:NOM_TEXT))
                    ORDER BY nom";


                if (rows_per_page > 0)
                {
                    consulta.CommandText += $" OFFSET {offset} ROWS FETCH NEXT {rows_per_page} ROWS ONLY";
                }


                Utils.CrearParametre(consulta,"%" + nom_filtre + "%","NOM_TEXT",System.Data.DbType.String);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();


                int id = 0;
                string nom = " ";
                decimal latitud, longitud;
                int idCiutat = 0;


                using (var reader = consulta.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id"));
                        nom = reader.GetString(reader.GetOrdinal("nom"));
                        latitud = reader.GetDecimal(reader.GetOrdinal("latitud"));
                        longitud = reader.GetDecimal(reader.GetOrdinal("longitud"));
                        idCiutat = reader.GetInt32(reader.GetOrdinal("id_ciutat"));

                        Estacio e = new Estacio(id,nom,latitud,longitud,idCiutat);

                        resultat.Add(e);
                    }
                }
            }

            return resultat;
        }


        public void AddEstacio(Estacio estacio)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"INSERT INTO ESTACIO
                    (nom, latitud, longitud, id_ciutat)
                    VALUES
                    (:NOM, :LATITUD, :LONGITUD, :ID_CIUTAT)";


                Utils.CrearParametre(consulta,estacio.Nom,"NOM",System.Data.DbType.String);

                Utils.CrearParametre(consulta,estacio.Latitud,"LATITUD",System.Data.DbType.Decimal);

                Utils.CrearParametre(consulta,estacio.Longitud,"LONGITUD",System.Data.DbType.Decimal);

                Utils.CrearParametre(consulta,estacio.IdCiutat,"ID_CIUTAT",System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }


        public void UpdateEstacio(Estacio estacio)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"UPDATE ESTACIO
                    SET nom = :NOM,
                        latitud = :LATITUD,
                        longitud = :LONGITUD,
                        id_ciutat = :ID_CIUTAT
                    WHERE id = :ID";


                Utils.CrearParametre(consulta,estacio.Nom,"NOM",System.Data.DbType.String);

                Utils.CrearParametre(consulta,estacio.Latitud,"LATITUD",System.Data.DbType.Decimal);

                Utils.CrearParametre(consulta,estacio.Longitud,"LONGITUD",System.Data.DbType.Decimal);

                Utils.CrearParametre(consulta,estacio.IdCiutat,"ID_CIUTAT",System.Data.DbType.Int32);

                Utils.CrearParametre(consulta,estacio.Id,"ID",System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }


        public void DeleteEstacio(int id)
        {
            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"DELETE FROM ESTACIO
                    WHERE id = :ID";


                Utils.CrearParametre(consulta,id,"ID",System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                consulta.ExecuteNonQuery();
            }
        }
    }
}
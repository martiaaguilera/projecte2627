using IDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Model;
using System.Collections.ObjectModel;

namespace DAO
{
    public class DAOParada : IDAOParada
    {
        private MyDBContext _context;

        public DAOParada(MyDBContext c)
        {
            this._context = c;
        }

        public Parada GetParada(int idTrajecte, int ordre)
        {
            Parada parada = null;

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM PARADA
                    WHERE id_traj = :ID_TRAJ
                    AND ordre = :ORDRE";

                Utils.CrearParametre(consulta, idTrajecte, "ID_TRAJ", System.Data.DbType.Int32);
                Utils.CrearParametre(consulta, ordre, "ORDRE", System.Data.DbType.Int32);

                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();

                using (var reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idTraj = reader.GetInt32(reader.GetOrdinal("id_traj"));
                        int ordreParada = reader.GetInt32(reader.GetOrdinal("ordre"));
                        string nom = reader.GetString(reader.GetOrdinal("nom"));
                        string horaPas = reader.GetString(reader.GetOrdinal("horapas"));
                        int idEstacio = reader.GetInt32(reader.GetOrdinal("idestacio"));

                        parada = new Parada(idTraj, ordreParada, nom, horaPas, idEstacio);
                    }
                }
            }

            return parada;
        }

        public ObservableCollection<Parada> GetParades(string nom_filtre, int offset = 0, int rows_per_page = -1)
        {
            ObservableCollection<Parada> resultat = new ObservableCollection<Parada>();

            var connexio = _context.Database.GetDbConnection();

            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }

            using (var consulta = connexio.CreateCommand())
            {
                consulta.CommandText =
                    @"SELECT * FROM PARADA
                    WHERE (:NOM_TEXT = '%%' OR UPPER(nom) LIKE UPPER(:NOM_TEXT))
                    ORDER BY nom";


                if (rows_per_page > 0)
                {
                    consulta.CommandText += $" OFFSET {offset} ROWS FETCH NEXT {rows_per_page} ROWS ONLY";
                }


                Utils.CrearParametre(consulta, "%" + nom_filtre + "%", "NOM_TEXT", System.Data.DbType.String);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();


                using (var reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idTraj = reader.GetInt32(reader.GetOrdinal("id_traj"));
                        int ordreParada = reader.GetInt32(reader.GetOrdinal("ordre"));
                        string nom = reader.GetString(reader.GetOrdinal("nom"));
                        string horaPas = reader.GetString(reader.GetOrdinal("horapas"));
                        int idEstacio = reader.GetInt32(reader.GetOrdinal("idestacio"));

                        parada = new Parada(idTraj, ordreParada, nom, horaPas, idEstacio);
                    }
                }
            }
        }

        public void AddParada(Parada parada)
        {
            throw new NotImplementedException();
        }


        public void UpdateParada(Parada parada)
        {
            throw new NotImplementedException();
        }

        public void DeleteParada(int id)
        {
            throw new NotImplementedException();
        }

        

        

        
    }
}
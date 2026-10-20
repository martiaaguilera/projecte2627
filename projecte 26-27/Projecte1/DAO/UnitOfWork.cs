using IDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public class UnitOfWork : IDisposable
    {
        private readonly MyDBContext _context;

        public IDAOCiutat DAOCiutat { get; }
        public IDAOEstacio DAOEstacio { get; }
        public IDAOMitjaTransport DAOMitjaTransport { get; }
        public IDAOParada DAOParada { get; }
        public IDAOTrajecte DAOTrajecte { get; }
        public IDAOUsuari DAOUsuari { get; }

        public UnitOfWork(MyDBContext context)
        {
            _context = context;
            DAOCiutat = new DAOCiutat(_context);
            DAOEstacio = new DAOEstacio(_context);
            DAOMitjaTransport = new DAOMitjaTransport(_context);
            DAOParada = new DAOParada(_context);
            DAOTrajecte = new DAOTrajecte(_context);
            DAOUsuari = new DAOUsuari(_context);
        }

        public void BeginTransaction() => _context.Database.BeginTransaction();
        public void Commit() => _context.Database.CurrentTransaction?.Commit();

        public void Rollback() => _context.Database.CurrentTransaction?.Rollback();

        public void Dispose()
        {
        }
    }
}

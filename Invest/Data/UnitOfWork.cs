﻿using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.Data
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction _transaction;
        //private DbContextTransaction _transaction;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            if (!_disposed)
                this._transaction = _context.Database.BeginTransaction();
            _disposed = false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Commit(bool dispose = true)
        {
            if (_transaction != null)
                _transaction.Commit();
            _transaction = null;
            if (dispose)
                Dispose();
        }

        public void Rollback(bool dispose = true)
        {
            if (_transaction != null)
                _transaction.Rollback();
            _transaction = null;
            if (dispose)
                Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

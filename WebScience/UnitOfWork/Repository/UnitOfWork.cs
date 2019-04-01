using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebScience.Models;
using WebScience.UnitOfWork.Interface;

namespace WebScience.UnitOfWork.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        public UnitOfWork()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ModelScience"].ConnectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try { _transaction.Commit(); }
            catch { _transaction.Rollback(); throw; }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }

        private void resetRepositories()
        {
            //UserProfileRepository = null;
            //_catRepository = null;
        }

        public IGenericRepository<tb_UserProfile> UserProfileRepository => new GenericRepository<tb_UserProfile>(_transaction);



    }
}
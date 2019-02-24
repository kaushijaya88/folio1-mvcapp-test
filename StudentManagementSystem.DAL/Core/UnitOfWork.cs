using StudentManagementSystem.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Private Properties
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IClassManagementRepository _classManagementRepository;
        private IStudentManagementRepository _studentManagementRepository;
        private bool _disposed = false;
        #endregion

        public UnitOfWork(ConnectionStringsDto connection)
        {
            string connectionString = connection.SQLConnectionString;
            _connection = new SqlConnection(connectionString);

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            _transaction = _connection.BeginTransaction();
        }

        public IClassManagementRepository ClassManagementRepository
        {
            get { return _classManagementRepository ?? (_classManagementRepository = new ClassManagementRepository(_transaction)); }
        }

        public IStudentManagementRepository StudentManagementRepository
        {
            get { return _studentManagementRepository ?? (_studentManagementRepository = new StudentManagementRepository(_transaction)); }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                _transaction.Dispose();
                ResetRepositories();
            }
        }

        /// <summary>
        /// Reset all repositoroies
        /// </summary>
        private void ResetRepositories()
        {
            _classManagementRepository = null;
            _studentManagementRepository = null;
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
                        _connection.Close();
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Call to Distructor
        /// </summary>
        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}

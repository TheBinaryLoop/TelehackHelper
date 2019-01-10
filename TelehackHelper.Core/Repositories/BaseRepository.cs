using System;
using System.Data;
using System.Data.SQLite;
using log4net;

namespace TelehackHelper.Core.Repositories
{
    public abstract class BaseRepository<T> : IRepository
    {
        protected ILog Log;
        private readonly string _filePath;

        public BaseRepository(string filePath)
        {
            _filePath = filePath;

            InitializeDb();
        }

        #region SQLite

        protected void InitializeDb() => ExecuteWithConnectionInsideTransaction((connection, command) =>
        {
            CreateSchemaIfNotExists(command);
            InsertDefaultValuesIfNotExists(command);
        });

        protected SQLiteConnection GetConnection() => new SQLiteConnection($"Data Source={_filePath};Version=3;");

        public void ExecuteWithConnection(Action<SQLiteConnection> action)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                action(connection);
            }
        }

        public SQLT ExecuteWithConnection<SQLT>(Func<SQLiteConnection, SQLT> action)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                return action(connection);
            }
        }

        public void ExecuteWithConnectionInsideTransaction(Action<SQLiteConnection, SQLiteCommand> action)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            action(connection, command);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Log.Error(ex);
                            Log.Info("All changes were rolled back");
                        }
                    }
                }
            }
        }

        public SQLT ExecuteWithConnectionInsideTransaction<SQLT>(Func<SQLiteConnection, SQLiteCommand, SQLT> action)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            return action(connection, command);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Log.Error(ex);
                            Log.Info("All changes were rolled back");
                            return default(SQLT);
                        }
                    }
                }
            }
        }

        protected abstract void CreateSchemaIfNotExists(IDbCommand command);

        protected abstract void InsertDefaultValuesIfNotExists(IDbCommand command);

        #endregion

        public abstract void Insert(T parameter);
        public abstract void Update(int id, T parameter);
        public abstract void Delete(T parameter);
    }
}

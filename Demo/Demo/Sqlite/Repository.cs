using Demo.Common;
using MvvmCross.Plugins.Sqlite;
using SQLite;


namespace Demo.Sqlite
{
    public sealed class Repository
    {
        public readonly SQLiteConnection SqLiteConnection;

        private Repository(IMvxSqliteConnectionFactory factory)
        {
            SqLiteConnection= factory.GetConnection(Constants.DataBaseName);

            SqLiteConnection.CreateTable<RecordData>();
        }
    }
}

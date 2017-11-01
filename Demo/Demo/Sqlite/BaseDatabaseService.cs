using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Common;
using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace Demo.Sqlite
{
    public class BaseDatabaseService:IBaseDataService
    {
        protected RecordType RecordType { get; set; }
        protected readonly SQLiteConnection SqLiteConnection;

        public BaseDatabaseService(IMvxSqliteConnectionFactory factory)
        {
            SqLiteConnection = factory.GetConnection(Constants.DataBaseName);
            SqLiteConnection.CreateTable<RecordData>();
        }

      

        public void Delete(string recordId)
        {
            if (SqLiteConnection.Find<RecordData>(recordId) == null)
            {
                throw new NullReferenceException("not found this record");
            }
            SqLiteConnection.Delete(SqLiteConnection.Find<RecordData>(recordId));
        }

        public void QueryById(string recordId)
        {
            if (SqLiteConnection.Find<RecordData>(recordId) == null)
            {
                throw new NullReferenceException("not found this record");
            }
            SqLiteConnection.Delete(SqLiteConnection.Find<RecordData>(recordId));
        }

       
        public T1 Retrieve<T1>(long id) where T1 : class
        {
            throw new NotImplementedException();
        }

        public TableQuery<T1> RetrieveAll<T1>() where T1 : class
        {
            
            throw new NotImplementedException();
        }

        public void Add(RecordData record) 
        {
            
                SqLiteConnection.InsertOrReplace(record);
            
        }

        public List<RecordData> Query()
        {
            List<RecordData> result = null;
            result = SqLiteConnection.Table<RecordData>().ToList();
            return result;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Demo.Sqlite
{
    public interface IBaseDataService
    {
        T Retrieve<T>(long id) where T : class;
        TableQuery<T> RetrieveAll<T>() where T : class;
        void Add(RecordData record);
        List<RecordData> Query();
    }
}

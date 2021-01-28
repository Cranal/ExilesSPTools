using System.Data.SQLite;
using ExileSPToolsLib.DataContainers;

namespace ExileSPToolsLib.DataAccess.DataConverters
{
    public interface IDataConverter<T> where T: IDataContainer
    {
        T ConvertData(SQLiteDataReader dataReader);
    }
}
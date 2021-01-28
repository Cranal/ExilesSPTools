using System.Data.SQLite;
using ExileSPToolsLib.DataContainers;
using ExileSPToolsLib.Utility;

namespace ExileSPToolsLib.DataAccess.DataConverters
{
    public abstract class DataConverterBase<T> : IDataConverter<T> where T: IDataContainer
    {
        private DataFieldsManager dataFieldsManager;

        private DataFieldsManager DataFieldsManager 
        {
            get
            {
                if (this.dataFieldsManager == null)
                    this.dataFieldsManager = new DataFieldsManager();

                return this.dataFieldsManager;
            }
        }
        public T ConvertData(SQLiteDataReader dataReader)
        {
            T data = this.ConvertDataInternal(dataReader);

            return data;
        }

        protected abstract T ConvertDataInternal(SQLiteDataReader dataReader);

        protected string GetFieldName(string fieldPropertyName)
        {
            return this.DataFieldsManager.GetFieldName<T>(fieldPropertyName);
        }
    }
}
using System;
using ExileSPToolsLib.DataContainers;

namespace ExileSPToolsLib.Utility
{
    public class DataFieldsManager
    {
        public string GetFieldName<T>(string fieldPropertyName) where T: IDataContainer
        {
            return typeof(T).GetProperty(fieldPropertyName)?.
                GetCustomAttributes(false)[0] is FieldNameAttribute fieldNameAttribute 
                ? fieldNameAttribute.FieldName 
                : string.Empty;
        }

        public string GetTableName<T>() where T : IDataContainer
        {
            return (typeof(T).GetCustomAttributes(false)[0] as TableNameAttribute)?.TableName;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using ExileSPToolsLib.DataContainers;

namespace ExileSPToolsLib.Utility
{
    public class SqlManager
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
        
        public string GetSelectStatement<T>() where T: IDataContainer
        {
            var containerProperties = typeof(T).GetProperties();
            List<string> fieldsList = new List<string>();
            
            foreach (var property in containerProperties)
            {
                fieldsList.Add(this.DataFieldsManager.GetFieldName<T>(property.Name));
            }

            string sql = $"SELECT {string.Join(", ", fieldsList)} FROM {this.DataFieldsManager.GetTableName<T>()}";

            return sql;
        }

        public Tuple<string, List<SQLiteParameter>> GetUpdateCommand<T>(T dataContainer, List<string> propertiesToUpdate, string filterField) where T: IDataContainer
        {
            var type = dataContainer.GetType();
            StringBuilder updateSql = new StringBuilder();
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            updateSql.Append($"UPDATE {this.DataFieldsManager.GetTableName<T>()} ");

            foreach (var property in propertiesToUpdate)
            {
                var value = type.GetProperty(property)?.GetValue(dataContainer);

                if (value != null)
                {
                    updateSql.Append($" SET {this.DataFieldsManager.GetFieldName<T>(property)} = @{property} ");
                    parameters.Add(new SQLiteParameter($"@{property}", value));
                }
            }

            updateSql.Append($" WHERE {this.DataFieldsManager.GetFieldName<T>(filterField)} = @{filterField}");
            parameters.Add(new SQLiteParameter($"@{filterField}", type.GetProperty(filterField)?.GetValue(dataContainer)));
            
            return new Tuple<string, List<SQLiteParameter>>(updateSql.ToString(), parameters);
        }
    }
}
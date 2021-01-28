using System;
using System.Collections.Generic;
using System.Data.SQLite;
using ExileSPToolsLib.DataAccess.DataConverters;
using ExileSPToolsLib.DataContainers;

namespace ExileSPToolsLib.DataAccess
{
    public class DataManager
    {
        /// <summary>
        /// Gets or sets the <see cref="SQLiteConnection"/> which is used for database connection.
        /// </summary>
        private SQLiteConnection Connection 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Creates the <see cref="SQLiteConnection"/> which will be used to acces the specified game.db.
        /// </summary>
        /// <param name="gameDbPath">The path to Game.db file.</param>
        /// <exception cref="Exception">Throws when there is an error during the connection.</exception>
        private void CreateConnection(string gameDbPath)
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection($"Data Source={gameDbPath}");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.Connection = sqlite_conn;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DataManager"/> class.
        /// </summary>
        /// <param name="gameDbPath">The path to Game.db file.</param>
        public DataManager(string gameDbPath)
        {
            this.CreateConnection(gameDbPath);
        }

        public List<T> GetData<T>(string sqlRequest, IDataConverter<T> converter) where T: IDataContainer
        {
            List<T> dataList = new List<T>();
            var command = this.Connection.CreateCommand();
            command.CommandText = sqlRequest;

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var data = converter.ConvertData(reader);
                    dataList.Add(data);
                }
            }

            return dataList;
        }

        public void UpdateData(Tuple<string, List<SQLiteParameter>> updateData)
        {
            var command = this.Connection.CreateCommand();
            command.CommandText = updateData.Item1;
            updateData.Item2.ForEach(param => command.Parameters.Add(param));

            command.ExecuteNonQuery();
        }
    }
}
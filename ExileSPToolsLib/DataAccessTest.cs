using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ExileSPToolsLib
{
    public class DataAccessTest
    {
        public List<string> GetPlayers()
        {
            List<string> list = new List<string>();
            SQLiteConnection sqlite_conn;
            sqlite_conn = this.CreateConnection();

            var command = sqlite_conn.CreateCommand();
            command.CommandText = "SELECT characters.char_name, characters.level, guilds.name FROM characters "
                                  + " INNER JOIN guilds ON guilds.guildId = characters.guild";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string datastring = string.Empty;
                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        datastring += reader.GetValue(i).ToString();

                    }
                    list.Add(datastring);
                }

                return list;
            }
        }

        private SQLiteConnection CreateConnection()
        {
 
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=F:\\Back\\Conan\\Coop\\Saved\\Game.db");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
 
            }
            return sqlite_conn;
        }
    }
}
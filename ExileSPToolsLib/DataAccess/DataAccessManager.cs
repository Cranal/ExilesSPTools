using System.Data.SQLite;

namespace ExilesSPToolsLib.DataAccess
{
    public class DataAccessManager
    {
        public SQLiteConnection Connection { get; set; }
        
        public DataAccessManager(string gameDbPath)
        {
            
        }
    }
}
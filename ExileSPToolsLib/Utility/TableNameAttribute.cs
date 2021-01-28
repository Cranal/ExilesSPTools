using System;

namespace ExileSPToolsLib.Utility
{
    [AttributeUsage(AttributeTargets.Class)]  
    public class TableNameAttribute : Attribute
    {
        public string TableName { get; set; }
        
        public TableNameAttribute(string tableName)  
        {  
            this.TableName = tableName;
        }  
    }
}
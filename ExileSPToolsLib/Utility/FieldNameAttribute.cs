using System;

namespace ExileSPToolsLib.Utility
{
    [AttributeUsage(AttributeTargets.Property)]  
    public class FieldNameAttribute : Attribute
    {
        public string FieldName { get; set; }
        
        public FieldNameAttribute(string fieldName)  
        {  
            this.FieldName = fieldName;
        }  

    }
}
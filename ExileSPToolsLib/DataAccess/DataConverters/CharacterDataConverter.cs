using System;
using System.Data.SQLite;
using ExileSPToolsLib.DataContainers;

namespace ExileSPToolsLib.DataAccess.DataConverters
{
    public class CharacterDataConverter : DataConverterBase<CharacterDataContainer>
    {
        /// <summary>
        /// Converts the sql result data to <see cref="CharacterDataContainer"/> value.
        /// </summary>
        /// <param name="dataReader">The data reader which reads data from Db.</param>
        /// <returns>Filled <see cref="CharacterDataContainer"/>.</returns>
        protected override CharacterDataContainer ConvertDataInternal(SQLiteDataReader dataReader)
        {
            CharacterDataContainer dataContainer = new CharacterDataContainer();
            
            dataContainer.PlayerId = dataReader[this.GetFieldName(nameof(dataContainer.PlayerId))].ToString();
            dataContainer.Id = dataReader[this.GetFieldName(nameof(dataContainer.Id))].ToString();
            dataContainer.Level = Convert.ToInt32(dataReader[this.GetFieldName(nameof(dataContainer.Level))]);
            dataContainer.Rank = (byte) (dataReader[this.GetFieldName(nameof(dataContainer.Rank))] != DBNull.Value 
                ? Convert.ToByte(dataReader[this.GetFieldName(nameof(dataContainer.Rank))]) 
                : 0);
            
            dataContainer.Guild = dataReader[this.GetFieldName(nameof(dataContainer.Guild))] != DBNull.Value 
                ? Convert.ToInt32(dataReader[this.GetFieldName(nameof(dataContainer.Guild))]) 
                : 0;
            
            dataContainer.CharName = dataReader[this.GetFieldName(nameof(dataContainer.CharName))].ToString();

            return dataContainer;
        }
    }
}
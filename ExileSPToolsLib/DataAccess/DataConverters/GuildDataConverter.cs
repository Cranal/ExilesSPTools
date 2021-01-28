using System;
using System.Data.SQLite;
using ExileSPToolsLib.DataContainers;

namespace ExileSPToolsLib.DataAccess.DataConverters
{
    public class GuildDataConverter : DataConverterBase<GuildDataContainer>
    {
        /// <summary>
        /// Converts the sql result data to <see cref="GuildDataContainer"/> value.
        /// </summary>
        /// <param name="dataReader">The data reader which reads data from Db.</param>
        /// <returns>Filled <see cref="GuildDataContainer"/>.</returns>
        protected override GuildDataContainer ConvertDataInternal(SQLiteDataReader dataReader)
        {
            GuildDataContainer dataContainer = new GuildDataContainer();

            dataContainer.GuildId = dataReader[this.GetFieldName(nameof(dataContainer.GuildId))].ToString();
            dataContainer.Name = dataReader[this.GetFieldName(nameof(dataContainer.Name))].ToString();
            dataContainer.Owner = Convert.ToInt32(dataReader[this.GetFieldName(nameof(dataContainer.Owner))]);

            return dataContainer;
        }
    }
}
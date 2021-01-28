using ExileSPToolsLib.Utility;

namespace ExileSPToolsLib.DataContainers
{
    [TableName("guilds")]
    public class GuildDataContainer : IDataContainer
    {
        [FieldName("guildId")]
        public string GuildId { get; set; }

        [FieldName("name")]
        public string Name { get; set; }
        
        [FieldName("owner")]
        public int Owner { get; set; }
    }
}
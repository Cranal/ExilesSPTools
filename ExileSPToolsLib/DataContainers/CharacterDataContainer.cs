using ExileSPToolsLib.Utility;

namespace ExileSPToolsLib.DataContainers
{
    [TableName("characters")]
    public class CharacterDataContainer : IDataContainer
    {
        [FieldName("char_name")]
        public string CharName { get; set; }

        [FieldName("guild")]
        public int Guild { get; set; }
        
        [FieldName("id")]
        public string Id { get; set; }

        [FieldName("level")]
        public int Level { get; set; }
        
        [FieldName("playerId")]
        public string PlayerId { get; set; }

        [FieldName("rank")]
        public byte Rank { get; set; }
    }
}
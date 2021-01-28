using System.Collections.Generic;
using System.Linq;
using ExileSPToolsLib.DataAccess;
using ExileSPToolsLib.DataAccess.DataConverters;
using ExileSPToolsLib.DataContainers;
using ExileSPToolsLib.Utility;

namespace ExileSPToolsLib
{
    public class CharacterManager
    {
        private SqlManager SqlGenerator { get; }

        public CharacterManager(DataManager dataManager)
        {
            this.SqlGenerator = new SqlManager();
            this.DataManager = dataManager;
        }
        
        public List<CharacterDataContainer> Characters { get; set; }

        private DataManager DataManager { get; set; }
        
        public CharacterDataContainer GetActive()
        {
            return this.Characters.First(character => character.PlayerId == "1");
        }

        public List<CharacterDataContainer> GetCharacters()
        {
            this.Characters =  this.DataManager.GetData<CharacterDataContainer>(this.SqlGenerator.GetSelectStatement<CharacterDataContainer>(),
                new CharacterDataConverter());

            return this.Characters;
        }

        public void SetActive(CharacterDataContainer character)
        {
            this.Characters.ForEach(ch => ch.PlayerId = "999");

            if (character != null)
            {
                this.Characters.First(ch => ch.Id == character.Id).PlayerId = "1";
            }

            foreach (var characterToUpdate in this.Characters)
            {
                this.DataManager.UpdateData(this.SqlGenerator.GetUpdateCommand<CharacterDataContainer>(characterToUpdate, 
                    new List<string>()
                    {
                        nameof(CharacterDataContainer.PlayerId)
                    }, nameof(CharacterDataContainer.Id)));
            }
        }
    }
}
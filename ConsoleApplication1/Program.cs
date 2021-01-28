using System;
using System.Linq;
using ExileSPToolsLib;
using ExileSPToolsLib.DataAccess;
using ExileSPToolsLib.DataAccess.DataConverters;
using ExileSPToolsLib.DataContainers;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CharacterManager manager = new CharacterManager(new DataManager(@"F:\Back\Conan\Coop\Saved\Game.db"));
            var characters = manager.GetCharacters();
            
            manager.SetActive(null);
        }
    }
}
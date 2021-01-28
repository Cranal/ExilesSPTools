using System;
using ExilesSPToolsLib;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DataAccessTest test = new DataAccessTest();
            var testData = test.GetPlayers();
            
            testData.ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
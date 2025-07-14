using System;
using System.Collections.Generic;

namespace ScriptureMemorizerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Biblioteca de exemplos (stretch goal)
            var scriptures = new List<Scripture>
            {
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world that he gave his one and only Son, " +
                    "that whoever believes in him shall not perish but have eternal life."
                ),
                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all your heart and lean not on your own understanding; " +
                    "in all your ways submit to him, and he will make your paths straight."
                )
            };

            var rnd = new Random();
            var selected = scriptures[rnd.Next(scriptures.Count)];

            while (true)
            {
                Console.Clear();
                selected.Display();

                if (selected.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Well done!");
                    break;
                }

                Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
                var input = Console.ReadLine();
                if (input?.Equals("quit", StringComparison.OrdinalIgnoreCase) == true)
                    break;

                selected.HideRandomWords(3);
            }
        }
    }
}

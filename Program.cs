using BuilderWire.Models;
using BuilderWire.Services;
using System;
using System.IO;
using System.Linq;

namespace BuilderWire
{
    internal class Program
    {
        private static IParagraphService paragraphService;
        private static IOutputService outputService;
        private static IWordService wordService;

        static void Main(string[] args)
        {
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Please provide articlePath & wordsPath");
                Console.Read();
                return;
            }

            //since there's no NuGet we will instantiate service like this
            paragraphService = new ParagraphService();
            outputService = new OutputService();
            wordService = new WordService();

            var words = wordService.GetWords(args[1]);
            var paragraphs = paragraphService.CleanParagraph(File.ReadAllText(args[0]), words);
            var output = outputService.ProcessParagraph(paragraphs, words);
            var displayList = outputService.DisplayOutput(output);

            foreach (var display in displayList)
            {
                Console.WriteLine(display);
            }

            Console.Read();
        }
    }
}

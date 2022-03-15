using BuilderWire.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuilderWire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Please provide articlePath & wordsPath");
                Console.Read();
                return;
            }

            var words = File.ReadAllText(args[1])
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new Word
                {
                    Text = w
                })
                .ToList();

            var paragraphs = CleanParagraph(File.ReadAllText(args[0]), words);
            var outputList = ProcessParagraph(paragraphs, words);
            var line = 'a';
            var lineIncrement = 0;

            foreach (var output in outputList)
            {
                Console.WriteLine($"{GetLineNumber(line, lineIncrement)}. {output.Word} {{{output.Occurrences.Count}:{string.Join(',', output.Occurrences)}}}");

                if (line == 'z')
                {
                    line = 'a';
                    lineIncrement++;
                }
                else
                {
                    line++;
                }
            }

            Console.Read();
        }

        private static List<Paragraph> CleanParagraph(string paragraph, List<Word> words)
        {
            foreach (var word in words)
            {
                paragraph = paragraph.Replace(word.Text, word.TransformedText, StringComparison.OrdinalIgnoreCase);
            }

            return paragraph
                .Split(". ", StringSplitOptions.RemoveEmptyEntries)
                .Select(p => new Paragraph
                {
                    Sentence = p
                })
                .ToList();
        }

        private static List<Output> ProcessParagraph(List<Paragraph> paragraphs, List<Word> words)
        {
            var outputList = new List<Output>();

            foreach (var word in words)
            {
                var output = new Output
                {
                    Word = word.Text,
                    Occurrences = new List<int>()
                };

                for (var i = 0; i < paragraphs.Count; i++)
                {
                    foreach (var wordInSentence in paragraphs[i].Sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                    {
                        var currentWord = wordInSentence
                            .Replace(".", string.Empty)
                            .Replace(",", string.Empty);

                        if (string.Equals(currentWord, word.TransformedText, StringComparison.OrdinalIgnoreCase))
                        {
                            output.Occurrences.Add(i + 1);
                        }
                    }
                }

                outputList.Add(output);
            }

            return outputList;
        }

        private static string GetLineNumber(char line, int lineIncrement)
        {
            var newLine = string.Empty;

            for (var i = 0; i <= lineIncrement; i++)
            {
                newLine += line.ToString();
            }

            return newLine;
        }
    }
}

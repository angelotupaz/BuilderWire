using BuilderWire.Models;
using System;
using System.Collections.Generic;

namespace BuilderWire.Services
{
    public class OutputService : IOutputService
    {
        public List<Output> ProcessParagraph(List<Paragraph> paragraphs, List<Word> words)
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
                    foreach (var wordInSentence in paragraphs[i].TransformedText.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (string.Equals(wordInSentence, word.TransformedText, StringComparison.OrdinalIgnoreCase))
                        {
                            output.Occurrences.Add(i + 1);
                        }
                    }
                }

                outputList.Add(output);
            }

            return outputList;
        }

        public List<string> DisplayOutput(List<Output> output)
        {
            var result = new List<string>();
            var line = 'a';
            var lineIncrement = 0;

            foreach (var entry in output)
            {
                result.Add($"{GetLineNumber(line, lineIncrement)}. {entry.Word} {{{entry.Occurrences.Count}:{string.Join(',', entry.Occurrences)}}}");

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

            return result;
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

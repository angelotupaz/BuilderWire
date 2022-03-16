using BuilderWire.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderWire.Services
{
    public class ParagraphService : IParagraphService
    {
        public List<Paragraph> CleanParagraph(string paragraph, List<Word> words)
        {
            foreach (var word in words)
            {
                paragraph = paragraph.Replace(word.Text, word.TransformedText, StringComparison.OrdinalIgnoreCase);
            }

            return paragraph
                .Split(". ", StringSplitOptions.RemoveEmptyEntries)
                .Select(p => new Paragraph
                {
                    Text = p
                })
                .ToList();
        }
    }
}

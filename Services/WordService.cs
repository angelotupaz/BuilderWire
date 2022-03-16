using BuilderWire.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuilderWire.Services
{
    public class WordService : IWordService
    {
        List<Word> IWordService.GetWords(string text)
        {
            return File.ReadAllText(text)
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new Word
                {
                    Text = w
                })
                .ToList();
        }
    }
}

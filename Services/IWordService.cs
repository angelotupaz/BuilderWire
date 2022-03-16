using BuilderWire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderWire.Services
{
    public interface IWordService
    {
        List<Word> GetWords(string text);
    }
}

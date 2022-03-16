using BuilderWire.Models;
using System.Collections.Generic;

namespace BuilderWire.Services
{
    public interface IOutputService
    {
        List<Output> ProcessParagraph(List<Paragraph> paragraphs, List<Word> words);
        List<string> DisplayOutput(List<Output> output);
    }
}

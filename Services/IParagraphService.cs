using BuilderWire.Models;
using System.Collections.Generic;

namespace BuilderWire.Services
{
    public interface IParagraphService
    {
        List<Paragraph> CleanParagraph(string paragraph, List<Word> words);
    }
}

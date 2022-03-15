namespace BuilderWire.Models
{
    public class Word
    {
        public string Text { get; set; }

        public string TransformedText
        {
            get
            {
                return Text.Replace(".", string.Empty);
            }
        }
    }
}

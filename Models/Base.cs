namespace BuilderWire.Models
{
    public abstract class Base
    {
        public string Text { get; set; }
        public abstract string TransformedText { get; }
    }
}

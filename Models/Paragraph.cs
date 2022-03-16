namespace BuilderWire.Models
{
    public class Paragraph : Base
    {
        public override string TransformedText
        {
            get => Text?
                .Replace("/", string.Empty)
                .Replace("`", string.Empty)
                .Replace("!", string.Empty)
                .Replace("@", string.Empty)
                .Replace("#", string.Empty)
                .Replace("$", string.Empty)
                .Replace("%", string.Empty)
                .Replace("^", string.Empty)
                .Replace("&", string.Empty)
                .Replace("*", string.Empty)
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace("-", string.Empty)
                .Replace("_", string.Empty)
                .Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("\\", string.Empty)
                .Replace("|", string.Empty)
                .Replace(".", string.Empty)
                .Replace(",", string.Empty);
        }
    }
}

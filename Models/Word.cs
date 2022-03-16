namespace BuilderWire.Models
{
    public class Word : Base
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

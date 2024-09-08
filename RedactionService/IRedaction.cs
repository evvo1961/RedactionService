namespace RedactionService
{
    public interface IRedaction
    {
        string? RedactedText { get; set; }

        string ReplaceText(string words, string textstring);
    }
}
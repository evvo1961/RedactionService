
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace RedactionService
{
    public class Redaction : IRedaction
    {             
        public String? RedactedText { get; set; }

        public String ReplaceText(string words, string textstring)
        {
            string words_to_redact = words;                        
            string[] REDACTION_WORDS = words_to_redact.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            RedactedText = Regex.Replace(textstring, "\\b" + string.Join("\\b|\\b", REDACTION_WORDS) + "\\b", "REDACTED", RegexOptions.IgnoreCase);

            return RedactedText;
        }
    }
}

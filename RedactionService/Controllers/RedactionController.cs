using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace RedactionService.Controllers
{
    [ApiController]
    [Route("redact")]
    public class RedactionController : ControllerBase
    {       
        private string text_for_redaction = "A dog, a monkey or a dolphin are all mammals. A snake, however, is not a mammal, it is a reptile. Who can say what a DogSnake is?";
        private string? get_response_text = string.Empty;
        private readonly ILogger<RedactionController> _logger;
        private readonly IConfiguration _config;
        private readonly IRedaction _redaction;

        public RedactionController(ILogger<RedactionController> logger, IConfiguration config, IRedaction redaction)
        {
            _logger = logger;
            _config = config;  
            _redaction = redaction;
        }

        [HttpGet(Name = "Get")]
        public String Get()
        {
            get_response_text = _config["ConfigSettings:TextForGetResponse"];
            return get_response_text;
        }

        [HttpPost(Name = "Post")]
        public String Post()
        {
            string? words = _config["ConfigSettings:Words"];            
            var redactedtext = _redaction.ReplaceText(words, text_for_redaction);

            _logger.LogInformation(DateTime.Now + " " + text_for_redaction);

            return redactedtext;

        }
    }
}

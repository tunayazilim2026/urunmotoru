using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XmlController : ControllerBase
    {
        private readonly XmlParserService _parser;
        private readonly RuleEngineService _rule;

        public XmlController()
        {
            _parser = new XmlParserService();
            _rule = new RuleEngineService();
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import(XmlImportRequest request)
        {
            using var http = new HttpClient();
            var xmlContent = await http.GetStringAsync(request.XmlUrl);

            var products = _parser.Parse(xmlContent);

            var cleaned = products
                .Select(p => _rule.Clean(p))
                .ToList();

            return Ok(cleaned);
        }
    }
}

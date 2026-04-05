using System.Xml.Linq;
using api.Models;

namespace api.Services
{
    public class XmlParserService
    {
        public List<ProductDto> Parse(string xmlContent)
        {
            var doc = XDocument.Parse(xmlContent);

            var products = doc.Descendants("food")
                .Select(x => new ProductDto
                {
                    Title = x.Element("name")?.Value,
                    Description = x.Element("description")?.Value,
                    Brand = "",
                    Category = "",
                    Price = decimal.TryParse(
                        x.Element("price")?.Value?.Replace("$", "").Trim(),
                        out var p
                    ) ? p : 0
                })
                .ToList();

            return products;
        }
    }
}

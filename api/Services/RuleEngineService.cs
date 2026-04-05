using api.Models;

namespace api.Services
{
    public class RuleEngineService
    {
        public ProductDto Clean(ProductDto product)
        {
            if (!string.IsNullOrEmpty(product.Title))
            {
                product.Title = product.Title
                    .Replace("!!!", "")
                    .Replace("%100", "")
                    .Trim();
            }

            if (!string.IsNullOrEmpty(product.Description))
            {
                product.Description = product.Description
                    .Replace("KAÇIRMA", "")
                    .Trim();
            }

            return product;
        }
    }
}

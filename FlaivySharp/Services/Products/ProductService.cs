using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlaivySharp.Entities;
using FlaivySharp.Extensions;
using FlaivySharp.Infrastructure;

namespace FlaivySharp.Services.Products
{
    public class ProductService : FlaivyService
    {
        public ProductService(string accessToken) : base(accessToken)
        {
        }

        public virtual async Task<ProductsQueryResponse> GetProducts(string modifiedDate = null)
        {
            var requestBuilder = new StringBuilder().Append(FlaivyUtility.Articles);
            if (modifiedDate != null) requestBuilder.Append($"?modifiedSince={modifiedDate}");

            var req = PrepareRequest(requestBuilder.ToString());
            return await ExecuteRequestAsync<ProductsQueryResponse>(req, HttpMethod.Get);
        }

        public virtual async Task<object> UpdateStock(string articleNumber, UpdateStockRequest updateStockRequest)
        {
            var req = PrepareRequest($"{FlaivyUtility.Articles}/{articleNumber}/quantities");
            HttpContent content = null;

            if (updateStockRequest != null)
            {
                var body = updateStockRequest.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }
    }
}
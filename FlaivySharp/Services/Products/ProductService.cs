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

        public virtual async Task<ProductsQueryResponse> GetProducts(int page, int pageSize, string lastModified = null)
        {
            var requestBuilder = new StringBuilder().Append(Utils.Articles);
            requestBuilder.Append(lastModified != null
                ? $"?lastModified={lastModified}&page={page}&pageSize={pageSize}"
                : $"?page={page}&pageSize={pageSize}");

            var req = PrepareRequest(requestBuilder.ToString());
            return await ExecuteRequestAsync<ProductsQueryResponse>(req, HttpMethod.Get);
        }

        public virtual async Task<UpdateStockResponse> UpdateStock(string articleNumber, UpdateStockRequest updateStockRequest)
        {
            var req = PrepareRequest($"{Utils.Articles}/{articleNumber}/quantities");
            HttpContent content = null;

            if (updateStockRequest != null)
            {
                var body = updateStockRequest.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<UpdateStockResponse>(req, HttpMethod.Put, content);
        }
    }
}
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlaivySharp.Entities;
using FlaivySharp.Extensions;
using FlaivySharp.Infrastructure;

namespace FlaivySharp.Services.Orders
{
    public class OrderService : FlaivyService
    {
        public OrderService(string accessToken) : base(accessToken)
        {
        }

        public virtual async Task<OrdersQueryResponse> GetOrders(int page, int pageSize, string lastModified = null)
        {
            var requestBuilder = new StringBuilder().Append(Utils.Orders);
            requestBuilder.Append(lastModified != null
                ? $"?lastModified={lastModified}&page={page}&pageSize={pageSize}"
                : $"?page={page}&pageSize={pageSize}");

            var req = PrepareRequest(requestBuilder.ToString());
            return await ExecuteRequestAsync<OrdersQueryResponse>(req, HttpMethod.Get);
        }

        public virtual async Task<SuppliersQueryResponse> GetSuppliers()
        {
            var req = PrepareRequest(Utils.Suppliers);
            return await ExecuteRequestAsync<SuppliersQueryResponse>(req, HttpMethod.Get);
        }

        public virtual async Task<FlaivyOrder> GetOrder(string orderId)
        {                 
            var req = PrepareRequest($"{Utils.Orders}/{orderId}");
            return await ExecuteRequestAsync<FlaivyOrder>(req, HttpMethod.Get);   
        }

        public virtual async Task<EntityPostOperationResponse> CreateOrUpdateOrder(CreateOrUpdateOrderRequest request)
        {
            var req = PrepareRequest(Utils.Orders);
            HttpContent content = null;

            if (request != null)
            {
                var body = request.ToDictionary();
                content = new JsonContent(body);
            }

            return await ExecuteRequestAsync<EntityPostOperationResponse>(req, HttpMethod.Post, content);
        }

        public virtual async Task<EntityPostOperationResponse> CancelOrder(string orderNumber)
        {
            var req = PrepareRequest($"{Utils.Orders}/{orderNumber}/cancel");
            return await ExecuteRequestAsync<EntityPostOperationResponse>(req, HttpMethod.Put);
        }
    }
}
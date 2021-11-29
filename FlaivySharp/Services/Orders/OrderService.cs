using System.Net.Http;
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

        public virtual async Task<OrdersQueryResponse> GetOrders(int page, int pageSize)
        {
            var req = PrepareRequest($"{FlaivyUtility.Orders}?page={page}&pageSize={pageSize}");
            return await ExecuteRequestAsync<OrdersQueryResponse>(req, HttpMethod.Get);
        }

        public virtual async Task<SuppliersQueryResponse> GetSuppliers()
        {
            var req = PrepareRequest(FlaivyUtility.Suppliers);
            return await ExecuteRequestAsync<SuppliersQueryResponse>(req, HttpMethod.Get);
        }

        public virtual async Task<FlaivyOrder> GetOrder(string orderId)
        {                 
            var req = PrepareRequest($"{FlaivyUtility.Orders}/{orderId}");
            return await ExecuteRequestAsync<FlaivyOrder>(req, HttpMethod.Get);   
        }

        public virtual async Task<object> CreateOrUpdateOrder(CreateOrUpdateOrderRequest request)
        {
            var req = PrepareRequest(FlaivyUtility.Orders);
            HttpContent content = null;

            if (request != null)
            {
                var body = request.ToDictionary();
                content = new JsonContent(body);
            }

            return await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }
    }
}
using System;
using System.Threading.Tasks;
using FlaivySharp.Entities;
using FlaivySharp.Services.Orders;
using FlaivySharp.Services.Products;

namespace TestFlaivy
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {

                var token = "65I0rOfM7SrOXHycx9eV87f9k";

                try
                {
                    #region Product

                    var productService = new ProductService(token);
                    // var articles = await productService.GetProducts(DateTime.Now.AddDays(-2).ToString("s"));
                    // var req = await productService.UpdateStock("789234234234", new UpdateStockRequest
                    // {
                    //     QuantityInStock = 100
                    // });

                    #endregion


                    #region Order

                    var orderService = new OrderService(token);
                    // var orders = await orderService.GetOrders();
                    //var suppliers = await orderService.GetSuppliers();
                    // var order = await orderService.GetOrder("96337468");
                    var res = await orderService.CreateOrUpdateOrder(new UpdateOrderRequest
                    {
                        

                    });

                    #endregion
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }).GetAwaiter().GetResult();
        }
    }
}
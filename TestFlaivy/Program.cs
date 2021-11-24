using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaivySharp.Entities;
using FlaivySharp.Infrastructure;
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
                    var articles = await productService.GetProducts("2018-10-26");
                    // var req = await productService.UpdateStock("XXXX", new UpdateStockRequest
                    // {
                    //     QuantityInStock = 100
                    // });

                    #endregion


                    #region Order

                    var orderService = new OrderService(token);
                    var orders = await orderService.GetOrders();
                    var suppliers = await orderService.GetSuppliers();
                    // var order = await orderService.GetOrder("96337468");
                    var res = await orderService.CreateOrUpdateOrder(new UpdateOrderRequest
                    {

                    });

                    #endregion
                }
                catch (FlaivyException ex)
                {

                }
                catch (Exception e)
                {
                    if (e.Message == "")
                    {

                    }
                    Console.WriteLine(e);
                    throw;
                }
            }).GetAwaiter().GetResult();
        }
    }
}

using System;
using System.Text;

namespace FlaivySharp.Infrastructure
{
    public static class Utils
    {
        public const string Articles = "articles";
        public const string Orders = "orders";
        public const string Suppliers = "suppliers";

        public const int MaxPageSize = 1000;
        public const string PrimePenguin = "PrimePenguin";
        public const string Flaivy = "Flaivy";
        public const string DecryptKey = "sblw-3hn8-sqoy19";

        public const string FlaivyAccessToken = "65I0rOfM7SrOXHycx9eV87f9k"; // TODO: Flaivy Access Token
        public const string UserName = "ajay@primepenguin.com";
        public const string Password = "B66ItJ75YZ";
        public const string Warehouse = "3PLOG";
        public const string Client = "225-3P";
        public const string WarehouseUri = "https://swedentradelab.lxir.se/RESTAPI";

        public static string GenerateExtendApiAccessToken() => Convert.ToBase64String(Encoding.ASCII.GetBytes(UserName + ":" + Password));
    }
}
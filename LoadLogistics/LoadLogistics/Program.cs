using LoadLogistics.Models;
using LoadLogistics.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadLogistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockService stock = new StockService();
            int loadCount = stock.GetNumberOfLoadsThatCanBeFulfilled(TestData.customers.SingleOrDefault(t => t.Id == 1));
            Console.WriteLine("Customer's fulfiled load count : " + loadCount);


            IEnumerable<Customer> customerList = stock.GetCustomersWithAtleastOneLoad();
        }
    }
}

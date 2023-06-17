using LoadLogistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadLogistics
{
    public class TestData
    {
        public static List<Customer> customers = new List<Customer>()
        {
             new Customer()
             {
                Id = 1,
                Name = "Jony"
             },
            new Customer()
            {
                Id = 2,
                Name = "Jack"
            }
        };
        public static List<Carrier> carriers = new List<Carrier>()
        {
            new Carrier()
            {
                Id = 1,
                Name = "Flipkart"
            },
            new Carrier()
            {
                Id = 2,
                Name = "Amazon"
            }
        };

        public static List<Warehouse> warehouses = new List<Warehouse>()
        {
            new Warehouse()
            {
                WarehouseId = 1,
                Address = "3377 Sandstone Court, Pleasanton CA 94588"
            },
            new Warehouse()
            {
                WarehouseId = 2,
                Address = "6145 East Castro Valley Boulevard, Castro Valley CA 94552"
            }
        };

        public static List<FreightItem> freightItems = new List<FreightItem>()
        {
            new FreightItem()
            {
                Carrier = carriers.SingleOrDefault(a => a.Id == 1),
                FreightItemId = 1,
                Name = "Fridge",
                Sku = "M01"
            },
            new FreightItem()
            {
                Carrier = carriers.SingleOrDefault(a => a.Id == 2),
                FreightItemId = 2,
                Name = "Washing machine",
                Sku = "M02"
            }
        };

        public static List<Stock> stocks = new List<Stock>()
        {
            new Stock()
            {
                FreightItem = freightItems.SingleOrDefault(a => a.FreightItemId == 1),
                StockId = 1,
                StockQuantity = 1,
                Warehouse = warehouses.SingleOrDefault(a => a.WarehouseId == 1)

            },
            new Stock()
            {
                FreightItem = freightItems.SingleOrDefault(a => a.FreightItemId == 2),
                StockId = 2,
                StockQuantity = 3,
                Warehouse = warehouses.SingleOrDefault(a => a.WarehouseId == 2)
            }
        };

        public static List<Load> loads = new List<Load>()
        {
            new Load()
            {
                Id = 1,
                Carrier = carriers.SingleOrDefault(a => a.Id == 1),
                Customer = customers.SingleOrDefault(a => a.Id == 1),
                FromAddress = "777 Brockton Avenue, Abington MA 2351",
                ToAddress = "30 Memorial Drive, Avon MA 2322",
                Status = "Assigned",
                PlacedAt = new DateTime(2023, 6, 16),
                DeliveryTime = new DateTime(2023, 7, 16),
                LoadItems = new List<LoadItem>()
                {
                     new LoadItem()
                     {
                        FreightItem = freightItems.SingleOrDefault(a => a.FreightItemId == 1),
                        LoadItemId = 1,
                        Quantity = 3
                     },
                     new LoadItem()
                     {
                        FreightItem = freightItems.SingleOrDefault(a => a.FreightItemId == 2),
                        LoadItemId = 2,
                        Quantity = 3
                     }
                }
            },
            new Load()
            {
                Id = 2,
                Carrier = carriers.SingleOrDefault(a => a.Id == 1),
                Customer = customers.SingleOrDefault(a => a.Id == 1),
                FromAddress = "250 Hartford Avenue, Bellingham MA 2019",
                ToAddress = "700 Oak Street, Brockton MA 2301",
                Status = "Dispatched",
                PlacedAt = new DateTime(2023, 6, 16),
                DeliveryTime = new DateTime(2023, 7, 16),
                LoadItems = new List<LoadItem>()
                {
                    new LoadItem()
                    {
                        FreightItem = freightItems.SingleOrDefault(a => a.FreightItemId == 1),
                        LoadItemId = 4,
                        Quantity = 5
                    },
                    new LoadItem()
                    {
                        FreightItem = freightItems.SingleOrDefault(a => a.FreightItemId == 2),
                        LoadItemId = 5,
                        Quantity = 9
                    }
                }
            }
        };
    }
}

using LoadLogistics.Models;
using System.Collections.Generic;
using System.Linq;

namespace LoadLogistics.Services
{
    internal class StockService
    {
        //It returns load fulfillment in a particular warehouse
        public bool CanFulfillLoadFromWarehouse(Load load, Warehouse warehouse)
        {
            foreach (var loadItem in load.LoadItems)
            {
                // To check whether the load item in warehouse is available or not
                var itemWarehouseExist = TestData.stocks.SingleOrDefault(stk => stk.Warehouse.WarehouseId == warehouse.WarehouseId && stk.FreightItem.FreightItemId == loadItem.FreightItem.FreightItemId);
                if (itemWarehouseExist != null)
                {
                    // To check whether the quantity is available or not
                    if (loadItem.Quantity > itemWarehouseExist.StockQuantity)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        // It returns loads count which is fulfilled by warehouse for a customer
        public int GetNumberOfLoadsThatCanBeFulfilled(Customer customer)
        {
            int fulFillcount = 0;
            // Get all the loads of the customer ordered by delivery time
            List<Load> customerLoads = TestData.loads.Where(ld => ld.Customer.Id == customer.Id).OrderBy(ld => ld.DeliveryTime).ToList();
            foreach (var load in customerLoads)
            {
                foreach (var warehouse in TestData.warehouses)
                {
                    if (CanFulfillLoadFromWarehouse(load, warehouse))
                    {
                        fulFillcount++;
                        break;
                    }
                }
            }
            return fulFillcount;
        }
    }
}

using LoadLogistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

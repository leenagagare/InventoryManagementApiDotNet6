using System.Collections.Generic;

namespace InventoryManagementServiceLayer.Contract
{
    public class GetItemsResponse: InventoryServiceResponse
    {
        public List<ItemDto> Items { get; set; }
    }
}

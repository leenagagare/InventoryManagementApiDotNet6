namespace InventoryManagementServiceLayer.Contract
{
    public class UpdateItemRequest : InventoryServiceResponse
    {
        public ItemDto Item { get; set; }
    }
}

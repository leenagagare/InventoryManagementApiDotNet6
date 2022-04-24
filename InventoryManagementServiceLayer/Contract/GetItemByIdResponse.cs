namespace InventoryManagementServiceLayer.Contract
{
    public class GetItemByIdResponse: InventoryServiceResponse
    {
        public ItemDto Item { get; set; }
    }
}

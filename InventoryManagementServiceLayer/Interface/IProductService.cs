

using InventoryManagementDataLayer.Entities;
using InventoryManagementApi.Models.Products;
using InventoryManagementDataLayer.Entities;
using InventoryManagementServiceLayer.Contract;

namespace InventoryManagementServiceLayer.Interface
{
    public interface IProductService
    {
        Task<GetItemsResponse> GetAllItems();

        Task<GetItemByIdResponse> GetItemById(string itemId);
        
        Task<GetItemByIdResponse> GetItemByName(string name);
        Task<AddItemResponse> AddItem(AddItemRequest request);

        Task<UpdateItemResponse> UpdateItem(UpdateItemRequest request);

        Task<RemoveItemResponse> RemoveItem(string itemId);
        Task<RemoveItemResponse> RemoveAll();
    }

}

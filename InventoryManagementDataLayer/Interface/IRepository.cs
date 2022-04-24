using InventoryManagementDataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDataLayer.Interface
{
    public interface IRepository
    {
    

        Task<List<Product>> GetAllItems();

        Task<Product> GetItemById(string itemId);

        Task<Product> GetItemByName(string name);
        Task<int> AddItem(Product request);

        Task<bool> UpdateItem(Product request);

        Task<bool> RemoveItem(string itemId);
        Task<bool> RemoveAll();

    }



}

using InventoryManagementDataLayer.Data;
using InventoryManagementDataLayer.Entities;
using InventoryManagementDataLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDataLayer.Repository
{
    public class ProductRepository : IRepository
    {

        public async Task<List<Product>> GetAllItems()
        {
            using (var _inventoryDataContext = new InventoryDbContext())
            {
                return await _inventoryDataContext.Products.ToListAsync();
            }
        }

        public async Task<Product> GetItemById(string ProductCode)
        {
            using (var _inventoryDataContext = new InventoryDbContext())
            {
                return await _inventoryDataContext.Products.FirstOrDefaultAsync(x => x.ProductCode == Convert.ToInt32(ProductCode));
            }
        }
        public async Task<Product> GetItemByName(string name)
        {
            using (var _inventoryDataContext = new InventoryDbContext())
            {
                return await _inventoryDataContext.Products.FirstOrDefaultAsync(x => x.Name == Convert.ToString(name));
            }
        }
        public async Task<int> AddItem(Product item)
        {
            using (var _inventoryDataContext = new InventoryDbContext())
            {
                await _inventoryDataContext.Products.AddAsync(item);
                await _inventoryDataContext.SaveChangesAsync();
                return item.ProductCode;
            }
        }

        public async Task<bool> UpdateItem(Product item)
        {
            using (var _inventoryDataContext = new InventoryDbContext())
            {
                var itemToBeUpdated = await _inventoryDataContext.Products.FirstOrDefaultAsync(x => x.ProductCode == item.ProductCode);
                if (itemToBeUpdated != null)
                {
                    itemToBeUpdated.ProductCode = item.ProductCode;
                    itemToBeUpdated.ProductDescription = item.ProductDescription;
                    itemToBeUpdated.Price = item.Price;
                    itemToBeUpdated.Name = item.Name;
                    await _inventoryDataContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
        }

        public async Task<bool> RemoveItem(string ProductCode)
        {
            using (var _inventoryDataContext = new InventoryDbContext())
            {
                var itemToBeDeleted = await _inventoryDataContext.Products.FirstOrDefaultAsync(x => x.ProductCode == Convert.ToInt32(ProductCode));
                if (itemToBeDeleted != null)
                {
                    _inventoryDataContext.Products.Remove(itemToBeDeleted);
                    await _inventoryDataContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
        }
        public async Task<bool> RemoveAll()
        {
            using (var _inventoryDataContext = new InventoryDbContext())
            {
                var itemToBeDeleted = await _inventoryDataContext.Products.ToListAsync();
                if (itemToBeDeleted != null)
                {
                    _inventoryDataContext.Products.RemoveRange(itemToBeDeleted);
                    await _inventoryDataContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
        }
        
    }
}

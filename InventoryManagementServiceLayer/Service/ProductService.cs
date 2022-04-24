
using InventoryManagementApi.Models.Products;
using InventoryManagementDataLayer.Data;
using InventoryManagementDataLayer.Entities;
using InventoryManagementDataLayer.Interface;
using InventoryManagementServiceLayer.Contract;
using InventoryManagementServiceLayer.Interface;
using System.Globalization;

namespace InventoryManagementServiceLayer.Services;

public class ProductService : IProductService
{
    private readonly IRepository _productRepository;

    public ProductService(IRepository ProductRepository)
    {
        _productRepository = ProductRepository;
    }
    public async Task<GetItemsResponse> GetAllItems()
    {
        try
        {
            var items = await _productRepository.GetAllItems();
            var itemsDto = new List<ItemDto>();
            foreach (var item in items)
            {
                itemsDto.Add(new ItemDto()
                {
                    ProductCode = item.ProductCode.ToString(),
                    Name = item.Name,
                    Price = item.Price.ToString(CultureInfo.InvariantCulture),
                    ProductDescription = item.ProductDescription
                });
            }

            return new GetItemsResponse()
            {
                Items = itemsDto
            };
        }
        catch (Exception ex)
        {
            return new GetItemsResponse()
            {
                ErrorMessage = ex.Message
            };
        }

    }

    public async Task<GetItemByIdResponse> GetItemById(string itemId)
    {
        try
        {
            if (string.IsNullOrEmpty(itemId) || !int.TryParse(itemId, out _))
            {
                throw new Exception("Item id is not valid !");
            }
            var item = await _productRepository.GetItemById(itemId);

            if (item == null)
            {
                return new GetItemByIdResponse()
                {
                    ErrorMessage = "The item with specified id could not be found!"
                };
            }
            return new GetItemByIdResponse()
            {
                Item = new ItemDto()
                {
                    ProductCode = item.ProductCode.ToString(),
                    Name = item.Name,
                    Price = item.Price.ToString(CultureInfo.InvariantCulture),
                    ProductDescription = item.ProductDescription
                }
            };
        }
        catch (Exception ex)
        {
            return new GetItemByIdResponse()
            {
                ErrorMessage = ex.Message
            };
        }
    }
    public async Task<GetItemByIdResponse> GetItemByName(string name)
    {
        try
        {
           
            var item = await _productRepository.GetItemByName(name);

            if (item == null)
            {
                return new GetItemByIdResponse()
                {
                    ErrorMessage = "The item with specified id could not be found!"
                };
            }
            return new GetItemByIdResponse()
            {
                Item = new ItemDto()
                {
                    ProductCode = item.ProductCode.ToString(),
                    Name = item.Name,
                    Price = item.Price.ToString(CultureInfo.InvariantCulture),
                    ProductDescription = item.ProductDescription
                }
            };
        }
        catch (Exception ex)
        {
            return new GetItemByIdResponse()
            {
                ErrorMessage = ex.Message
            };
        }
    }
    public async Task<AddItemResponse> AddItem(AddItemRequest request)
    {
        try
        {
            Validate(request.Item);
            var itemToBeAdded = new InventoryManagementDataLayer.Entities.Product()
            {
                Name = request.Item.Name,
                ProductDescription = request.Item.ProductDescription,
                Price = Convert.ToDecimal(request.Item.Price)
            };
            var addedItemId = await _productRepository.AddItem(itemToBeAdded);
            return new AddItemResponse()
            {
                AddedItemId = addedItemId
            };
        }
        catch (Exception ex)
        {
            return new AddItemResponse()
            {
                ErrorMessage = ex.Message
            };
        }
    }

    public async Task<UpdateItemResponse> UpdateItem(UpdateItemRequest request)
    {
        try
        {
            Validate(request.Item);
            var itemToBeUpdated = new InventoryManagementDataLayer.Entities.Product()
            {
                ProductCode = Convert.ToInt32(request.Item.ProductCode),
                Name = request.Item.Name,
                ProductDescription = request.Item.ProductDescription,
                Price = Convert.ToDecimal(request.Item.Price)
            };
            var result = await _productRepository.UpdateItem(itemToBeUpdated);
            return result ? new UpdateItemResponse() :
                new UpdateItemResponse()
                {
                    ErrorMessage = "The item with the specified id could not be updated!"
                };
        }
        catch (Exception ex)
        {
            return new UpdateItemResponse()
            {
                ErrorMessage = ex.Message
            };
        }
    }

    private static void Validate(ItemDto item)
    {
        if (item == null ||
            string.IsNullOrEmpty(item.Name) ||
            string.IsNullOrEmpty(item.Price) ||
            string.IsNullOrEmpty(item.ProductDescription))
        {
            throw new Exception("Missing params in AddItemRequest !");
        }

        if (!decimal.TryParse(item.Price, out _))
        {
            throw new Exception("Item price is not valid !");
        }
    }

    public async Task<RemoveItemResponse> RemoveItem(string itemId)
    {
        try
        {
            if (string.IsNullOrEmpty(itemId) || !int.TryParse(itemId, out _))
            {
                throw new Exception("Item id is not valid !");
            }

            var result = await _productRepository.RemoveItem(itemId);
            return result ? new RemoveItemResponse() :
            new RemoveItemResponse()
            {
                ErrorMessage = "The item with the specified id could not be removed!"
            };
        }
        catch (Exception ex)
        {
            return new RemoveItemResponse()
            {
                ErrorMessage = ex.Message
            };
        }
    }

    public async Task<RemoveItemResponse> RemoveAll()
    {
        try
        {

            var result = await _productRepository.RemoveAll();
            return result ? new RemoveItemResponse() :
            new RemoveItemResponse()
            {
                ErrorMessage = "The item with the specified id could not be removed!"
            };
        }
        catch (Exception ex)
        {
            return new RemoveItemResponse()
            {
                ErrorMessage = ex.Message
            };
        }
    }
}
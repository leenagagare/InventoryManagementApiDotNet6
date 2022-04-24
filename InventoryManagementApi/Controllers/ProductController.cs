
using InventoryManagementApi.Models.Products;
using InventoryManagementServiceLayer.Contract;
using InventoryManagementServiceLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }


        [HttpGet]
        [Route("getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllItems().ConfigureAwait(false);
            return BuildResponse(result);
        }

  
        [HttpGet]
        [Route("productId/{itemId}")]
        public async Task<IActionResult> GetItemById(string itemId)
        {
            var result = await _productService.GetItemById(itemId).ConfigureAwait(false);
            return BuildResponse(result);
        }
        [HttpGet]
        [Route("productName/{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var result = await _productService.GetItemByName(name).ConfigureAwait(false);
            return BuildResponse(result);
        }

        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
        {
            var result = await _productService.AddItem(request).ConfigureAwait(false);
            return BuildResponse(result);
        }

        
        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateItemRequest request)
        {
            var result = await _productService.UpdateItem(request).ConfigureAwait(false);
            return BuildResponse(result);
        }

        [HttpDelete]
        [Route("removeProduct")]
        public async Task<IActionResult> RemoveItem(string itemId)
        {
            var result = await _productService.RemoveItem(itemId).ConfigureAwait(false);
            return BuildResponse(result);
        }

        [HttpDelete]
        [Route("removeAllProduct")]
        public async Task<IActionResult> RemoveAll()
        {
            var result = await _productService.RemoveAll().ConfigureAwait(false);
            return BuildResponse(result);
        }
        private ActionResult BuildResponse(InventoryServiceResponse response)
        {
            return new JsonResult(response);
        }
    }
}

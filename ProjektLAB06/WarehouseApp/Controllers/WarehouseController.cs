using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Models;
using WarehouseApp.Services;

namespace WarehouseApp.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService) {
            _warehouseService = warehouseService;
        }
        [HttpPost("Zadanie 1")]
        public IActionResult AddProductToWarehouse(ProductAddRequest product)
        {
            try
            {
                var WarehouseProductKey = _warehouseService.AddProductToWarehouse(product);
                return Ok("Created new Product_Warehouse entry: Key = " + WarehouseProductKey);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Zadanie 2")]
        public IActionResult AddProductToWarehouseThroughProcedure(ProductAddRequest product)
        {
            try
            {
                var WarehouseProductKey = _warehouseService.AddProductToWarehouseThroughProcedure(product);
                return Ok("Created new Product_Warehouse entry: Key = " + WarehouseProductKey);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

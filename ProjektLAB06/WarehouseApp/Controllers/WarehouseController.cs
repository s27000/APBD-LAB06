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
        [HttpPost]
        public IActionResult AddProductToWarehouse(ProductAddRequest product)
        {
            var WarehouseProductKey = _warehouseService.AddProductToWarehouse(product);
            return Ok(WarehouseProductKey);
        }
    }
}

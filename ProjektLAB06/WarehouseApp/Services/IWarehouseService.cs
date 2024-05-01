using WarehouseApp.Models;

namespace WarehouseApp.Services
{
    public interface IWarehouseService
    {
        int AddProductToWarehouse(ProductAddRequest request);
        int AddProductToWarehouseThroughProcedure(ProductAddRequest request);
    }
}

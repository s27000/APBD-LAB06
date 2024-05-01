using WarehouseApp.Models;

namespace WarehouseApp.Services
{
    public interface IWarehouseService
    {
        int AddProductToWarehouse(ProductAddRequest product);
    }
}

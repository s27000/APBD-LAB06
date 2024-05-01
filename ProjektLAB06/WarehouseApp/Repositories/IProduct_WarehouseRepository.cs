using WarehouseApp.Models;

namespace WarehouseApp.Repositories
{
    public interface IProduct_WarehouseRepository
    {
        bool OrderExistsInWarehouse(int IdOrder);
        int AddProductToWarehouse(ProductAddRequest request, int IdOrder, double Price);
        int AddProductToWareHouseThroughProcedure(ProductAddRequest request);
    }
}

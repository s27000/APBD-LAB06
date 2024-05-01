namespace WarehouseApp.Repositories
{
    public interface IProductRepository
    {
        bool ProductExists(int IdProduct);
        double getPrice(int IdProduct);
    }
}

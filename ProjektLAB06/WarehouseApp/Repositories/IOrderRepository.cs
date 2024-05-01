namespace WarehouseApp.Repositories
{
    public interface IOrderRepository
    {
        int GetOrderId(int IdProduct, int Amount, DateTime CreatedAt);
        void FufillOrder(int IdOrder);
    }
}

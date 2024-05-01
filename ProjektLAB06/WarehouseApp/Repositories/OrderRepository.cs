namespace WarehouseApp.Repositories
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration){
            
        }
    }
}

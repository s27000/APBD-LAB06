using WarehouseApp.Models;
using WarehouseApp.Repositories;

namespace WarehouseApp.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IProduct_WarehouseRepository _product_warehouseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IOrderRepository _orderRepository;
        
        public WarehouseService(
            IProduct_WarehouseRepository product_warehouseRepository, 
            IProductRepository productRepository,
            IWarehouseRepository warehouseRepository,
            IOrderRepository orderRepository)
        {
            _product_warehouseRepository = product_warehouseRepository;
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
            _orderRepository = orderRepository;
        }
        public int AddProductToWarehouse(ProductAddRequest product)
        {
            Console.WriteLine(_warehouseRepository.WarehouseExists(product.IdWarehouse));
            Console.WriteLine(_productRepository.ProductExists(product.IdProduct));
            return 1;
        }
    }
}

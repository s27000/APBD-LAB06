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
        public int AddProductToWarehouse(ProductAddRequest request)
        {
            try
            {
                VerifyProductAddRequest(request);
                int IdOrder = _orderRepository.GetOrderId(request.IdProduct, request.Amount, request.CreatedAt);
                VerifyOrderIdInWarehouse(IdOrder);
                _orderRepository.FufillOrder(IdOrder);
                return ProcessRequest(request, IdOrder);
            }catch(Exception)
            {
                throw;
            }
        }

        private void VerifyProductAddRequest(ProductAddRequest request)
        {
            if (!_warehouseRepository.WarehouseExists(request.IdWarehouse))
            {
                throw new Exception("Warehouse not found");
            }
            if (!_productRepository.ProductExists(request.IdProduct))
            {
                throw new Exception("Product not found");
            }
        }

        private void VerifyOrderIdInWarehouse(int IdOrder)
        {
            if (_product_warehouseRepository.OrderExistsInWarehouse(IdOrder)){
                throw new Exception("Order is already in a warhouse");
            }
        }

        private int ProcessRequest(ProductAddRequest request, int IdOrder)
        {
            try
            {
                double Price = request.Amount * _productRepository.getPrice(request.IdProduct);
                return _product_warehouseRepository.AddProductToWarehouse(request, IdOrder, Price);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddProductToWarehouseThroughProcedure(ProductAddRequest request)
        {
            try
            {
                return _product_warehouseRepository.AddProductToWareHouseThroughProcedure(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

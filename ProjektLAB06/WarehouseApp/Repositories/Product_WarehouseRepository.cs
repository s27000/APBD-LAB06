using System.Data.SqlClient;
using WarehouseApp.Models;

namespace WarehouseApp.Repositories
{
    public class Product_WarehouseRepository : Repository, IProduct_WarehouseRepository 
    {
        public Product_WarehouseRepository(IConfiguration configuration) : base(configuration) { }

        public bool OrderExistsInWarehouse(int IdOrder)
        {
            using var con = new SqlConnection(_ConnectionString);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM Product_Warehouse WHERE IdOrder = @IdOrder";
            cmd.Parameters.AddWithValue("@IdOrder", IdOrder);
            int dr = (int)cmd.ExecuteScalar();

            return dr > 0;
        }

        public int AddProductToWarehouse(ProductAddRequest request, int IdOrder, double Price)
        {
            using var con = new SqlConnection(_ConnectionString);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) VALUES (@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt)";
            cmd.Parameters.AddWithValue("@IdWarehouse", request.IdWarehouse);
            cmd.Parameters.AddWithValue("@IdProduct", request.IdProduct);
            cmd.Parameters.AddWithValue("@IdOrder", IdOrder);
            cmd.Parameters.AddWithValue("@Amount", request.Amount);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

            var affectedCount = cmd.ExecuteNonQuery();
            if (affectedCount == 0)
            {
                throw new Exception("Product has not been added to Warehouse");
            }
            return GetProductWarehouseCount();
        }

        private int GetProductWarehouseCount()
        {
            using var con = new SqlConnection(_ConnectionString);

            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT MAX(IdProductWarehouse) FROM Product_Warehouse";
            int dr = (int)cmd.ExecuteScalar();
            return dr;
        }

        public int AddProductToWareHouseThroughProcedure(ProductAddRequest request)
        {
            try
            {
                using var con = new SqlConnection(_ConnectionString);
                con.Open();

                using var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "EXEC AddProductToWarehouse @IdProduct, @IdWarehouse, @Amount, @CreatedAt";
                cmd.Parameters.AddWithValue("@IdWarehouse", request.IdWarehouse);
                cmd.Parameters.AddWithValue("@IdProduct", request.IdProduct);
                cmd.Parameters.AddWithValue("@Amount", request.Amount);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                var dr = cmd.ExecuteScalar();
                return Decimal.ToInt32((decimal)dr);
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}

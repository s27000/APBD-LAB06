using System.Data.SqlClient;

namespace WarehouseApp.Repositories
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration){}
        public int GetOrderId(int IdProduct, int Amount, DateTime CreatedAt)
        {
            using var con = new SqlConnection(_ConnectionString);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdOrder FROM \"Order\" WHERE IdProduct = @Id AND Amount = @Amount AND CreatedAt < @CreatedAt";
            cmd.Parameters.AddWithValue("@Id", IdProduct);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@CreatedAt", CreatedAt);
            var dr = cmd.ExecuteScalar();

            if(dr == null)
            {
                throw new Exception("No Order has been found");
            }
            return (int)dr;
        }

        public void FufillOrder(int IdOrder)
        {
            using var con = new SqlConnection(_ConnectionString);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE \"Order\" SET FulfilledAt = @FulfilledAt WHERE IdOrder = @IdOrder";
            cmd.Parameters.AddWithValue("@IdOrder", IdOrder);
            cmd.Parameters.AddWithValue("@FulfilledAt", DateTime.Now);

            var affectedCount = cmd.ExecuteNonQuery();
            if (affectedCount == 0)
            {
                throw new Exception("No order has been fulfilled");
            }
        }
    }
}

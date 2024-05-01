using System.Data.SqlClient;

namespace WarehouseApp.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration) { }

        public bool ProductExists(int IdProduct)
        {
            using var con = new SqlConnection(_ConnectionString);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM Product WHERE IdProduct = @Id";
            cmd.Parameters.AddWithValue("@Id", IdProduct);
            int dr = (int)cmd.ExecuteScalar();

            return dr > 0;
        }
        public double getPrice(int IdProduct)
        {
            using var con = new SqlConnection(_ConnectionString);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Price FROM Product WHERE IdProduct = @Id";
            cmd.Parameters.AddWithValue("@Id", IdProduct);
            var dr = cmd.ExecuteScalar();

            if (dr == null)
            {
                throw new Exception("Could not find Price");
            }
            return decimal.ToDouble((decimal)dr);
        }
    }
}

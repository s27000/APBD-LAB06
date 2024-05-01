using System.Data.SqlClient;

namespace WarehouseApp.Repositories
{
    public class WarehouseRepository : Repository,  IWarehouseRepository
    {
        public WarehouseRepository(IConfiguration configuration) : base(configuration) { }

        public bool WarehouseExists(int IdWarehouse)
        {
            using var con = new SqlConnection(_ConnectionString);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM Warehouse WHERE IdWarehouse = @Id";
            cmd.Parameters.AddWithValue("@Id", IdWarehouse);

            int dr = (int)cmd.ExecuteScalar();

            return dr > 0;
        }
    }
}

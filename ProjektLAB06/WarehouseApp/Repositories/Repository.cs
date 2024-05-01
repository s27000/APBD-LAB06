namespace WarehouseApp.Repositories
{
    public class Repository
    {
        protected readonly string _ConnectionString;
        public Repository(IConfiguration configuration)
        {
            _ConnectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}

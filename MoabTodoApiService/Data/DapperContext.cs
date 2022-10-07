using Npgsql;

namespace MoabTodoApiService.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public NpgsqlConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }

}

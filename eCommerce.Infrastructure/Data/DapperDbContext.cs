using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection DbConnection
        {
            get
            {
                var connStr = _configuration.GetConnectionString("DefaultConnection");
                return new NpgsqlConnection(connStr);
            }
        }
    }
}

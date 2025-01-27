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
                string connectionString = _configuration
                    .GetConnectionString("DefaultConnection")
                    .Replace("${POSTGRES_HOST}", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
                    .Replace("${POSTGRES_PASSWORD}", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

                return new NpgsqlConnection(connectionString);
            }
        }
    }
}
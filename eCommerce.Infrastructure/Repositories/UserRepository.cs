using Dapper;
using eCommerce.Core.Dtos;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Data;


namespace eCommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;

        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUserAsync(ApplicationUser? user)
        {
            if (user == null)
            {
                return null;
            }
            user.UserID = Guid.NewGuid();

            // Add Dapper code to insert user into database
            string query = @"
                INSERT INTO public.""Users"" (""UserID"", ""Email"", ""Password"", ""PersonName"", ""Gender"")
                VALUES (@UserID, @Email, @Password, @PersonName, @Gender)";

            var rowEffactes = await _dbContext.DbConnection.ExecuteAsync(query, user);
            return rowEffactes > 0 ? user : null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
        {
            var query = @"
                SELECT * FROM public.""Users"" WHERE ""Email"" = @Email AND ""Password"" = @Password";

            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });
            return user;
        }
    }
}

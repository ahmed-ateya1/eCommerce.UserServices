using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts
{
    /// <summary>
    /// Interface for user repository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Add user to the database asynchronously and return the user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUserAsync(ApplicationUser? user);
        /// <summary>
        /// Get user by email and password asynchronously and return the user object
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password);
    }
}

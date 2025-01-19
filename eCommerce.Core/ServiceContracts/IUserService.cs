using eCommerce.Core.Dtos;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUserService
    {
        /// <summary>
        /// Method to handle user login use case and returns the authentication response object
        /// that contains the token and user details
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest login);
        /// <summary>
        /// Method to handle user registration use case and returns the authentication response object
        /// that contains the token and user details
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(RegisterRequest register);
    }
}

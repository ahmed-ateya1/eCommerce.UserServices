using AutoMapper;
using eCommerce.Core.Dtos;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest login)
        {
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(login.Email, login.Password);
            if (user == null)
                return null;
            return _mapper.Map<AuthenticationResponse>(user) with
            {
                Success = true,
                Token = "token"
            };

        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest register)
        {
            var user = _mapper.Map<ApplicationUser>(register);
            await _userRepository.AddUserAsync(user);

            return _mapper.Map<AuthenticationResponse>(user) with { Success = true , Token = "token"};
        }
    }
}

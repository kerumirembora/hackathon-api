using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Repositories.SQLLite;
using Hackathon.Services.Interfaces;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class LoginService : ILoginService
    {
        IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Login(string userName)
        {
            return await _userRepository.GetByUserName(userName);
        }
    }
}

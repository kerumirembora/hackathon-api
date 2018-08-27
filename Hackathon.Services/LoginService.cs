using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Repositories.InMemory;
using Hackathon.Services.Interfaces;

namespace Hackathon.Services
{
    public class LoginService : ILoginService
    {
        IUserRepository _userRepository = new InMemoryUserRepository();

        public User Login(string userName)
        {
            return _userRepository.Get(userName);
        }
    }
}

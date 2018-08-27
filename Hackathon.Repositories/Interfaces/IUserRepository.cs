using Hackathon.Model;

namespace Hackathon.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Get(int id);
        User Get(string userName);
    }
}

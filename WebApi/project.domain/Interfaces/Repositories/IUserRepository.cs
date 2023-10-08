using project.domain.Entities;
using System.Threading.Tasks;

namespace project.domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Login(string username, string password);
    }
}

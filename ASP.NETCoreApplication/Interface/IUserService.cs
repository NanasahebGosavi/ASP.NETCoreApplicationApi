using ASP.NETCoreApplication.Entities;
using ASP.NETCoreApplication.Model;
using System.Threading.Tasks;

namespace ASP.NETCoreApplication.Interface
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);

        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> GetUserByUsername(string UserName);
        Task<User?> AddAndUpdateUser(User userObj);
        Task<bool> DeleteAsync(int id);

    }
}

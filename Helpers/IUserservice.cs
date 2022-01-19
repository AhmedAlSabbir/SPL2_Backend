using System.Threading.Tasks;
using JWTApi.Models;

namespace JWTApi.Helpers
{
    public interface IUserservice
    {
        Task<Staff> Register(Staff user, string password);
        Task<Staff> Authenticate(string username, string password);
        Task<bool> UserExist(string username);
    }
}
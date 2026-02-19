using InstawebAPI.DTOs;
using InstawebAPI.Models;

namespace InstawebAPI.Services
{
    public interface IUserService
    {
        Task<User> CreerClient(UserClientDto userClientDto);
        Task<User> CreerAdmin(UserAdminDto userAdminDto);
        Task<User?> Login(string email, string motDePasse);
        Task<User?> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUser();
        Task<User?> UpdateClient(int id,UserClientDto userClientDto);
        Task<User?> UpdateAdmin(int id, UserAdminDto userAdminDto);
        Task<bool> EmailExiste(string email);
        Task<bool> SupprimerUser(int id);
    }
}

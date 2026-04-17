using InstawebAPI.DTOs; // Instruction métier conservée telle quelle.
using InstawebAPI.Models; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Services // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public interface IUserService // Déclaration d'une interface.
    { // Délimiteur de bloc de code.
        Task<User> CreerClient(UserClientDto userClientDto); // Instruction métier conservée telle quelle.
        Task<User> CreerAdmin(UserAdminDto userAdminDto); // Instruction métier conservée telle quelle.
        Task<User?> Login(string email, string motDePasse); // Instruction métier conservée telle quelle.
        Task<User?> GetUserById(int id); // Instruction métier conservée telle quelle.
        Task<IEnumerable<User>> GetAllUser(); // Instruction métier conservée telle quelle.
        Task<User?> UpdateClient(int id,UserClientDto userClientDto); // Instruction métier conservée telle quelle.
        Task<User?> UpdateAdmin(int id, UserAdminDto userAdminDto); // Instruction métier conservée telle quelle.
        Task<bool> EmailExiste(string email); // Instruction métier conservée telle quelle.
        Task<bool> SupprimerUser(int id); // Instruction métier conservée telle quelle.
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

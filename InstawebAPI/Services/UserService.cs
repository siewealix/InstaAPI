using InstawebAPI.Data;
using InstawebAPI.DTOs;
using InstawebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InstawebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly MydbContext _context;

        // Constructeur
        public UserService(MydbContext context)
        {
            _context = context;
        }

        // verifier si l'email existe
        public async Task<bool> EmailExiste(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        // Créer un admin
        public async Task<User> CreerAdmin(UserAdminDto userAdminDto)
        {
            var user = new User("XXXXX","XXXXX",userAdminDto.Email,"0000000000", userAdminDto.MotDePasse,userAdminDto.Role);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return user;
        }

        // Créer un client
        public async Task<User> CreerClient(UserClientDto userClientDto)
        {
            if (userClientDto.MotDePasse != userClientDto.ConfirmMotPasse)
                throw new ArgumentException("Les mots de passe ne correspondent pas.");

            if (await EmailExiste(userClientDto.Email))
                throw new ArgumentException("Cet email est déjà utilisé.");

            var user = new User(userClientDto.Nom, userClientDto.Prenom, userClientDto.Email, userClientDto.Telephone, userClientDto.MotDePasse, userClientDto.Role);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return user;
        }

        // Récupérer tous les utilisateurs
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        // Récupérer un utilisateur par Id
        public async Task<User?> GetUserById(int id)

        {
            return await _context.Users.FindAsync(id);
        }

        // Modifier un client
        public async Task<User?> UpdateClient(int id, UserClientDto userClient)
        {
            var user = await _context.Users.FindAsync(id);
            
                user.ChangerNom(userClient.Nom);
                user.ChangerPrenom(userClient.Prenom);
                user.ChangerEmail(userClient.Email);
                user.ChangerTelephone(userClient.Telephone);
                user.ChangerMotDePasse(userClient.MotDePasse);
            
            await _context.SaveChangesAsync();
            return user;
        }

        // Modifier un admin
        public async Task<User?> UpdateAdmin(int id, UserAdminDto userAdminDto)
        {
            var user = await _context.Users.FindAsync(id);

                user.ChangerEmail(userAdminDto.Email);
                user.ChangerMotDePasse(userAdminDto.MotDePasse);

            await _context.SaveChangesAsync();
            return user;
        }

        // Suppression d'un utilisateur
        public async Task<bool> SupprimerUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Login
        public async Task<User?> Login(string email, string motDePasse)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return null;

            // bool ok = BCrypt.Net.BCrypt.Verify(motDePasse, user.MotDePasse); 
            bool ok = motDePasse == user.MotDePasse;
            return ok ? user : null;
        }
    }
}

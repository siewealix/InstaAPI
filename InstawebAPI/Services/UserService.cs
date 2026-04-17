using InstawebAPI.Data; // Instruction métier conservée telle quelle.
using InstawebAPI.DTOs; // Importation d'un espace de noms nécessaire.
using InstawebAPI.Models; // Importation d'un espace de noms nécessaire.
using Microsoft.EntityFrameworkCore; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Services // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class UserService : IUserService // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        private readonly MydbContext _context; // Déclaration d'un membre (propriété, méthode ou champ).

        // Constructeur
        public UserService(MydbContext context) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            _context = context; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // verifier si l'email existe
        public async Task<bool> EmailExiste(string email) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            return await _context.Users.AnyAsync(u => u.Email == email); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Créer un admin
        public async Task<User> CreerAdmin(UserAdminDto userAdminDto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var user = new User("XXXXX","XXXXX",userAdminDto.Email,"0000000000", userAdminDto.MotDePasse,userAdminDto.Role); // Déclaration et/ou initialisation de variable locale.

            _context.Users.Add(user); // Instruction métier conservée telle quelle.

            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return user; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Créer un client
        public async Task<User> CreerClient(UserClientDto userClientDto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (userClientDto.MotDePasse != userClientDto.ConfirmMotPasse) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Les mots de passe ne correspondent pas."); // Instruction métier conservée telle quelle.

            if (await EmailExiste(userClientDto.Email)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Cet email est déjà utilisé."); // Instruction métier conservée telle quelle.

            var user = new User(userClientDto.Nom, userClientDto.Prenom, userClientDto.Email, userClientDto.Telephone, userClientDto.MotDePasse, userClientDto.Role); // Déclaration et/ou initialisation de variable locale.

            _context.Users.Add(user); // Instruction métier conservée telle quelle.

            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return user; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Récupérer tous les utilisateurs
        public async Task<IEnumerable<User>> GetAllUser() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            return await _context.Users.ToListAsync(); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Récupérer un utilisateur par Id
        public async Task<User?> GetUserById(int id) // Déclaration d'un membre (propriété, méthode ou champ).

        { // Délimiteur de bloc de code.
            return await _context.Users.FindAsync(id); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Modifier un client
        public async Task<User?> UpdateClient(int id, UserClientDto userClient) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var user = await _context.Users.FindAsync(id); // Déclaration et/ou initialisation de variable locale.
            
                user.ChangerNom(userClient.Nom); // Instruction métier conservée telle quelle.
                user.ChangerPrenom(userClient.Prenom); // Instruction métier conservée telle quelle.
                user.ChangerEmail(userClient.Email); // Instruction métier conservée telle quelle.
                user.ChangerTelephone(userClient.Telephone); // Instruction métier conservée telle quelle.
                user.ChangerMotDePasse(userClient.MotDePasse); // Instruction métier conservée telle quelle.
            
            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return user; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Modifier un admin
        public async Task<User?> UpdateAdmin(int id, UserAdminDto userAdminDto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var user = await _context.Users.FindAsync(id); // Déclaration et/ou initialisation de variable locale.

                user.ChangerEmail(userAdminDto.Email); // Instruction métier conservée telle quelle.
                user.ChangerMotDePasse(userAdminDto.MotDePasse); // Instruction métier conservée telle quelle.

            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return user; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Suppression d'un utilisateur
        public async Task<bool> SupprimerUser(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var user = await _context.Users.FindAsync(id); // Déclaration et/ou initialisation de variable locale.
            if (user == null) // Condition pour contrôler le flux d'exécution.
                return false; // Retour de la valeur calculée.
            _context.Users.Remove(user); // Instruction métier conservée telle quelle.
            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return true; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Login
        public async Task<User?> Login(string email, string motDePasse) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email); // Déclaration et/ou initialisation de variable locale.
            if (user == null) // Condition pour contrôler le flux d'exécution.
                return null; // Retour de la valeur calculée.

            // bool ok = BCrypt.Net.BCrypt.Verify(motDePasse, user.MotDePasse); 
            bool ok = motDePasse == user.MotDePasse; // Déclaration et/ou initialisation de variable locale.
            return ok ? user : null; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

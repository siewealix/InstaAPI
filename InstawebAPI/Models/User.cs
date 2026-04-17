using System.ComponentModel.DataAnnotations.Schema; // Instruction métier conservée telle quelle.
using System.ComponentModel.DataAnnotations; // Importation d'un espace de noms nécessaire.
using System.Text.RegularExpressions; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Models // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class User // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        [Key] // Attribut de configuration/annotation appliqué.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Attribut de configuration/annotation appliqué.
        public int Id { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).
        [Required(ErrorMessage = "Le nom est obligatoire.")] // Attribut de configuration/annotation appliqué.
        [MinLength(2, ErrorMessage = "Le nom doit contenir au moins 2 caractères.")] // Attribut de configuration/annotation appliqué.
        public string Nom { get; private set; } // Déclaration d'un membre (propriété, méthode ou champ).
        [Required(ErrorMessage = "Le prenom est obligatoire.")] // Attribut de configuration/annotation appliqué.
        [MinLength(2, ErrorMessage = "Le prenom doit contenir au moins 2 caractères.")] // Attribut de configuration/annotation appliqué.
        public string Prenom { get; private set; } // Déclaration d'un membre (propriété, méthode ou champ).
        [Required(ErrorMessage = "L'email est obligatoire.")] // Attribut de configuration/annotation appliqué.
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")] // Attribut de configuration/annotation appliqué.
        public string Email { get; private set; } // Déclaration d'un membre (propriété, méthode ou champ).
        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")] // Attribut de configuration/annotation appliqué.
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Le numéro de téléphone doit contenir 10 chiffres.")] // Attribut de configuration/annotation appliqué.
        public string Telephone { get; private set; } // Déclaration d'un membre (propriété, méthode ou champ).
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")] // Attribut de configuration/annotation appliqué.
        [DataType(DataType.Password)] // Attribut de configuration/annotation appliqué.
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[^a-zA-Z0-9]).{12,}$", ErrorMessage = "Le mot de passe doit contenir au moins 12 caractères, une majuscule, une minuscule et un caractère spécial.")] // Attribut de configuration/annotation appliqué.
        public string MotDePasse { get; private set; } // Déclaration d'un membre (propriété, méthode ou champ).
        public string Role { get; private set; } // Déclaration d'un membre (propriété, méthode ou champ).

        // Constructeur
        public User(string nom, string prenom, string email, string telephone, string motDePasse, string role) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            ChangerNom(nom); // Instruction métier conservée telle quelle.
            ChangerPrenom(prenom); // Instruction métier conservée telle quelle.
            ChangerEmail(email); // Instruction métier conservée telle quelle.
            ChangerTelephone(telephone); // Instruction métier conservée telle quelle.
            ChangerMotDePasse(motDePasse); // Instruction métier conservée telle quelle.
            ChangerRole(role); // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.


        // --- Règle métier : nom valide ---
        public void ChangerNom(string nom) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (string.IsNullOrWhiteSpace(nom)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le nom d'utilisateur est obligatoire."); // Instruction métier conservée telle quelle.

            if (nom.Length < 2) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le nom doit contenir au moins 2 caractères."); // Instruction métier conservée telle quelle.

            Nom = nom; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // --- Règle métier : prenom valide ---
        public void ChangerPrenom(string prenom) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (string.IsNullOrWhiteSpace(prenom)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le prenom de l'utilisateur est obligatoire."); // Instruction métier conservée telle quelle.

            if (prenom.Length < 2) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le prenom doit contenir au moins 2 caractères."); // Instruction métier conservée telle quelle.

            Prenom = prenom; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // --- Règle métier : email valide ---
        public void ChangerEmail(string email) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (string.IsNullOrWhiteSpace(email)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("L'email est obligatoire."); // Instruction métier conservée telle quelle.

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"); // Déclaration et/ou initialisation de variable locale.

            if (!regex.IsMatch(email)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("L'email n'est pas valide."); // Instruction métier conservée telle quelle.

            Email = email; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.


        // --- Règle métier : telephone valide ---
        public void ChangerTelephone(string telephone) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (string.IsNullOrWhiteSpace(telephone)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le numéro de téléphone est obligatoire."); // Instruction métier conservée telle quelle.

            // Exemple : numéro français à 10 chiffres
            var regex = new Regex(@"^[0-9]{10}$"); // Déclaration et/ou initialisation de variable locale.

            if (!regex.IsMatch(telephone)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le numéro de téléphone doit contenir 10 chiffres."); // Instruction métier conservée telle quelle.

            Telephone = telephone; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // --- Règle métier : mot de passe valide ---
        public void ChangerMotDePasse(string motDePasse) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (string.IsNullOrWhiteSpace(motDePasse)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le mot de passe de l'utilisateur est obligatoire."); // Instruction métier conservée telle quelle.

            var regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[^a-zA-Z0-9]).{12,}$"); // Déclaration et/ou initialisation de variable locale.

            if (!regex.IsMatch(motDePasse)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le numéro de téléphone doit contenir 12 chiffres."); // Instruction métier conservée telle quelle.

            if (motDePasse.Length < 12) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le mot de passe doit contenir au moins 12 caractères."); // Instruction métier conservée telle quelle.

            MotDePasse = motDePasse; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // --- Règle métier : nom valide ---
        public void ChangerRole(string role) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            Role = role; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

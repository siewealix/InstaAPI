using System.ComponentModel.DataAnnotations.Schema; // Instruction métier conservée telle quelle.
using System.ComponentModel.DataAnnotations; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Models // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class Produit // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        [Key] // Attribut de configuration/annotation appliqué.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Attribut de configuration/annotation appliqué.
        public int Id { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).

        [Required(ErrorMessage = "Le nom du produit est obligatoire.")] // Attribut de configuration/annotation appliqué.
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 100 caractères.")] // Attribut de configuration/annotation appliqué.
        public string Nom { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).

        [Range(0, double.MaxValue, ErrorMessage = "Le prix ne peut pas être négatif.")] // Attribut de configuration/annotation appliqué.
        public decimal Prix { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).

        [Range(0, int.MaxValue, ErrorMessage = "Le stock ne peut pas être négatif.")] // Attribut de configuration/annotation appliqué.
        public int Stock { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).

        // constructeur
        public Produit() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.

        } // Délimiteur de bloc de code.

        // constructeur
        public Produit(string nom, decimal prix, int stock) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            ChangerNom(nom); // Instruction métier conservée telle quelle.
            ChangerPrix(prix); // Instruction métier conservée telle quelle.
            ChangerStock(stock); // Instruction métier conservée telle quelle.

        } // Délimiteur de bloc de code.

        // --- Règle métier : nom valide ---
        public void ChangerNom(string nom) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (string.IsNullOrWhiteSpace(nom)) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le nom du produit est obligatoire."); // Instruction métier conservée telle quelle.

            if (nom.Length < 2) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le nom doit contenir au moins 2 caractères."); // Instruction métier conservée telle quelle.

            Nom = nom; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // --- Règle métier : prix positif ---
        public void ChangerPrix(decimal prix) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (prix < 0) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le prix ne peut pas être négatif."); // Instruction métier conservée telle quelle.

            Prix = prix; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // --- Règle métier : stock cohérent ---
        public void ChangerStock(int stock) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (stock < 0) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("Le stock ne peut pas être négatif."); // Instruction métier conservée telle quelle.

            Stock = stock; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // --- Règle métier : décrémenter le stock ---
        public void RetirerDuStock(int quantite) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (quantite <= 0) // Condition pour contrôler le flux d'exécution.
                throw new ArgumentException("La quantité doit être positive."); // Instruction métier conservée telle quelle.

            if (quantite > Stock) // Condition pour contrôler le flux d'exécution.
                throw new InvalidOperationException("Stock insuffisant."); // Instruction métier conservée telle quelle.

            Stock -= quantite; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        // --- Règle métier : ajouter au stock ---
        public void AjouterAuStock(int quantite) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (quantite <= 0) // Condition pour contrôler le flux d'exécution.
            { // Délimiteur de bloc de code.
                throw new ArgumentException("La quantité doit être positive."); // Instruction métier conservée telle quelle.

            } // Délimiteur de bloc de code.
            Stock += quantite; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

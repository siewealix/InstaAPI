using System.ComponentModel.DataAnnotations; // Instruction métier conservée telle quelle.

namespace ClientAPI.Models // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class ProduitDTO // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        public int Id { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).
        [Required(ErrorMessage = "Le nom est obligatoire.")] // Attribut de configuration/annotation appliqué.
        [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères.")] // Attribut de configuration/annotation appliqué.
        [RegularExpression(@"^[^<>]*$", ErrorMessage = "Les caractères < et > sont interdits.")] // Attribut de configuration/annotation appliqué.
        public string Nom { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).
        [Range(0.01, 100000, ErrorMessage = "Le prix doit être positif.")] // Attribut de configuration/annotation appliqué.
        public decimal Prix { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).
        [Range(0, int.MaxValue, ErrorMessage = "Le stock doit être positif.")] // Attribut de configuration/annotation appliqué.
        public int Stock { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).


    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

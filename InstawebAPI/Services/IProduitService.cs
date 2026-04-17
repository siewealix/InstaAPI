using Microsoft.EntityFrameworkCore; // Instruction métier conservée telle quelle.
using InstawebAPI.DTOs; // Importation d'un espace de noms nécessaire.
using InstawebAPI.Models; // Importation d'un espace de noms nécessaire.

namespace WebMVC.Services // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public interface IProduitService // Déclaration d'une interface.
    { // Délimiteur de bloc de code.
        Task<Produit> CreerProduit(ProduitDTO dto); // Instruction métier conservée telle quelle.

        Task<IEnumerable<Produit>> GetAllProduit(); // Instruction métier conservée telle quelle.

        // "?" peut contenir un produit vide
        Task<Produit?> UpdateProduit(int id, ProduitDTO dto); // Instruction métier conservée telle quelle.

        Task<Produit?> GetProduitById(int id); // Instruction métier conservée telle quelle.

        Task<bool> AjouterStock(int id, int quantite); // Instruction métier conservée telle quelle.
        Task<bool> RetirerStock(int id, int quantite); // Instruction métier conservée telle quelle.
        Task<bool> SupprimerProduit(int id); // Instruction métier conservée telle quelle.

        
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

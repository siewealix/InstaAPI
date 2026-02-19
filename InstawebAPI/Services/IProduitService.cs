using Microsoft.EntityFrameworkCore;
using InstawebAPI.DTOs;
using InstawebAPI.Models;

namespace WebMVC.Services
{
    public interface IProduitService
    {
        Task<Produit> CreerProduit(ProduitDTO dto);

        Task<IEnumerable<Produit>> GetAllProduit();

        // "?" peut contenir un produit vide
        Task<Produit?> UpdateProduit(int id, ProduitDTO dto);

        Task<Produit?> GetProduitById(int id);

        Task<bool> AjouterStock(int id, int quantite);
        Task<bool> RetirerStock(int id, int quantite);
        Task<bool> SupprimerProduit(int id);

        
    }
}

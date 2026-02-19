using Microsoft.EntityFrameworkCore;
using System.Globalization;
using InstawebAPI.Data;
using InstawebAPI.DTOs;
using InstawebAPI.Models;
using InstawebAPI.Services;
using WebMVC.Services;

namespace InstawebAPI.Services
{
    public class ProduitService : IProduitService
    {
        //Declarer une variable de type MydbContext,ne peut etre appeler que dans ProduitService
        //Et on ne peut pas la modifiee
        private readonly MydbContext _context;


        public ProduitService(MydbContext context)
        {
            _context = context;
        }


        public async Task<Produit> CreerProduit(ProduitDTO dto)
        {
            //var prix = Convert.ToDecimal(dto.Prix, CultureInfo.GetCultureInfo("fr-FR"));
            var produit = new Produit(dto.Nom, dto.Prix, dto.Stock);


            // ton constructeur exige un Id > 0. 
            // Si tu ajoutes un constructeur sans paramètre, tu pourras faire : //
            //var produit = new Produit(dto.Nom,dto.Prix,dto.Stock); //
            produit.ChangerNom(dto.Nom);
            produit.ChangerPrix(dto.Prix);
            produit.ChangerStock(dto.Stock);


            _context.Produits.Add(produit);

            await _context.SaveChangesAsync();
            return produit;
        }

        public async Task<IEnumerable<Produit>> GetAllProduit()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task<Produit?> UpdateProduit(int id, ProduitDTO dto)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null) return null;
            //var prix = Convert.ToDecimal(dto.Prix, CultureInfo.GetCultureInfo("fr-FR"));
            // On utilise les règles métier existantes
            produit.ChangerNom(dto.Nom);

            produit.ChangerPrix(dto.Prix);
            produit.ChangerStock(dto.Stock);
            await _context.SaveChangesAsync();
            return produit;
        }

        // Récupérer un produit par Id
        public async Task<Produit?> GetProduitById(int id)
        {
            return await _context.Produits.FindAsync(id);

        }


        public async Task<bool> AjouterStock(int id, int quantite)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
                return false;
            produit.AjouterAuStock(quantite);
            await _context.SaveChangesAsync();
            return true;
        }
        // Retirer du stock
        public async Task<bool> RetirerStock(int id, int quantite)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
                return false;
            produit.RetirerDuStock(quantite);
            await _context.SaveChangesAsync();
            return true;
        }

        // Suppression d'un produit
        public async Task<bool> SupprimerProduit(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
                return false;
            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

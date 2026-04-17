using Microsoft.EntityFrameworkCore; // Instruction métier conservée telle quelle.
using System.Globalization; // Importation d'un espace de noms nécessaire.
using InstawebAPI.Data; // Importation d'un espace de noms nécessaire.
using InstawebAPI.DTOs; // Importation d'un espace de noms nécessaire.
using InstawebAPI.Models; // Importation d'un espace de noms nécessaire.
using InstawebAPI.Services; // Importation d'un espace de noms nécessaire.
using WebMVC.Services; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Services // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class ProduitService : IProduitService // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        //Declarer une variable de type MydbContext,ne peut etre appeler que dans ProduitService
        //Et on ne peut pas la modifiee
        private readonly MydbContext _context; // Déclaration d'un membre (propriété, méthode ou champ).


        public ProduitService(MydbContext context) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            _context = context; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.


        public async Task<Produit> CreerProduit(ProduitDTO dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            //var prix = Convert.ToDecimal(dto.Prix, CultureInfo.GetCultureInfo("fr-FR"));
            var produit = new Produit(dto.Nom, dto.Prix, dto.Stock); // Déclaration et/ou initialisation de variable locale.


            // ton constructeur exige un Id > 0. 
            // Si tu ajoutes un constructeur sans paramètre, tu pourras faire : //
            //var produit = new Produit(dto.Nom,dto.Prix,dto.Stock); //
            produit.ChangerNom(dto.Nom); // Instruction métier conservée telle quelle.
            produit.ChangerPrix(dto.Prix); // Instruction métier conservée telle quelle.
            produit.ChangerStock(dto.Stock); // Instruction métier conservée telle quelle.


            _context.Produits.Add(produit); // Instruction métier conservée telle quelle.

            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return produit; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        public async Task<IEnumerable<Produit>> GetAllProduit() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            return await _context.Produits.ToListAsync(); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        public async Task<Produit?> UpdateProduit(int id, ProduitDTO dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produit = await _context.Produits.FindAsync(id); // Déclaration et/ou initialisation de variable locale.
            if (produit == null) return null; // Condition pour contrôler le flux d'exécution.
            //var prix = Convert.ToDecimal(dto.Prix, CultureInfo.GetCultureInfo("fr-FR"));
            // On utilise les règles métier existantes
            produit.ChangerNom(dto.Nom); // Instruction métier conservée telle quelle.

            produit.ChangerPrix(dto.Prix); // Instruction métier conservée telle quelle.
            produit.ChangerStock(dto.Stock); // Instruction métier conservée telle quelle.
            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return produit; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Récupérer un produit par Id
        public async Task<Produit?> GetProduitById(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            return await _context.Produits.FindAsync(id); // Retour de la valeur calculée.

        } // Délimiteur de bloc de code.


        public async Task<bool> AjouterStock(int id, int quantite) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produit = await _context.Produits.FindAsync(id); // Déclaration et/ou initialisation de variable locale.
            if (produit == null) // Condition pour contrôler le flux d'exécution.
                return false; // Retour de la valeur calculée.
            produit.AjouterAuStock(quantite); // Instruction métier conservée telle quelle.
            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return true; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.
        // Retirer du stock
        public async Task<bool> RetirerStock(int id, int quantite) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produit = await _context.Produits.FindAsync(id); // Déclaration et/ou initialisation de variable locale.
            if (produit == null) // Condition pour contrôler le flux d'exécution.
                return false; // Retour de la valeur calculée.
            produit.RetirerDuStock(quantite); // Instruction métier conservée telle quelle.
            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return true; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        // Suppression d'un produit
        public async Task<bool> SupprimerProduit(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produit = await _context.Produits.FindAsync(id); // Déclaration et/ou initialisation de variable locale.
            if (produit == null) // Condition pour contrôler le flux d'exécution.
                return false; // Retour de la valeur calculée.
            _context.Produits.Remove(produit); // Instruction métier conservée telle quelle.
            await _context.SaveChangesAsync(); // Attente asynchrone sans bloquer le thread.
            return true; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

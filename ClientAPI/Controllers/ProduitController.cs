using ClientAPI.Models; // Instruction métier conservée telle quelle.
using ClientAPI.Services; // Importation d'un espace de noms nécessaire.
using Microsoft.AspNetCore.Mvc; // Importation d'un espace de noms nécessaire.

namespace ClientAPI.Controllers // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class ProduitController : Controller // Déclaration d'une classe.
    { // Délimiteur de bloc de code.

        private readonly ProduitAPIClient _apiclient; // Déclaration d'un membre (propriété, méthode ou champ).

        public ProduitController(ProduitAPIClient apiclient) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            _apiclient = apiclient; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        public async Task<IActionResult> Index() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produits = await _apiclient.GetAllAsync(); // Déclaration et/ou initialisation de variable locale.
            return View(produits); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        [HttpGet] // Attribut de configuration/annotation appliqué.
        public IActionResult Create() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            return View(); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.
        [HttpPost] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> Create(ProduitDTO dto) // Déclaration d'un membre (propriété, méthode ou champ).

        { // Délimiteur de bloc de code.
            if (!ModelState.IsValid) // Condition pour contrôler le flux d'exécution.
                return View(dto); // Retour de la valeur calculée.
            await _apiclient.CreateAsync(dto); // Attente asynchrone sans bloquer le thread.
            return RedirectToAction(nameof(Index)); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var produit = await _apiclient.GetByIdAsync(id);
        //    if (produit == null) return NotFound();
        //    return View(produit);
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ok = await _apiclient.DeleteAsync(id);
        //    if (!ok) return NotFound();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> Delete(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var ok = await _apiclient.DeleteAsync(id); // Déclaration et/ou initialisation de variable locale.

            TempData["Message"] = ok ? "Produit supprimé." : "Suppression impossible."; // Instruction métier conservée telle quelle.

            return RedirectToAction(nameof(Index)); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.



        public async Task<IActionResult> Details(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produit = await _apiclient.GetByIdAsync(id); // Déclaration et/ou initialisation de variable locale.
            if (produit == null) return NotFound(); // Condition pour contrôler le flux d'exécution.
            return View(produit); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        [HttpGet] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> Edit(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produit = await _apiclient.GetByIdAsync(id); // Déclaration et/ou initialisation de variable locale.
            if (produit == null) return NotFound(); // Condition pour contrôler le flux d'exécution.
            return View(produit); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        [HttpPost] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> Edit(int id, ProduitDTO dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (!ModelState.IsValid) // Condition pour contrôler le flux d'exécution.
                return View(dto); // Retour de la valeur calculée.

            var ok = await _apiclient.UpdateAsync(id, dto); // Déclaration et/ou initialisation de variable locale.
            if (!ok) return NotFound(); // Condition pour contrôler le flux d'exécution.

            return RedirectToAction(nameof(Index)); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.


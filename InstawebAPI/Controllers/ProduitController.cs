using InstawebAPI.DTOs; // Instruction métier conservée telle quelle.
using Microsoft.AspNetCore.Authorization; // Importation d'un espace de noms nécessaire.
using Microsoft.AspNetCore.Http; // Importation d'un espace de noms nécessaire.
using Microsoft.AspNetCore.Mvc; // Importation d'un espace de noms nécessaire.
using System.Globalization; // Importation d'un espace de noms nécessaire.
using WebMVC.Services; // Importation d'un espace de noms nécessaire.
using static Microsoft.EntityFrameworkCore.DbLoggerCategory; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Controllers // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    [Route("api/[controller]")] // Attribut de configuration/annotation appliqué.
    [ApiController] // Attribut de configuration/annotation appliqué.
    public class ProduitController : ControllerBase // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        public readonly IProduitService _produitService; // Déclaration d'un membre (propriété, méthode ou champ).

        public ProduitController(IProduitService produitService) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            _produitService = produitService; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.


        [HttpGet] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> GetProduits() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produits = await _produitService.GetAllProduit(); // Déclaration et/ou initialisation de variable locale.
            return Ok(produits); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        [HttpPost] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> Create([FromBody] ProduitDTO dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (!ModelState.IsValid) // Condition pour contrôler le flux d'exécution.
                return BadRequest(ModelState); // Retour de la valeur calculée.

            try // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                var produitCree = await _produitService.CreerProduit(dto); // Déclaration et/ou initialisation de variable locale.

                return StatusCode(201, $"Produit a été créer avec success"); // Retour de la valeur calculée.

            } // Délimiteur de bloc de code.
            catch (Exception ex) // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                return StatusCode(500, new { message = ex.Message }); // Retour de la valeur calculée.
            } // Délimiteur de bloc de code.
        } // Délimiteur de bloc de code.

        //modifier un produit
        [HttpPut("{id}")] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> Update(int id, [FromBody] ProduitDTO dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (!ModelState.IsValid) // Condition pour contrôler le flux d'exécution.
                return BadRequest(ModelState); // 400

            try // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                var updated = await _produitService.UpdateProduit(id, dto); // Déclaration et/ou initialisation de variable locale.

                if (updated == null) // Condition pour contrôler le flux d'exécution.
                    return NotFound(); // 404

                return Ok(updated); // 200 + JSON
            } // Délimiteur de bloc de code.
            catch (Exception ex) // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                ModelState.AddModelError("", "Impossible de contacter le serveur d’authentification."); // Instruction métier conservée telle quelle.
                return StatusCode(500, new { message = ex.Message }); // 500
            } // Délimiteur de bloc de code.
        } // Délimiteur de bloc de code.

        [HttpGet("{id}")] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> GetById(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var produit = await _produitService.GetProduitById(id); // Déclaration et/ou initialisation de variable locale.

            if (produit == null) // Condition pour contrôler le flux d'exécution.
                return NotFound(); // Retour de la valeur calculée.

            var dto = new ProduitDTO // Déclaration et/ou initialisation de variable locale.
            { // Délimiteur de bloc de code.
                Id = produit.Id, // Instruction métier conservée telle quelle.
                Nom = produit.Nom, // Instruction métier conservée telle quelle.
                Prix = produit.Prix, // Instruction métier conservée telle quelle.
                Stock = produit.Stock // Instruction métier conservée telle quelle.
            }; // Instruction métier conservée telle quelle.

            return Ok(dto); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.



        [HttpDelete("{id}")] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> Delete(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            try // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                var deleted = await _produitService.SupprimerProduit(id); // Déclaration et/ou initialisation de variable locale.

                if (!deleted) // Condition pour contrôler le flux d'exécution.
                    return NotFound(); // Retour de la valeur calculée.

                return NoContent(); // Retour de la valeur calculée.
            } // Délimiteur de bloc de code.
            catch (Exception ex) // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                return StatusCode(500, new { message = ex.Message }); // Retour de la valeur calculée.
            } // Délimiteur de bloc de code.
        } // Délimiteur de bloc de code.

    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

using InstawebAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;

namespace InstawebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProduits()
        {
            var produits = await _produitService.GetAllProduit();
            return Ok(produits);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produit = await _produitService.GetProduitById(id);

            if (produit == null)
                return NotFound();

            var dto = new ProduitDTO
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Prix = produit.Prix,
                Stock = produit.Stock
            };

            return Ok(dto);
        }

        // Réservé admin
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProduitDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _produitService.CreerProduit(dto);
                return StatusCode(201, "Produit créé avec succès.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Réservé admin
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProduitDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated = await _produitService.UpdateProduit(id, dto);

                if (updated == null)
                    return NotFound();

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Réservé admin
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/ajouter-stock")]
        public async Task<IActionResult> AjouterStock(int id, [FromQuery] int quantite)
        {
            if (quantite <= 0)
                return BadRequest("La quantité doit être > 0.");

            try
            {
                var ok = await _produitService.AjouterStock(id, quantite);
                if (!ok)
                    return NotFound();

                return Ok(new { message = "Stock ajouté avec succès." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Réservé admin
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/retirer-stock")]
        public async Task<IActionResult> RetirerStock(int id, [FromQuery] int quantite)
        {
            if (quantite <= 0)
                return BadRequest("La quantité doit être > 0.");

            try
            {
                var ok = await _produitService.RetirerStock(id, quantite);
                if (!ok)
                    return NotFound();

                return Ok(new { message = "Stock retiré avec succès." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Réservé admin
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _produitService.SupprimerProduit(id);

                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

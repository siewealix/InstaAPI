using InstawebAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebMVC.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InstawebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        public readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProduits()
        {
            var produits = await _produitService.GetAllProduit();
            return Ok(produits);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProduitDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var produitCree = await _produitService.CreerProduit(dto);

                return StatusCode(201, $"Produit a été créer avec success");

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //modifier un produit
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProduitDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400

            try
            {
                var updated = await _produitService.UpdateProduit(id, dto);

                if (updated == null)
                    return NotFound(); // 404

                return Ok(updated); // 200 + JSON
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Impossible de contacter le serveur d’authentification.");
                return StatusCode(500, new { message = ex.Message }); // 500
            }
        }

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

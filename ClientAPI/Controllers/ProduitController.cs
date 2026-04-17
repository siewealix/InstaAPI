using ClientAPI.Models;
using ClientAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers
{
    public class ProduitController : Controller
    {
        private readonly ProduitAPIClient _apiclient;

        public ProduitController(ProduitAPIClient apiclient)
        {
            _apiclient = apiclient;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await _apiclient.GetAllAsync();
            return View(produits);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProduitDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var ok = await _apiclient.CreateAsync(dto);
            if (!ok)
            {
                ModelState.AddModelError("", "Création impossible.");
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _apiclient.DeleteAsync(id);
            TempData["Message"] = ok ? "Produit supprimé." : "Suppression impossible.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var produit = await _apiclient.GetByIdAsync(id);
            if (produit == null) return NotFound();
            return View(produit);
        }

        [HttpPost]
        public async Task<IActionResult> AjouterStock(int id, int quantite)
        {
            if (quantite <= 0)
            {
                TempData["Erreur"] = "Veuillez entrer une quantité supérieure à 0.";
                return RedirectToAction(nameof(Details), new { id });
            }

            var ok = await _apiclient.AjouterStockAsync(id, quantite);
            TempData["Erreur"] = ok ? null : "Impossible d'ajouter le stock.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> RetirerStock(int id, int quantite)
        {
            if (quantite <= 0)
            {
                TempData["Erreur"] = "Veuillez entrer une quantité supérieure à 0.";
                return RedirectToAction(nameof(Details), new { id });
            }

            var ok = await _apiclient.RetirerStockAsync(id, quantite);
            TempData["Erreur"] = ok ? null : "Impossible de retirer le stock (quantité trop grande ?).";
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var produit = await _apiclient.GetByIdAsync(id);
            if (produit == null) return NotFound();
            return View(produit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProduitDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var ok = await _apiclient.UpdateAsync(id, dto);
            if (!ok) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}

using ClientAPI.Models; // Instruction métier conservée telle quelle.
using System.Net; // Importation d'un espace de noms nécessaire.

namespace ClientAPI.Services // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class ProduitAPIClient // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        private readonly HttpClient _httpClient; // Déclaration d'un membre (propriété, méthode ou champ).

        public ProduitAPIClient(HttpClient httpClient) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            _httpClient = httpClient; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        /***************************************/
        public async Task<IEnumerable<ProduitDTO>?> GetAllAsync() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            //Envoie une requete GET vers l'URL indiquée.
            //Désérialise la réponse JSON en objets C# du type demandé
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProduitDTO>>("api/produit"); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.
        public async Task<bool> CreateAsync(ProduitDTO dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.

            //le JWT dans
            //AddJwt();
            var response = await _httpClient.PostAsJsonAsync("api/produit", dto); // Déclaration et/ou initialisation de variable locale.
            return response.IsSuccessStatusCode; // Retour de la valeur calculée.

        } // Délimiteur de bloc de code.

        public async Task<ProduitDTO?> GetByIdAsync(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            //Envoie une requête HTTP GET vers l’endpoint api/produit/{ id}.
            var response = await _httpClient.GetAsync($"api/produit/{id}"); // Déclaration et/ou initialisation de variable locale.

            if (response.StatusCode == HttpStatusCode.NotFound) // Condition pour contrôler le flux d'exécution.
                return null; // Retour de la valeur calculée.
            //Vérifie que le code HTTP est un succès(200).
            response.EnsureSuccessStatusCode(); // Instruction métier conservée telle quelle.
            //Lit le contenu JSON de la réponse.
            //Désérialise automatiquement ce JSON en un objet ProduitDto.
            //Retourne cet objet au code appelant.
            return await response.Content.ReadFromJsonAsync<ProduitDTO>(); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        public async Task<bool> DeleteAsync(int id) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var response = await _httpClient.DeleteAsync($"api/produit/{id}"); // Déclaration et/ou initialisation de variable locale.

            if (response.StatusCode == HttpStatusCode.NotFound) // Condition pour contrôler le flux d'exécution.
                return false; // Retour de la valeur calculée.

            return response.IsSuccessStatusCode; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        public async Task<bool> UpdateAsync(int id, ProduitDTO dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var response = await _httpClient.PutAsJsonAsync($"api/produit/{id}", dto); // Déclaration et/ou initialisation de variable locale.
            return response.IsSuccessStatusCode; // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        public async Task<(bool Success, string? ErrorMessage)> AjouterStockAsync(int id, int quantite) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var response = await _httpClient.PostAsync($"api/produit/{id}/ajouter-stock?quantite={quantite}", null); // Déclaration et/ou initialisation de variable locale.
            if (response.IsSuccessStatusCode) // Condition pour contrôler le flux d'exécution.
                return (true, null); // Retour de la valeur calculée.

            var error = await response.Content.ReadAsStringAsync(); // Déclaration et/ou initialisation de variable locale.
            return (false, error); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.

        public async Task<(bool Success, string? ErrorMessage)> RetirerStockAsync(int id, int quantite) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var response = await _httpClient.PostAsync($"api/produit/{id}/retirer-stock?quantite={quantite}", null); // Déclaration et/ou initialisation de variable locale.
            if (response.IsSuccessStatusCode) // Condition pour contrôler le flux d'exécution.
                return (true, null); // Retour de la valeur calculée.

            var error = await response.Content.ReadAsStringAsync(); // Déclaration et/ou initialisation de variable locale.
            return (false, error); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.



    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.

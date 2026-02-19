using ClientAPI.Models;
using System.Net;

namespace ClientAPI.Services
{
    public class ProduitAPIClient
    {
        private readonly HttpClient _httpClient;

        public ProduitAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /***************************************/
        public async Task<IEnumerable<ProduitDTO>?> GetAllAsync()
        {
            //Envoie une requete GET vers l'URL indiquée.
            //Désérialise la réponse JSON en objets C# du type demandé
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProduitDTO>>("api/produit");
        }
        public async Task<bool> CreateAsync(ProduitDTO dto)
        {

            //le JWT dans
            //AddJwt();
            var response = await _httpClient.PostAsJsonAsync("api/produit", dto);
            return response.IsSuccessStatusCode;

        }

        public async Task<ProduitDTO?> GetByIdAsync(int id)
        {
            //Envoie une requête HTTP GET vers l’endpoint api/produit/{ id}.
            var response = await _httpClient.GetAsync($"api/produit/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            //Vérifie que le code HTTP est un succès(200).
            response.EnsureSuccessStatusCode();
            //Lit le contenu JSON de la réponse.
            //Désérialise automatiquement ce JSON en un objet ProduitDto.
            //Retourne cet objet au code appelant.
            return await response.Content.ReadFromJsonAsync<ProduitDTO>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/produit/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return false;

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, ProduitDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/produit/{id}", dto);
            return response.IsSuccessStatusCode;
        }



    }
}

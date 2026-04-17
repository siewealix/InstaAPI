using ClientAPI.Models;
using System.Net;
using System.Net.Http.Json;

namespace ClientAPI.Services
{
    public class ProduitAPIClient
    {
        private readonly HttpClient _httpClient;

        public ProduitAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private HttpRequestMessage CreateAdminRequest(HttpMethod method, string url)
        {
            var request = new HttpRequestMessage(method, url);
            request.Headers.Add("X-Role", "Admin");
            return request;
        }

        public async Task<IEnumerable<ProduitDTO>?> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProduitDTO>>("api/produit");
        }

        public async Task<bool> CreateAsync(ProduitDTO dto)
        {
            var request = CreateAdminRequest(HttpMethod.Post, "api/produit");
            request.Content = JsonContent.Create(dto);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public async Task<ProduitDTO?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/produit/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProduitDTO>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var request = CreateAdminRequest(HttpMethod.Delete, $"api/produit/{id}");
            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return false;

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, ProduitDTO dto)
        {
            var request = CreateAdminRequest(HttpMethod.Put, $"api/produit/{id}");
            request.Content = JsonContent.Create(dto);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AjouterStockAsync(int id, int quantite)
        {
            var request = CreateAdminRequest(HttpMethod.Put, $"api/produit/{id}/ajouter-stock?quantite={quantite}");
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RetirerStockAsync(int id, int quantite)
        {
            var request = CreateAdminRequest(HttpMethod.Put, $"api/produit/{id}/retirer-stock?quantite={quantite}");
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}

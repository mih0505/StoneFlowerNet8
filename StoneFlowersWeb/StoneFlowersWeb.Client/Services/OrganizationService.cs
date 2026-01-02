using System.Net.Http.Json;
using StoneFlowersWeb.Client.Models;

namespace StoneFlowersWeb.Client.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly HttpClient _http;

        public OrganizationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<OrganizationListItem>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<OrganizationListItem>>("api/organizations");
        }

        public async Task<OrganizationDetail> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<OrganizationDetail>($"api/organizations/{id}");
        }

        public async Task<Guid> CreateAsync(string name)
        {
            var content = JsonContent.Create(new { Name = name });
            var res = await _http.PostAsync("api/organizations", content);
            res.EnsureSuccessStatusCode();
            var body = await res.Content.ReadFromJsonAsync<Dictionary<string, Guid>>();
            return body != null && body.ContainsKey("id") ? body["id"] : Guid.Empty;
        }

        public async Task UpdateAsync(Guid id, string name)
        {
            var content = JsonContent.Create(new { Id = id, Name = name });
            var res = await _http.PutAsync($"api/organizations/{id}", content);
            res.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var res = await _http.DeleteAsync($"api/organizations/{id}");
            res.EnsureSuccessStatusCode();
        }
    }
}
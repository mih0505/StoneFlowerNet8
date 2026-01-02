using StoneFlowersWeb.Client.Models;

namespace StoneFlowersWeb.Client.Services
{
    public interface IOrganizationService
    {
        Task<List<OrganizationListItem>> GetAllAsync();
        Task<OrganizationDetail> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(string name);
        Task UpdateAsync(Guid id, string name);
        Task DeleteAsync(Guid id);
    }
}
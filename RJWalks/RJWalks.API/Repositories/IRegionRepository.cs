using RJWalks.API.Models.Domain;

namespace RJWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid Id, Region region);

        Task<Region?> DeleteAsync(Guid Id);
    }
}

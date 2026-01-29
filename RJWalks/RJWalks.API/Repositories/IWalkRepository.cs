using Microsoft.AspNetCore.Mvc;
using RJWalks.API.Models.Domain;

namespace RJWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null,string? filterQuery = null);
        Task<Walk?> GetbyIdAsync(Guid id);

        Task<Walk?>UpdateAsync(Guid id, Walk walk);
        Task<Walk?>DeleteAsync(Guid id);

    }
}

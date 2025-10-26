using RJWalks.API.Models.Domain;

namespace RJWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
    }
}

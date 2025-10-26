using RJWalks.API.Data;
using RJWalks.API.Models.Domain;

namespace RJWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly RJWalksDBContext dBContext;

        public SQLWalkRepository(RJWalksDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dBContext.Walks.AddAsync(walk);
            await dBContext.SaveChangesAsync();
            return walk;
        }
    }
}

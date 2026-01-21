using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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


        public async Task<List<Walk>> GetAllAsync()
        {
            return await dBContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

        }

        public async Task<Walk?> GetbyIdAsync(Guid id)
        {
            return await dBContext.Walks
                 .Include("Difficulty")
                 .Include("Region")
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthinKm = walk.LengthinKm;
            existingWalk.WalkImageURL = walk.WalkImageURL;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await dBContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
           var existingWalk = await dBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null ) return null;

            dBContext.Walks.Remove(existingWalk);
            await dBContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}

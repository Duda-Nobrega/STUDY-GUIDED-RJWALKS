using Microsoft.EntityFrameworkCore;
using RJWalks.API.Models.Domain;

namespace RJWalks.API.Data
{
    public class RJWalksDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {

        //All of these properties represens collection inside our database
        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

    }
}

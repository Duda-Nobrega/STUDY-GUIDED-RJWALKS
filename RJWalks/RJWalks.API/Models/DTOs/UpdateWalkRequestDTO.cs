namespace RJWalks.API.Models.DTOs
{
    public class UpdateWalkRequestDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthinKm { get; set; }

        public string? WalkImageURL { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace RJWalks.API.Models.DTOs
{
    public class UpdateWalkRequestDTO
    {

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0,50)]
        public double LengthinKm { get; set; }

        public string? WalkImageURL { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}

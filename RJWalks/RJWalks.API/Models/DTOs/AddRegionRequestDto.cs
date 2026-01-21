using System.ComponentModel.DataAnnotations;

namespace RJWalks.API.Models.DTOs
{
    public class AddRegionRequestDto
    {
        [Required]
        //[MinLength()]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string? RegionImgURl { get; set; }
    }
}

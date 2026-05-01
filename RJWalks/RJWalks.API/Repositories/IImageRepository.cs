using RJWalks.API.Models.Domain;

namespace RJWalks.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}

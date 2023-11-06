using ResumeSite.Helpers;
using ResumeSite.Models.Entities;

namespace ResumeSite.Models.ViewModels
{
    public class PublicationResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;

        public List<string> ImagesUrls { get; set; } = null!;
    }

    public static class PublicationResponseExtensions
    {
        public static PublicationResponse ToPublicationResponseWithImages(this Publication publication)
        {
            return new PublicationResponse
            {
                Id = publication.Id,
                Title = publication.Title,
                Description = publication.Description,
                ShortDescription = publication.Description.Substring(0, 5) + "...", // TODO: Change substring to 100 chars
                ImagesUrls = ImagesConverterHelper.ConvertImagesByteArraysToUrls(publication.Images)
            };
        }

        public static PublicationResponse ToPublicationResponse(this Publication publication)
        {
            return new PublicationResponse
            {
                Id = publication.Id,
                Title = publication.Title,
                Description = publication.Description,
                ShortDescription = publication.Description.Substring(0, 5) + "...", // TODO: Change substring to 100 chars
            };
        }
    }
}

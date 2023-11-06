using ResumeSite.Helpers;
using ResumeSite.Models.Entities;

namespace ResumeSite.Models.ViewModels
{
    public class PublicationUpdateRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<IFormFile> Images { get; set; } = null!;

        public Publication ToPublication()
        {
            return new Publication
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Images = ImagesConverterHelper.ConvertImagesToByteArrays(Images)
            };
        }
    }

    public static class PublicationUpdateRequestExtensions
    {
        public static PublicationUpdateRequest ToPublicationUpdateRequest(this PublicationResponse publicationResponse)
        {
            return new PublicationUpdateRequest
            {
                Id = publicationResponse.Id,
                Title = publicationResponse.Title,
                Description = publicationResponse.Description
            };
        }
    }
}

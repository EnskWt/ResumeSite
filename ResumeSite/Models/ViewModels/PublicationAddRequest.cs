using ResumeSite.Helpers;
using ResumeSite.Models.Entities;

namespace ResumeSite.Models.ViewModels
{
    public class PublicationAddRequest
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<IFormFile> Images { get; set; } = null!;

        public Publication ToPublication()
        {
            return new Publication
            {
                Title = Title,
                Description = Description,
                Images = ImagesConverterHelper.ConvertImagesToByteArrays(Images)
            };
        }
    }

}

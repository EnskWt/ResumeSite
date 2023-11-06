using ResumeSite.Models.Entities;

namespace ResumeSite.Helpers
{
    public static class ImagesConverterHelper
    {
        public static List<Image> ConvertImagesToByteArrays(List<IFormFile> files)
        {
            var result = new List<Image>();

            foreach (var file in files)
            {
                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);

                var image = new Image
                {
                    Data = memoryStream.ToArray()
                };

                result.Add(image);
            }

            return result;  
        }

        public static List<string> ConvertImagesByteArraysToUrls(List<Image> images)
        {
            var result = new List<string>();

            foreach (var image in images)
            {
                result.Add(string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(image.Data)));
            }

            return result;
        }
    }
}

using Microsoft.AspNetCore.Http;

namespace LivrariaMVC.Helpers
{
    public static class FileHelper
    {
        private static readonly string[] SupportedImageTypes = { ".jpg", ".jpeg", ".png", ".svg" };
        public static async Task<string?> ProcessarImgUploadAsync(IFormFile formFile, string uploadFolderPath)
        {
            if (formFile == null || formFile.Length < 0)
            {
                return null;
            }
            else
            {
                if(IsSupportedImageTypes(formFile))
                {
                    var filePath = Path.Combine(uploadFolderPath, Guid.NewGuid() + Path.GetExtension(formFile.FileName));
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        
                    }
                    return "/uploads/" + Path.GetFileName(formFile.FileName);
                }
                return "invalido"; 
            }
        }

        private static bool IsSupportedImageTypes(IFormFile File)
        {
            var extension = Path.GetExtension(File.FileName).ToLowerInvariant();
            return SupportedImageTypes.Contains(extension);
        }

    }
}


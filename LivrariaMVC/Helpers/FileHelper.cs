namespace LivrariaMVC.Helpers
{
    public static class FileHelper
    {
        private static readonly string[] SupportedImageTypes = { ".jpg", ".jpeg", ".png", ".svg" };
        public static async Task<string?> ProcessarImgUploadAsync(IFormFile FormFile, string UploadFolderPath)
        {
            if (FormFile == null || FormFile.Length < 0)
            {
                return null;
            }
            else
            {
                if(IsSupportedImageTypes(FormFile))
                {
                    var filePath = Path.Combine(UploadFolderPath, Path.GetFileName(FormFile.FileName));
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await FormFile.CopyToAsync(stream);
                    }
                    return "/uploads/" + Path.GetFileName(FormFile.FileName);
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


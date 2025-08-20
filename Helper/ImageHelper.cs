using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;



namespace Online_Courses.Helper
{
    public class ImageHelper
    {

        public static async Task<string> UploadImageAsync(IFormFile file, string folderPath)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName; // Yeh DB me store hoga
        }
    }
}

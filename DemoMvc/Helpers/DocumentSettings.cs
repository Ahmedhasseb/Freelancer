using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace DemoMvc.Helpers
{
    public static class DocumentSettings
    {
        public static string uploadFile(IFormFile file, string folderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\File\\", folderName);

            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            string path = Path.Combine(FolderPath, fileName);

            using var fs = new FileStream(path, FileMode.Create);
            file.CopyTo(fs);
            return fileName;
        }

        public static void DeleteFile(string file, string foldername)
        {
            if (file is not null && foldername is not null)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\File\\", foldername, file);
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }

        }

    }
}

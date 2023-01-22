using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string Add(IFormFile formFile, string root)
        {
            if (formFile!=null)
            {
                string extension = Path.GetExtension(formFile.FileName);
                string guid = Guid.NewGuid().ToString();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            else
            {
                return "default.jpg";
            }
            
        }

        public static void Delete(string folderPath,string imagePath)
        {
            if (imagePath!="default.jpg")
            {
                File.Delete(folderPath + imagePath);
            }
        }

        public static string Update(IFormFile formFile, string folderPath, string imagePath)
        {
            if (imagePath != "default.jpg")
            {
                File.Delete(folderPath + imagePath);
            }
            return Add(formFile,folderPath);
        }
    }
}

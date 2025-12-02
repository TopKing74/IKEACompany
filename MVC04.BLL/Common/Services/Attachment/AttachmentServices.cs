using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.Common.Services.Attachment
{
    public class AttachmentServices : IAttachmentServices
    {
        private readonly List<string> AllowedExtinsions=new List<string>() {"jpg", "jpeg", "png" };
        private const int MaxSize = 2_097_152;
        public string UploadImg(IFormFile File, string FolderName)
        {
            var FileExtention = Path.GetExtension(File.FileName).TrimStart('.').ToLower();
            if (!AllowedExtinsions.Contains(FileExtention))
                throw new Exception("Invalid File Extention");

            if (File.Length > MaxSize)
                throw new Exception("File Exceeds Maximum Size");

            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", FolderName);

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var FileName = $"{Guid.NewGuid()}_{File.FileName}";

            var FilePath= Path.Combine(FolderPath, FileName);

            using var FileStream = new FileStream(FilePath, FileMode.Create);
            File.CopyTo(FileStream);
            
            return FileName;

        }
        public bool DeleteImg(string FilePath)
        {
              if(File.Exists(FilePath))
            {
                File.Delete(FilePath);
                return true;
            }
              return false;
        }
    }
}

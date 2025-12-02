using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.Common.Services.Attachment
{
    public interface IAttachmentServices
    {
        public string UploadImg(IFormFile File , string FolderName);

        public bool DeleteImg(string FilePath);
    }
}

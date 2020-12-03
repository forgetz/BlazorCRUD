using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace BlazorCRUD.Service
{
    public class FileUpload
    {
        private readonly IWebHostEnvironment _environment;

        public FileUpload(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task UploadAsync(IFileListEntry fileEntry)
        {
            var filepath = Path.Combine(_environment.ContentRootPath, "Uploads", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(fs);
            }
        }
    }
}
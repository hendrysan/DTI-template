using DTI.Contexts;
using DTI.Models.Entities;
using DTI.Models.Requests;
using DTI.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DTI.Services.Implements
{
    public class FileRepository : IFileRepository
    {
        private readonly ConnectionContext _context;

        public FileRepository(ConnectionContext context)
        {
            _context = context;
        }

        private List<string> ExtensionAllowed = new List<string>()
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".pdf",
            ".doc",
            ".docx",
        };

        public async Task PostFileAsync(IFormFile fileData)
        {
            try
            {
                var extension = Path.GetExtension(fileData.FileName);
                
                if (!ExtensionAllowed.Where(i => i.Equals(extension)).Any())
                {
                    throw new Exception("File Extension Not Allowed");
                }


                var fileDetails = new FileDetail()
                {
                    Id = Guid.NewGuid(),
                    FileName = fileData.FileName,
                    Extension = extension
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                    fileDetails.FileBase64 = Convert.ToBase64String(stream.ToArray());
                }

                _context.FileDetails.Add(fileDetails);
                var result = await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

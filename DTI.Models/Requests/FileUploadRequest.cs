using Microsoft.AspNetCore.Http;

namespace DTI.Models.Requests
{
    public class FileUploadRequest
    {
        public IFormFile FileDetails { get; set; }
    }
}

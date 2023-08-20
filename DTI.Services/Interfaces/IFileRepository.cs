using Microsoft.AspNetCore.Http;

namespace DTI.Services.Interfaces
{
    public interface IFileRepository
    {
        Task PostFileAsync(IFormFile fileData);
    }
}

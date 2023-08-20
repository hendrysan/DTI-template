using DTI.Models.Entities;
using DTI.Models.Requests;

namespace DTI.Services.Interfaces
{
    public interface ISocietyRepository
    {
        Task<IEnumerable<Society>> GetAll();
        Task<Society> GetById(Guid id);
        Task<Society> Create(SocietyRequest request);
        Task<Society> Update(Guid id, SocietyRequest request);
        Task<Society> Delete(Guid id);
    }
}

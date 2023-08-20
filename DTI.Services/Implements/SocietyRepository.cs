using DTI.Contexts;
using DTI.Models.Entities;
using DTI.Models.Requests;
using DTI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DTI.Services.Implements
{
    public class SocietyRepository : ISocietyRepository
    {
        private readonly ConnectionContext _context;

        public SocietyRepository(ConnectionContext context)
        {
            _context = context;
        }
        public async Task<Society> Create(SocietyRequest request)
        {
            try
            {
                var society = new Society()
                {
                    FullName = request.FullName,
                    Address = request.Address,
                    Domicile = request.Domicile,
                    IdentityNumber = request.IdentityNumber,
                    IdentityFamilyNumber = request.IdentityFamilyNumber,
                    TaxNumber = request.TaxNumber,
                    BPJSNumber = request.BPJSNumber,
                    Phone = request.Phone,
                    Email = request.Email,
                    SelfiePhoto = request.SelfiePhoto,
                    IsActive = true
                };

                _context.Societies.Add(society);
                var result = await _context.SaveChangesAsync();
                return society;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Society> Delete(Guid id)
        {
            try
            {
                var society = _context.Societies.FirstOrDefault(x => x.Id == id && x.IsActive == true);
                if (society == null)
                {
                    throw new Exception("Society Not Found");
                }
                society.IsActive = false;
                var result = await _context.SaveChangesAsync();

                return society;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Society>> GetAll()
        {
            try
            {
                var societies = await _context.Societies.Where(x => x.IsActive == true).ToListAsync();
                return societies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Society> GetById(Guid id)
        {
            try
            {
                var society = await _context.Societies.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
                if (society == null)
                {
                    throw new Exception("Society Not Found");
                }

                return society;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Society> Update(Guid Id, SocietyRequest request)
        {
            try
            {
                var society = _context.Societies.FirstOrDefault(x => x.Id == Id && x.IsActive == true);
                if (society == null)
                {
                    throw new Exception("Society Not Found");
                }

                society.FullName = request.FullName;
                society.Address = request.Address;
                society.Domicile = request.Domicile;
                society.IdentityNumber = request.IdentityNumber;
                society.IdentityFamilyNumber = request.IdentityFamilyNumber;
                society.TaxNumber = request.TaxNumber;
                society.BPJSNumber = request.BPJSNumber;
                society.Phone = request.Phone;
                society.Email = request.Email;
                society.SelfiePhoto = request.SelfiePhoto;
                
                var result = await _context.SaveChangesAsync();
                return society;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

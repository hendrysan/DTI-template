using DTI.Models.Requests;
using DTI.Models.Responses;
using DTI.Services.Implements;
using DTI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DTI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SocietyController : ControllerBase
    {
        private readonly ISocietyRepository _societyRepository;
        private readonly IClientExternalRepository _clientExternalRepository;

        public SocietyController(ISocietyRepository societyRepository, IClientExternalRepository clientExternalRepository)
        {
            _societyRepository = societyRepository;
            _clientExternalRepository = clientExternalRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, SocietyRequest request)
        {
            try
            {
                var find = await _societyRepository.GetById(id);
                if (find == null)
                {
                    return BadRequest("Society Not Found");
                }

                var checkDukcapil = await _clientExternalRepository.ValidateDukcapil(request.IdentityNumber, request.IdentityFamilyNumber);
                if (checkDukcapil == false)
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Identity Number Not Found",
                        Data = request,
                        ErrorCode = 400,
                        IsSuccess = false
                    });

                var checkTelco = await _clientExternalRepository.ValidateTelco(request.Phone);
                if (checkTelco == false)
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Phone Number Not Found",
                        Data = request,
                        ErrorCode = 400,
                        IsSuccess = false
                    });

                var checkBPJS = await _clientExternalRepository.ValidateBPJS(request.BPJSNumber);
                if (checkBPJS == false)
                    return BadRequest(new ErrorModel()
                    {
                        Message = "BPJS Number Not Found",
                        Data = request,
                        ErrorCode = 400,
                        IsSuccess = false
                    });
                var checkTax = await _clientExternalRepository.ValidateTax(request.TaxNumber);
                if (checkTax == false)
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Tax Number Not Found",
                        Data = request,
                        ErrorCode = 400,
                        IsSuccess = false
                    });

                var res = await _societyRepository.Update(id, request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var res = await _societyRepository.Delete(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var res = await _societyRepository.GetById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocietyRequest request)
        {
            try
            {
                var checkDukcapil = await _clientExternalRepository.ValidateDukcapil(request.IdentityNumber, request.IdentityFamilyNumber);
                if (checkDukcapil == false)
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Identity Number Not Found",
                        Data = request,
                        ErrorCode = 400,
                        IsSuccess = false
                    });

                var checkTelco = await _clientExternalRepository.ValidateTelco(request.Phone);
                if (checkTelco == false)
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Phone Number Not Found",
                        Data = request,
                        ErrorCode = 400,
                        IsSuccess = false
                    });

                var checkBPJS = await _clientExternalRepository.ValidateBPJS(request.BPJSNumber);
                if (checkBPJS == false)
                    return BadRequest(new ErrorModel()
                    {
                        Message = "BPJS Number Not Found",
                        Data = request,
                        ErrorCode = 400,
                        IsSuccess = false
                    });
                var checkTax = await _clientExternalRepository.ValidateTax(request.TaxNumber);
                if (checkTax == false)
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Tax Number Not Found",
                        Data = request,
                        ErrorCode = 400,
                        IsSuccess = false
                    });


                var res = await _societyRepository.Create(request);
                return Ok(res);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _societyRepository.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

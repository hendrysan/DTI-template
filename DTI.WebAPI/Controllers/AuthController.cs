using DTI.Models.Requests;
using DTI.Models.Responses;
using DTI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DTI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ITokenRepository _tokenRepository;

        public AuthController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AuthResponse>> AuthResponse([FromBody] AuthRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (request.identity.ToLower() != "string" && request.password.ToLower() != "string")
                    return BadRequest("Invalid Credentials");

                var refreshToken = _tokenRepository.GenerateRefreshToken();
                var expired = _tokenRepository.GetRefreshTokenExpiryTime();
                var accessToken = _tokenRepository.CreateToken(Guid.NewGuid().ToString(), "123", request.identity, expired);


                var result = new AuthResponse();
                result.AccessToken = accessToken;
                result.RefreshToken = refreshToken;
                result.Expired = expired;

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

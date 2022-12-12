using C__RPG_Backend.Data;
using C__RPG_Backend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace C__RPG_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO request)
        {
            var response = await _authRepo.Register(

                new User { Username = request.Username}, request.Password
            );
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDTO request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);
        }

    }

    
}
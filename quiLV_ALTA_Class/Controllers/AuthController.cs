using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.JwtService;
using quiLV_ALTA_Class.Services.UserService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService; 

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _userService.AuthenticateAsync(loginModel.UserName, loginModel.Password);
            if (account == null)
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateToken(account);
            return Ok(token);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (registerModel == null)
                return BadRequest("Invalid input.");

            var newUser = await _userService.RegisterAsync(registerModel.UserName, registerModel.Password, registerModel.Email);

            if (newUser == null)
                return Conflict("Username already exists.");

            return Ok(newUser);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            var result = await _userService.ForgotPasswordAsync(email);
            if (result)
            {
                return StatusCode(204); 
            }
            return StatusCode(404);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _userService.ResetPasswordAsync(request.Otp, request.NewPassword);
            if (result)
            {
                return StatusCode(204); 
            }
            return StatusCode(400);
        }



        [HttpPost("register-teacher")]
        public async Task<IActionResult> RegisterTeacher([FromBody] RegisterModel model)
        {
            var result = await _userService.RegisterTeacherAsync(model.UserName, model.Password, model.Email);
            if (result == null)
            {
                return StatusCode(409);
            }
            return StatusCode(201, result);
        }

        [HttpPost("register-student")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterModel model)
        {
            var result = await _userService.RegisterStudentAsync(model.UserName, model.Password, model.Email);
            if (result == null)
            {
                return StatusCode(409);
            }

            return StatusCode(201,result);
        }

    }
}

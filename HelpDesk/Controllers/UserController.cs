using Microsoft.AspNetCore.Mvc;
using src;
using src.Data;
using src.DTO;
using src.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly JWTservice _jwtService;

        public UserController(IUserRepository userRepository, JWTservice jwtServices)
        {
            _userRepository = userRepository;
            _jwtService = jwtServices;
        }

        [HttpGet("home")]
        public String Home()
        {
            return "Get funciona";
        }	


        [HttpGet("user")]
        public IActionResult GetLoggedInUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                if (string.IsNullOrEmpty(jwt))
                {
                    return Unauthorized(new { message = "JWT token not provided." });
                }

                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);

                var user = _userRepository.GetUserById(userId);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized(new { message = "Authorization failed!" });
            }
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserRegisterDTO request)
        {
            try
            {
                var user = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password
                };

                _userRepository.Create(user);

                return Ok("User registered successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO loginDTO)
        {
            try
            {
                var user = _userRepository.GetUserByEmail(loginDTO.Email);

                if (user == null || user.Password != loginDTO.Password)
                {
                    return Unauthorized(new { message = "Invalid Credentials." });
                }

                var token = _jwtService.Generate(user.Id);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                };

                Response.Cookies.Append("jwt", token, cookieOptions);

                return Ok(new { user, message = "sucess!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"ops {ex.Message}" });
            }
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message = "Logged out successfully!" });
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using WebQLSV.Models;

namespace WebQLSV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<UserAccount> _users = new List<UserAccount>();

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserAccount user)
        {
            if (_users.Any(u => u.Username == user.Username))
                return BadRequest(new { message = "Tên đăng nhập đã tồn tại!" });
            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            return Ok(new { message = "Đăng ký thành công!" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserAccount login)
        {
            var user = _users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null)
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu!" });
            return Ok(new { message = "Đăng nhập thành công!", username = user.Username, role = user.Role });
        }
    }
} 
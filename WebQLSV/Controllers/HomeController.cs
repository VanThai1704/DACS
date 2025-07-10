using Microsoft.AspNetCore.Mvc;

namespace WebQLSV.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Chào mừng bạn đến với API Quản Lý Sinh Viên!");
        }
    }
} 
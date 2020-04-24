using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Portal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var versao = _config.GetValue<string>("Version");
            ViewBag.Versao = versao;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
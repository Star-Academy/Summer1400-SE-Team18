using Microsoft.AspNetCore.Mvc;

namespace SearchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Route("")]
    [Route("api")]
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Google()
        {
            return View();
        }
    }
}
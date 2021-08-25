using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchWeb.Models;

namespace SearchWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
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
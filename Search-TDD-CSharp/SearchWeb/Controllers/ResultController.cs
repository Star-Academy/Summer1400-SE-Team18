using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Search.Search;

namespace SearchWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        public static string ResultString { get; set; }
        private ISearcher _searcher;

        public ResultController(ISearcher searcher)
        {
            _searcher = searcher;
        }

        public IActionResult Result([FromQuery]string text)
        {
            if (IsStringValid(text))
            {
                ResultString = HashSetToString(_searcher.Search(text));
                return View();
            }

            return NotFound("404");
        }

        private string HashSetToString(HashSet<string> set)
        {
            return set.Count == 0 ? "Nothing Found" : set.Aggregate((next, current) => next + ", " + current);
        }

        private static bool IsStringValid(string text)
        {
            if (text.Length > 35) return false;
            return Regex.Split(text, "\\s+")
                .All(variable => Regex.Match(variable, "[\\w\\+\\-_\\.]+").Success);
        }
    }
}
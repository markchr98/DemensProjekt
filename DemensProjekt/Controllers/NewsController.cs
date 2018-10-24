using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemensProjekt.Controllers
{
    [Route("news")]
    public class NewsController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("{year:int}/{month:range(1,12}/{key}")]
        public IActionResult News(int year, int month, string key)
        {

        }
    }
}
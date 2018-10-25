using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemensProjekt.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemensProjekt.Controllers
{
    [Route("news")]
    public class NewsController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            var news = new News
            {
                newsTitle = "Gulerødder hjælper på demens",
                newsBody = "Lang teskt",
                newsDate = DateTime.Now

            };
            return View(news);
        }

        [Route("{year:int}/{month:range(1,12)}/{key}")]
        public IActionResult News(int year, int month, string key)
        {
            var news = new News
            {
                newsTitle = "Gulerødder hjælper på demens",
                newsBody = "Lang teskt",
                newsDate = DateTime.Now

            };

            return View(news);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemensProjekt.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemensProjekt.Controllers
{
    [Route("forum")]
    public class ForumController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            var posts = new[]
            {
                new Post{}
            };
            return View(posts);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;
            return View();
        }
    }
}

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
        private readonly ForumDataContext _db;
        public ForumController(ForumDataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _db.Posts.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                _db.Posts
                    .OrderByDescending(x => x.Posted)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToArray();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(posts);

            return View(posts);
        }

        [HttpGet, Route("create")]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult CreatePost(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;


            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Index", "Forum", new
            {
                year = post.Posted.Year,
                month = post.Posted.Month        
            });
        }

        [HttpGet, Route("create")]
        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult CreateComment(Comment comment)
        {
            if (!ModelState.IsValid)
                return View();

            comment.Author = User.Identity.Name;
            comment.Posted = DateTime.Now;

            _db.Comments.Add(comment);
            _db.SaveChanges();

            return RedirectToAction("Index", "Forum", new
            {
                year = comment.Posted.Year,
                month = comment.Posted.Month
            });
        }

       
    }
}

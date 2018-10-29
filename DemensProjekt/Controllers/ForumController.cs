using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemensProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            //var pageSize = 2;
            //var totalPosts = _db.Posts.Count();
            //var totalPages = totalPosts / pageSize;
            //var previousPage = page - 1;
            //var nextPage = page + 1;

            //ViewBag.PreviousPage = previousPage;
            //ViewBag.HasPreviousPage = previousPage >= 0;
            //ViewBag.NextPage = nextPage;
            //ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                _db.Posts
                    .Include(p => p.Comments).OrderByDescending(p => p.Posted)
                    //.Skip(pageSize * page)
                    //.Take(pageSize)
                    .ToArray();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(posts);

            return View(posts);
        }

        [HttpGet, Route("CreatePost")]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost, Route("CreatePost")]
        public IActionResult CreatePost(Post post)
        {
            if (!ModelState.IsValid)
                return View("Index");

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;


            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Index", "Forum");
        }

        [HttpGet, Route("CreateComment")]
        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost, Route("CreateComment")]
        public IActionResult CreateComment(Comment comment)
        {
            if (!ModelState.IsValid)
                return View();

            comment.Author = User.Identity.Name;
            comment.Posted = DateTime.Now;

            Console.WriteLine(comment);

            //comment.Post = _db.Find(x => x.Id = comment.PostId); for future 

            _db.Comments.Add(comment);
            _db.SaveChanges();

            return RedirectToAction("Index", "Forum");
        }

        [HttpPut, Route("UpdateComment")]
        public IActionResult UpdateComment()
        {
            return View();
        }

        [HttpPut, Route("UpdateComment")]
        public IActionResult UpdateComment(long id, [FromBody]Comment updated)
        {
            var comment = _db.Comments.FirstOrDefault(x => x.CommentId == id);

            if (comment == null)
                return NotFound();

            comment.Body = updated.Body;

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete, Route("DeleteComment")]
        public IActionResult DeleteComment()
        {
            return View();
        }

        [HttpDelete, Route("DeleteComment")]
        public void DeleteComment(long id)
        {
            var comment = _db.Comments.FirstOrDefault(x => x.CommentId == id);
            
            if(comment != null)
            {
                _db.Comments.Remove(comment);
                _db.SaveChanges();
            }

            RedirectToAction("Index", "Forum");
        }
    }
}

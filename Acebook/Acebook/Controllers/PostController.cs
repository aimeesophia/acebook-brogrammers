using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Acebook.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Acebook.Controllers
{
    public class PostController : Controller
    {

        private readonly AcebookContext _context;

        public PostController(AcebookContext context)
        {
            _context = context;
        }

            // GET: /<controller>/
        //    public IActionResult Index()
        //{
        //    return _context.AcebookItems.ToList;
        //    //View all posts
        //    //return View();
        //}

        [HttpGet]
        public ActionResult<List<Post>> Index()
        {
            ViewBag.Posts = _context.posts.ToList();
            ViewBag.Username = HttpContext.Session.GetString("username");
            var posts = (
                from p in _context.posts
                join u in _context.users
                on p.userid equals u.id
                select new
                {
                    id = p.id,
                    content = p.content,
                    username = u.username
                });
            ViewBag.NewPosts = posts;
            //_context.posts.Join(
            //    from userid in _context.posts
            //    join id in _context.users
            //)
            return View();
        }

        // GET: /<controller>/:id
        [HttpGet]
        public IActionResult Read(long id = 1)
        {
            //Views a single post
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Item = _context.posts.Find(id);
                if (ViewBag.item == null)
                {
                    return NotFound();
                }
            return View();
        }

        // GET: /<controller>/new
        public IActionResult New()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }

        [HttpPost]
        public void Create(string content)
        {
            var userid = HttpContext.Session.GetInt32("id") ?? default(int);
            _context.posts.Add(new Post { content = content, userid = userid });
            _context.SaveChanges();
            Response.Redirect("Index");
        }

        // GET: /<controller>/:id/edit
        public IActionResult Edit(long id)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Item = _context.posts.Find(id);
            if (ViewBag.item == null)
            {
                return NotFound();
            }
            return View();
        }

        //PATCH: /<controller>/:id
        [HttpPost]
        public void Update(string content, long id)
        {
            var entry = _context.posts.Find(id);
            entry.content = content;
            _context.SaveChanges();
            Response.Redirect("../Index");
        }
        
        //DELETE: /<controller>/:id/delete
        [HttpPost]
        public void Delete(long id = 1)
        {
            ViewBag.Item = _context.posts.Find(id);
            _context.Remove(ViewBag.Item);
            _context.SaveChanges();
            Response.Redirect("../Index");
        }
    }
}

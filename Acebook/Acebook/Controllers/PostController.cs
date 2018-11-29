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
            ViewBag.Username = HttpContext.Session.GetString("username");
            _context.posts.Add(new Post { content = content, username = ViewBag.username });
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

            //if (_context.AcebookItems.Count() == 0)
            //{
            //    _context.AcebookItems.Add(new Post { message = "Item1" });
            //    _context.SaveChangesS ();
            //}
        }

            // GET: /<controller>/
        //    public IActionResult Index()
        //{
        //    return _context.AcebookItems.ToList;
        //    //View all posts
        //    //return View();
        //}

        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            ViewBag.Posts = _context.posts.ToList();
            return View();
        }

        // GET: /<controller>/:id
        public IActionResult Read()
        {
            //Views a single post
            return View();
        }

        // GET: /<controller>/new
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public void Create(string content)
        {
            _context.posts.Add(new Post { content = content });
            _context.SaveChanges();
            Response.Redirect("GetAll");
        }

        // GET: /<controller>/:id/edit
        public IActionResult Edit()
        {
            return View();
        }

        // PATCH: /<controller>/:id
        //public IActionResult Update()
        //{
        //    //Redirect page
        //}

        // DELETE: /<controller>/:id/delete
        //public IActionResult Destroy()
        //{
        //    //Redirect page
        //}
    }
}

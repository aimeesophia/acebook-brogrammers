using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Acebook.Controllers
{
    public class PostController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //View all posts
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

        // POST: /<controller>/
        //public IActionResult Create()
        //{
        //    //Redirect page
        //}

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

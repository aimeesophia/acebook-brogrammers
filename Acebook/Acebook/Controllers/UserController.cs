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
    public class UserController : Controller
    {

        private readonly AcebookContext _context;

        public UserController(AcebookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        
        }

        [HttpPost]
        public void SignIn(string username)
        {
            HttpContext.Session.SetString("username", username);
            //var user = _context.users.Where(users => users.username.Matches("melissa13"));
            //ViewBag.User = user;
            //SET SESSION VARIABLE HERE
            Response.Redirect("../Post");
        }

        // GET: /<controller>/
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public void Create(string username, string password)
        {
            _context.users.Add(new User { username = username, password = password });
            _context.SaveChanges();
            HttpContext.Session.SetString("username", username);
            Response.Redirect("../Post");
        }

        public void SignOut()
        {
            HttpContext.Session.Clear();
            Response.Redirect("../Post");
        }
    }
}

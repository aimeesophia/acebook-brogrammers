using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
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
            ViewBag.Message = TempData["FlashMessage"];
            return View();
        
        }

        [HttpPost]
        public void SignIn(string username, string password)
        {
            var user = _context.users.SingleOrDefault(c => c.username == username);
            if (user != null && Acebook.Models.User.AuthenticateSignIn(user.password, password)) {
                HttpContext.Session.SetString("username", user.username);
                HttpContext.Session.SetInt32("id", user.id);
                Response.Redirect("../Post");
            } else {
                TempData["FlashMessage"] = "Login credentials do not match.";
                Response.Redirect("https://localhost:5001/User");
            }
        }

        // GET: /<controller>/
        public IActionResult New()
        {
            ViewBag.Message = TempData["FlashMessage"];
            return View();
        }

        [HttpPost]
        public void Create(string username, string password)
        {
            var user = _context.users.SingleOrDefault(c => c.username == username);
            if (user != null)
            {
                TempData["FlashMessage"] = "Username already in use";
                Response.Redirect("New");
            }
            else
            {
                var encrypted = Acebook.Models.Encryption.EncryptPassword(password);
                _context.users.Add(new User { username = username, password = encrypted });
                _context.SaveChanges();
                var newuser = _context.users.SingleOrDefault(c => c.username == username);
                HttpContext.Session.SetString("username", newuser.username);
                HttpContext.Session.SetInt32("id", newuser.id);
                Response.Redirect("../Post");
            }
        }

        public void SignOut()
        {
            HttpContext.Session.Clear();
            Response.Redirect("../Post");
        }
    }
}

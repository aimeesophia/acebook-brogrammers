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
                Response.Redirect("../Post");
            } else {
                TempData["FlashMessage"] = "Login credentials do not match.";
                Response.Redirect("https://localhost:5001/User");
            }

            //var decrypted = Acebook.Models.Encryption.DecryptPassword(user.password);
            //if (user == null) {
            //    Response.Redirect("https://localhost:5001/User");
            //} else if (password != decrypted) {
            //    Response.Redirect("https://localhost:5001/User");
            //} else {
            //    HttpContext.Session.SetString("username", user.username);
            //    Response.Redirect("../Post");
            //}
        }

        // GET: /<controller>/
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public void Create(string username, string password)
        {
            var encrypted = Acebook.Models.Encryption.EncryptPassword(password);
            _context.users.Add(new User { username = username, password = encrypted });
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            Response.Redirect("../Post");
        }
    }
}

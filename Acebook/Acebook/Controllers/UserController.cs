﻿using System;
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
            return View();
        
        }

        [HttpPost]
        public void SignIn(string username, string password)
        {
            var user = _context.users.SingleOrDefault(c => c.username == username && c.password == password);
            if (user != null) {
                HttpContext.Session.SetString("username", user.username);
                Response.Redirect("../Post");
            } else {
                Response.Redirect("https://localhost:5001/User");
            }
        }

        // GET: /<controller>/
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public void Create(string username, string password)
        {
            var instance = new User();
            var encrypted = instance.Encrypt(password);
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

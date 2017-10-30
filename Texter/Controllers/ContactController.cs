using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Texter.Models;

namespace Texter.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public ContactController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_db.Contacts.ToList());
        }

        public IActionResult AddContact(string id)
        {
            ViewBag.user = _db.Users.FirstOrDefault(x => x.Id == id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Contact newContact)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newContact.User = currentUser;
            _db.Contacts.Add(newContact);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = userId });

        }
    }
}
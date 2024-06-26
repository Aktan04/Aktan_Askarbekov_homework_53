using Hw53.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hw53.Controllers
{
    public class PhoneReviewController : Controller
    {
        private readonly MobileContext _context;

        public PhoneReviewController(MobileContext context)
        {
            _context = context;
        }

        public IActionResult Create(int phoneId)
        {
            ViewBag.PhoneId = phoneId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhoneReview review)
        {
            if (ModelState.IsValid)
            {
                _context.PhoneReviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Index", "Phone");
            }
            return View(review);
        }
    }
}
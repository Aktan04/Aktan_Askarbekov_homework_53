using Hw53.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hw53.Controllers;

public class PhoneController : Controller
{
    private MobileContext _db;

    public PhoneController(MobileContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        List<Phone> phones = _db.Phones.Include(p => p.Reviews).ToList();
        return View(phones);
    }

    public IActionResult Create()
    {
        ViewBag.Brands = _db.Brands.ToList();
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Phone phone)
    {
        if (ModelState.IsValid)
        {
            _db.Phones.Add(phone);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        ViewBag.Brands = _db.Brands.ToList();
        return View(phone);
    }
    
    public IActionResult Edit(int? id)
    {
        
        if (id != null)
        {
            Phone phone = _db.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                ViewBag.Brands = _db.Brands.ToList();
                return View(phone);
            }
        }
        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(Phone phone)
    {
        ViewBag.Brands = _db.Brands.ToList();
        if (ModelState.IsValid)
        {
            _db.Phones.Update(phone);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(phone);
    }
    
    public IActionResult Delete(int? id)
    {
        if (id != null)
        {
            Phone phone = _db.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                return View(phone);
            }
        }
        return NotFound();
    }
    
    [HttpPost]
    public IActionResult ConfirmDelete(int? id)
    {
        if (id != null)
        {
            Phone phone = _db.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                _db.Phones.Remove(phone);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        return NotFound();
    }
}
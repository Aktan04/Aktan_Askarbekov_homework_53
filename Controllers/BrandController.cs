using Hw53.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hw53.Controllers;

public class BrandController : Controller
{
    private readonly MobileContext _db;

    public BrandController(MobileContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var brands = _db.Brands.ToList();
        return View(brands);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Brand brand)
    {
        if (ModelState.IsValid)
        {
            _db.Brands.Add(brand);
            _db.SaveChanges();
            return RedirectToAction("Index", "Phone");
        }
        return View(brand);
    }
    
    public IActionResult Edit(int id)
    {
        var brand = _db.Brands.Find(id);
        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    [HttpPost]
    public IActionResult Edit(Brand brand)
    {
        if (ModelState.IsValid)
        {
            _db.Update(brand);
            _db.SaveChanges();
            return RedirectToAction("Index", "Brand");
        }
        return View(brand);
    }
}
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class CategoryController : Controller
{   
    private readonly ApplicationDbContext _database;

    public CategoryController(ApplicationDbContext database)
    {
        _database = database;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> fetchedCategoriesList = _database.Categories;
        return View(fetchedCategoriesList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The Display Order Cannot Match Name");
        }
        if (ModelState.IsValid)
        {
            _database.Categories.Add(obj);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if ( id == null || id == 0)
        {
            return NotFound();
        }

        var category = _database.Categories.Find(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The Display Order Cannot Match Name");
        }
        if (ModelState.IsValid)
        {
            _database.Categories.Update(obj);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if ( id == null || id == 0)
        {
            return NotFound();
        }

        var category = _database.Categories.Find(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var category = _database.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }

        _database.Categories.Remove(category);
        _database.SaveChanges();
        return RedirectToAction("Index");
    }
}

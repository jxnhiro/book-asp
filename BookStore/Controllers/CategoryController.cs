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
}

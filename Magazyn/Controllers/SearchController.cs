using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magazyn.Context;
using Magazyn.Models;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class SearchController : Controller
{
    private readonly MagazynDbContext _context;


    public SearchController(MagazynDbContext context)
    {
        _context = context;
    }

    public IActionResult SearchItems()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SearchItems(string searchString)
    {
        if (string.IsNullOrEmpty(searchString))
        {
            return RedirectToAction(nameof(Index), "Items");
        }

        var items = await _context.Items
            .Where(item => item.Name.Contains(searchString))
            .ToListAsync();

        return View("SearchResults", items);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YonWeb.Data;
using YonWeb.Model;

namespace YonWeb.Pages.Categories;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;

    [BindProperty]
    public Category Category { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }

    

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if(Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the name.");
        }

        if(ModelState.IsValid)
        {
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();

            TempData["success"] = "Category created successfully";

            return RedirectToPage("Index");
        }
        return Page();
    }
}

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
        if(ModelState.IsValid)
        {
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        return Page();
    }
}

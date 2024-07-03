using Microsoft.EntityFrameworkCore;
using YonWeb.Model;

namespace YonWeb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }


    public DbSet<Category> Category => Set<Category>();
}

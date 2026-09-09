using Microsoft.EntityFrameworkCore;
using ICE4.Models;

namespace ICE4.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }

}

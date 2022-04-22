using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Entities;

namespace VerticalSliceArchitecture.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
}

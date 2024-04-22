using Microsoft.EntityFrameworkCore;

namespace AspireApp1.Shared;
internal class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
}

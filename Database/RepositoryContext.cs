using ASPNETCORE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE_API.Database
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

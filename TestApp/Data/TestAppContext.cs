
using TestApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TestApp.Data;

public class TestAppContext : IdentityDbContext<Usuario>
{
    public DbSet<CategoriaItem> CategoriaItem { get; set; } = null!;
    public DbSet<Negocio> Negocio { get; set; } = null!;
    public DbSet<Item> Item { get; set; } = null!;
    public DbSet<Usuario> Usuario { get; set; } = null!;
    public TestAppContext()
    {
    }

    public TestAppContext(DbContextOptions<TestAppContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
}
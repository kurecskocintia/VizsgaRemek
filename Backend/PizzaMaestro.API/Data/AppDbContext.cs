using Microsoft.EntityFrameworkCore;
using PizzaMaestro.API.Models;

namespace PizzaMaestro.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes => Set<Recipe>();

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique();

        b.Entity<User>()
            .HasIndex(x => x.UserName)
            .IsUnique();

        b.Entity<Recipe>()
            .HasOne(x => x.User)
            .WithMany(x => x.Recipes)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<Recipe>().HasData(
            new Recipe
            {
                Id = 1,
                Name = "24 órás klasszikus",
                YeastType = "Friss élesztő",
                Hydration = 60,
                SaltPercent = 2.8,
                Description = "Hosszú, kontrollált fermentáció friss élesztővel."
            },
            new Recipe
            {
                Id = 2,
                Name = "Folyékony kovász",
                YeastType = "Folyékony kovász",
                Hydration = 62,
                SaltPercent = 3.0,
                Description = "A li.co.li. karakteresebb, aromásabb tésztához."
            },
            new Recipe
            {
                Id = 3,
                Name = "Lievito madre",
                YeastType = "Lievito madre",
                Hydration = 60,
                SaltPercent = 3.0,
                Description = "Szilárd kovászra épülő, hosszabb fermentációhoz."
            }
        );
    }
}
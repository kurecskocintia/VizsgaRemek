namespace PizzaMaestro.API.Models;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = "";

    public string Email { get; set; } = "";

    public string PasswordHash { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
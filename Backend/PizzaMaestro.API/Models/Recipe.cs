namespace PizzaMaestro.API.Models;

public class Recipe
{
    public int Id { get; set; }

    public string Name { get; set; } = "";
    public string YeastType { get; set; } = "";

    public int Balls { get; set; }
    public double BallWeight { get; set; }

    public double TotalDoughWeight { get; set; }

    public double Hydration { get; set; }
    public double SaltPercent { get; set; }

    public double FlourGrams { get; set; }
    public double WaterGrams { get; set; }
    public double SaltGrams { get; set; }
    public double YeastGrams { get; set; }

    public string YeastLabel { get; set; } = "";

    public double RoomTemp { get; set; }
    public double RoomHours { get; set; }

    public double FridgeTemp { get; set; }
    public double FridgeHours { get; set; }

    public double TotalHours { get; set; }

    public double SourdoughFlourGrams { get; set; }
    public double SourdoughWaterGrams { get; set; }

    public string Description { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int? UserId { get; set; }

    public User? User { get; set; }
}
namespace PizzaMaestro.API.DTOs;

public record SaveRecipeRequest(
    string Name,
    int Balls,
    double BallWeight,
    double TotalDoughWeight,
    double Hydration,
    double SaltPercent,
    double FlourGrams,
    double WaterGrams,
    double SaltGrams,
    double YeastGrams,
    string YeastType,
    string YeastLabel,
    double RoomTemp,
    double RoomHours,
    double FridgeTemp,
    double FridgeHours,
    double TotalHours,
    double SourdoughFlourGrams,
    double SourdoughWaterGrams,
    string Description
);
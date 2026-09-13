namespace PizzaMaestro.API.DTOs;
public record CalculatorRequest(
    int Balls, double BallWeight, double Hydration, double Salt,
    string YeastType, double RoomTemp, double RoomHours, double FridgeTemp, double FridgeHours);
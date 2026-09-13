namespace PizzaMaestro.API.DTOs;
public class CalculatorResponse {
 public double TotalDoughWeight {get;set;} public double FlourGrams{get;set;} public double WaterGrams{get;set;} public double SaltGrams{get;set;}
 public double YeastGrams{get;set;} public string YeastLabel{get;set;}=""; public double Hydration{get;set;} public double SaltPercent{get;set;}
 public bool AvpnHydrationOk{get;set;} public bool AvpnSaltOk{get;set;} public bool AvpnOverallOk{get;set;}
 public double RoomHours{get;set;} public double FridgeHours{get;set;} public double RoomTemp{get;set;} public double FridgeTemp{get;set;} public double TotalHours{get;set;}
 public double SourdoughFlourGrams{get;set;} public double SourdoughWaterGrams{get;set;}
}
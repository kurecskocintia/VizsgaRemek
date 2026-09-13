using PizzaMaestro.API.DTOs;
namespace PizzaMaestro.API.Services;
public class DoughCalculatorService {
 public CalculatorResponse Calculate(CalculatorRequest r) {
   var total = r.Balls * r.BallWeight;
   var salt = total * r.Salt / 100.0;
   // Baker's percentages. With sourdough, flour/water include the preferment.
   var flour = total / (1 + r.Hydration/100.0 + r.Salt/100.0);
   var water = flour * r.Hydration / 100.0;
   var yeast = EstimateYeast(flour, r);
   double sf=0, sw=0;
   if(r.YeastType=="liquidSourdough" || r.YeastType=="lievitoMadre") {
      var pct = r.YeastType=="liquidSourdough" ? 0.08 : 0.07;
      var preferment = flour*pct;
      sf = preferment * (r.YeastType=="liquidSourdough"?0.50:0.45);
      sw = preferment-sf;
      yeast = preferment;
      flour -= sf; water -= sw;
   }
   return new CalculatorResponse {
      TotalDoughWeight=total, FlourGrams=flour, WaterGrams=water, SaltGrams=salt, YeastGrams=yeast,
      YeastLabel=r.YeastType switch { "fresh"=>"Friss élesztő","dry"=>"Szárított sörélesztő","liquidSourdough"=>"Folyékony kovász","lievitoMadre"=>"Lievito madre",_=>r.YeastType},
      Hydration=r.Hydration, SaltPercent=r.Salt, AvpnHydrationOk=r.Hydration>=55&&r.Hydration<=62,
      AvpnSaltOk=r.Salt>=2.5&&r.Salt<=3.75, AvpnOverallOk=r.Hydration>=55&&r.Hydration<=62&&r.Salt>=2.5&&r.Salt<=3.75,
      RoomHours=r.RoomHours,FridgeHours=r.FridgeHours,RoomTemp=r.RoomTemp,FridgeTemp=r.FridgeTemp,TotalHours=r.RoomHours+r.FridgeHours,
      SourdoughFlourGrams=sf,SourdoughWaterGrams=sw
   };
 }
 private static double EstimateYeast(double flour, CalculatorRequest r) {
   if(r.YeastType=="liquidSourdough"||r.YeastType=="lievitoMadre") return 0;
   var hours = Math.Max(1, r.RoomHours + r.FridgeHours*0.15);
   var temp = Math.Max(4, (r.RoomTemp*r.RoomHours + r.FridgeTemp*r.FridgeHours)/Math.Max(0.1,r.RoomHours+r.FridgeHours));
   // Practical estimate calibrated around ~0.17 g fresh yeast/kg flour for 24 h at 23 C.
   var baseFresh = 0.17 * (flour/1000.0) * (24.0/hours) * Math.Pow(2.0,(23-temp)/8.0);
   baseFresh = Math.Clamp(baseFresh, 0.05*(flour/1000), 3.0*(flour/1000));
   return r.YeastType=="dry" ? baseFresh/3.0 : baseFresh;
 }
}
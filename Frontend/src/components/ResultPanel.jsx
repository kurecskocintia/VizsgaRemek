import AvpnBadge from "./AvpnBadge";
export default function ResultPanel({ result, onSave, saving }) {
 if(!result) return <div className="card empty"><div className="pizza">🍕</div><h2>A recept eredménye itt jelenik meg</h2><p>Állítsd be a paramétereket, majd kattints a kalkulációra.</p></div>;
 return <div className="card result">
  <div className="result-head"><div><p className="eyebrow">Kiszámított recept</p><h2>{result.totalDoughWeight.toFixed(0)} g össztészta</h2></div><AvpnBadge ok={result.avpnHydrationOk && result.avpnSaltOk}>{result.avpnOverallOk?"AVPN-kompatibilis tartomány":"Ellenőrizendő érték"}</AvpnBadge></div>
  <div className="ingredients">
   <div><span>Víz</span><b>{result.waterGrams.toFixed(1)} g</b></div>
   <div><span>Liszt</span><b>{result.flourGrams.toFixed(1)} g</b></div>
   <div><span>Só</span><b>{result.saltGrams.toFixed(1)} g</b></div>
   <div><span>{result.yeastLabel}</span><b>{result.yeastGrams.toFixed(2)} g</b></div>
  </div>
  {result.sourdoughFlourGrams>0 && <p className="note">A kovászban lévő liszt: {result.sourdoughFlourGrams.toFixed(1)} g, víz: {result.sourdoughWaterGrams.toFixed(1)} g. Ezek a teljes recept liszt/víz mennyiségébe beszámítanak.</p>}
  <div className="checks"><p><strong>Hidratáció:</strong> {result.hydration.toFixed(1)}% <AvpnBadge ok={result.avpnHydrationOk}>{result.avpnHydrationOk?"55–62%":"kívül"}</AvpnBadge></p><p><strong>Só:</strong> {result.saltPercent.toFixed(1)}% <AvpnBadge ok={result.avpnSaltOk}>{result.avpnSaltOk?"2,5–3,75%":"kívül"}</AvpnBadge></p></div>
  <div className="fermentation"><h3>Fermentáció</h3><p>Szoba: {result.roomHours} óra / {result.roomTemp} °C · Hűtő: {result.fridgeHours} óra / {result.fridgeTemp} °C · Összesen: {result.totalHours} óra</p></div>
  <p className="disclaimer">Az élesztőmennyiség iránymutató becslés a megadott idő/hőmérséklet alapján; a liszt, élesztő/kovász aktivitása és a környezet jelentősen befolyásolja a valós fermentációt.</p>
    <div className="result-actions">
    <button
      className="primary"
      onClick={onSave}
      disabled={saving}
    >
      {saving ? "Mentés..." : "💾 Recept mentése"}
    </button>
  </div>
 </div>
}
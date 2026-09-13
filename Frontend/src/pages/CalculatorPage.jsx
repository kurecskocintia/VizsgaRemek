import { useState } from "react";
import DoughForm from "../components/DoughForm";
import ResultPanel from "../components/ResultPanel";
import { calculateDough } from "../api/calculatorApi";
import { saveRecipe } from "../api/recipeApi";

export default function CalculatorPage() {
  const [result, setResult] = useState(null);
  const [loading, setLoading] = useState(false);
  const [saving, setSaving] = useState(false);

  async function calc(v) {
    setLoading(true);

    try {
      const calculated = await calculateDough(v);

      setResult({
        ...calculated,
        balls: v.balls,
        ballWeight: v.ballWeight,
        yeastType: v.yeastType
      });
    } catch (e) {
      alert("Nem sikerült elérni az API-t. Fut a backend?");
      console.error(e);
    } finally {
      setLoading(false);
    }
  }

  async function handleSave() {
    if (!result) return;

    const name = window.prompt(
      "Milyen néven szeretnéd elmenteni a receptet?"
    );

    if (!name || !name.trim()) return;

    setSaving(true);

    try {
      await saveRecipe({
        name: name.trim(),

        balls: result.balls,
        ballWeight: result.ballWeight,

        totalDoughWeight: result.totalDoughWeight,

        hydration: result.hydration,
        saltPercent: result.saltPercent,

        flourGrams: result.flourGrams,
        waterGrams: result.waterGrams,
        saltGrams: result.saltGrams,
        yeastGrams: result.yeastGrams,

        yeastType: result.yeastType,
        yeastLabel: result.yeastLabel,

        roomTemp: result.roomTemp,
        roomHours: result.roomHours,

        fridgeTemp: result.fridgeTemp,
        fridgeHours: result.fridgeHours,

        totalHours: result.totalHours,

        sourdoughFlourGrams: result.sourdoughFlourGrams,
        sourdoughWaterGrams: result.sourdoughWaterGrams,

        description: ""
      });

      alert("A recept sikeresen el lett mentve.");
    } catch (e) {
      alert("Nem sikerült elmenteni a receptet.");
      console.error(e);
    } finally {
      setSaving(false);
    }
  }

  return (
    <main className="page">
      <div className="page-title">
        <p className="eyebrow">DOUGH CALCULATOR</p>

        <h1>Nápolyi pizzatészta kalkulátor</h1>

        <p>
          Az AVPN hivatalos 2024-es iránymutatásai alapján jelöljük
          a hidratáció és sótartalom elfogadott tartományát.
        </p>
      </div>

      <div className="calc-grid">
        <DoughForm
          onCalculate={calc}
          loading={loading}
        />

        <ResultPanel
          result={result}
          onSave={handleSave}
          saving={saving}
        />
      </div>
    </main>
  );
}
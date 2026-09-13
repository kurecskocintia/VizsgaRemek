import { useEffect, useState } from "react";
import { getRecipes, deleteRecipe } from "../api/recipeApi";

export default function RecipesPage() {
  const [recipes, setRecipes] = useState([]);
  const [loading, setLoading] = useState(true);

  async function loadRecipes() {
    try {
      const data = await getRecipes();
      setRecipes(data);
    } catch (e) {
      console.error(e);
      alert("Nem sikerült betölteni a recepteket.");
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    loadRecipes();
  }, []);

  async function handleDelete(id, name) {
    const confirmed = window.confirm(
      `Biztosan törölni szeretnéd a(z) "${name}" receptet?`
    );

    if (!confirmed) return;

    try {
      await deleteRecipe(id);

      // Azonnal eltávolítjuk a listából
      setRecipes(current =>
        current.filter(recipe => recipe.id !== id)
      );
    } catch (e) {
      console.error(e);
      alert("Nem sikerült törölni a receptet.");
    }
  }

  if (loading) {
    return (
      <main className="page">
        <div className="page-title">
          <p className="eyebrow">RECIPES</p>
          <h1>Mentett receptek</h1>
        </div>
        <div className="card">
          <p>Receptek betöltése...</p>
        </div>
      </main>
    );
  }

  return (
    <main className="page">
      <div className="page-title">
        <p className="eyebrow">RECIPES</p>
        <h1>Mentett receptek</h1>
        <p>
          Az elmentett pizzatészta-receptek teljes részletességgel.
        </p>
      </div>

      {recipes.length === 0 ? (
        <div className="card empty">
          <h2>Még nincs mentett recept</h2>
          <p>
            A kalkulátorban kiszámított recepteket itt tudod majd
            megtekinteni.
          </p>
        </div>
      ) : (
        <div className="recipe-grid">
          {recipes.map(recipe => (
            <article className="card recipe-card" key={recipe.id}>

              <div className="recipe-card-header">
                <div>
                  <p className="eyebrow">{recipe.yeastLabel}</p>
                  <h2>{recipe.name}</h2>
                </div>

                <button
                  className="delete-button"
                  onClick={() =>
                    handleDelete(recipe.id, recipe.name)
                  }
                  title="Recept törlése"
                >
                  🗑
                </button>
              </div>

              {recipe.description && (
                <p className="recipe-description">
                  {recipe.description}
                </p>
              )}

              <div className="recipe-summary">
                <div>
                  <span>Gombócok</span>
                  <strong>
                    {recipe.balls} × {recipe.ballWeight} g
                  </strong>
                </div>

                <div>
                  <span>Össztészta</span>
                  <strong>
                    {recipe.totalDoughWeight.toFixed(0)} g
                  </strong>
                </div>
              </div>

              <h3>Hozzávalók</h3>

              <div className="ingredients">
                <div>
                  <span>Liszt</span>
                  <b>{recipe.flourGrams.toFixed(1)} g</b>
                </div>

                <div>
                  <span>Víz</span>
                  <b>{recipe.waterGrams.toFixed(1)} g</b>
                </div>

                <div>
                  <span>Só</span>
                  <b>{recipe.saltGrams.toFixed(1)} g</b>
                </div>

                <div>
                  <span>{recipe.yeastLabel}</span>
                  <b>{recipe.yeastGrams.toFixed(2)} g</b>
                </div>
              </div>

              {recipe.sourdoughFlourGrams > 0 && (
                <div className="note">
                  <strong>Kovász:</strong>{" "}
                  {recipe.sourdoughFlourGrams.toFixed(1)} g liszt +{" "}
                  {recipe.sourdoughWaterGrams.toFixed(1)} g víz
                </div>
              )}

              <div className="recipe-meta">
                <span>
                  Hidratáció {recipe.hydration.toFixed(1)}%
                </span>

                <span>
                  Só {recipe.saltPercent.toFixed(1)}%
                </span>
              </div>

              <div className="fermentation">
                <h3>Fermentáció</h3>

                <p>
                  Szoba: {recipe.roomHours} óra /{" "}
                  {recipe.roomTemp} °C
                </p>

                <p>
                  Hűtő: {recipe.fridgeHours} óra /{" "}
                  {recipe.fridgeTemp} °C
                </p>

                <p>
                  <strong>
                    Összesen: {recipe.totalHours} óra
                  </strong>
                </p>
              </div>

            </article>
          ))}
        </div>
      )}
    </main>
  );
}
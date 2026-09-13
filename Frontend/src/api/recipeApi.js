import api from "./axios";

export async function getRecipes() {
  const { data } = await api.get("/recipes");
  return data;
}

export async function getRecipe(id) {
  const { data } = await api.get(`/recipes/${id}`);
  return data;
}

export async function saveRecipe(recipe) {
  const { data } = await api.post("/recipes", recipe);
  return data;
}

export async function deleteRecipe(id) {
  await api.delete(`/recipes/${id}`);
}
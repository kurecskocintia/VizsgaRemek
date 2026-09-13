import api from "./axios";
export async function calculateDough(payload) {
  const { data } = await api.post("/calculator", payload);
  return data;
}
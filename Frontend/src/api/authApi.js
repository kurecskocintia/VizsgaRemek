import api from "./axios";

export async function register(userName, email, password) {
  const { data } = await api.post("/auth/register", {
    userName,
    email,
    password
  });

  return data;
}

export async function login(email, password) {
  const { data } = await api.post("/auth/login", {
    email,
    password
  });

  localStorage.setItem("pizzaMaestroToken", data.token);
  localStorage.setItem(
    "pizzaMaestroUser",
    JSON.stringify(data.user)
  );

  return data.user;
}

export function logout() {
  localStorage.removeItem("pizzaMaestroToken");
  localStorage.removeItem("pizzaMaestroUser");
}

export function getCurrentUser() {
  const user = localStorage.getItem("pizzaMaestroUser");

  if (!user) {
    return null;
  }

  try {
    return JSON.parse(user);
  } catch {
    return null;
  }
}

export function isLoggedIn() {
  return !!localStorage.getItem("pizzaMaestroToken");
}
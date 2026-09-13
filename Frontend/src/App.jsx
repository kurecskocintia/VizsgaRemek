import { useState } from "react";

import Navbar from "./components/Navbar";
import HomePage from "./pages/HomePage";
import CalculatorPage from "./pages/CalculatorPage";
import RecipesPage from "./pages/RecipesPage";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";

import { getCurrentUser, logout } from "./api/authApi";

export default function App() {
  const [page, setPage] = useState("home");
  const [user, setUser] = useState(getCurrentUser());

  function handleLogin(user) {
    setUser(user);
  }

  function handleLogout() {
    logout();
    setUser(null);
    setPage("home");
  }

  return (
    <>
      <Navbar
        page={page}
        setPage={setPage}
        user={user}
        onLogout={handleLogout}
      />

      {page === "home" && (
        <HomePage go={setPage} />
      )}

      {page === "calculator" && (
        <CalculatorPage
          user={user}
          go={setPage}
        />
      )}

      {page === "recipes" && (
        <RecipesPage
          user={user}
          go={setPage}
        />
      )}

      {page === "login" && (
        <LoginPage
          onLogin={handleLogin}
          go={setPage}
        />
      )}

      {page === "register" && (
        <RegisterPage
          go={setPage}
        />
      )}

      <footer>
        Pizza Maestro · oktatási projekt · React + ASP.NET Core + MySQL
      </footer>
    </>
  );
}
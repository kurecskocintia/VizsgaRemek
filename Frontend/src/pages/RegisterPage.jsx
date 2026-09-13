import { useState } from "react";
import { register } from "../api/authApi";

export default function RegisterPage({ go }) {
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [passwordAgain, setPasswordAgain] = useState("");

  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const [loading, setLoading] = useState(false);

  async function handleSubmit(e) {
    e.preventDefault();

    setError("");
    setSuccess("");

    if (password !== passwordAgain) {
      setError("A két jelszó nem egyezik.");
      return;
    }

    if (password.length < 6) {
      setError("A jelszónak legalább 6 karakter hosszúnak kell lennie.");
      return;
    }

    setLoading(true);

    try {
      await register(userName, email, password);

      setSuccess(
        "Sikeres regisztráció! Most már bejelentkezhetsz."
      );

      setTimeout(() => {
        go("login");
      }, 1000);

    } catch (err) {
      setError(
        err.response?.data ||
        "Sikertelen regisztráció."
      );
    } finally {
      setLoading(false);
    }
  }

  return (
    <main className="page">
      <div className="page-title">
        <p className="eyebrow">ACCOUNT</p>
        <h1>Regisztráció</h1>
        <p>
          Hozd létre saját Pizza Maestro fiókodat.
        </p>
      </div>

      <div className="card auth-card">
        <form className="form" onSubmit={handleSubmit}>
          <label>
            Felhasználónév
            <input
              type="text"
              value={userName}
              onChange={e => setUserName(e.target.value)}
              required
              maxLength={100}
              autoComplete="username"
            />
          </label>

          <label>
            Email
            <input
              type="email"
              value={email}
              onChange={e => setEmail(e.target.value)}
              required
              autoComplete="email"
            />
          </label>

          <label>
            Jelszó
            <input
              type="password"
              value={password}
              onChange={e => setPassword(e.target.value)}
              required
              minLength={6}
              autoComplete="new-password"
            />
          </label>

          <label>
            Jelszó ismét
            <input
              type="password"
              value={passwordAgain}
              onChange={e => setPasswordAgain(e.target.value)}
              required
              autoComplete="new-password"
            />
          </label>

          {error && (
            <div className="auth-error">
              {error}
            </div>
          )}

          {success && (
            <div className="auth-success">
              {success}
            </div>
          )}

          <button
            className="primary"
            type="submit"
            disabled={loading}
          >
            {loading ? "Regisztráció..." : "Fiók létrehozása"}
          </button>
        </form>

        <p className="auth-switch">
          Már van fiókod?{" "}
          <button onClick={() => go("login")}>
            Bejelentkezés
          </button>
        </p>
      </div>
    </main>
  );
}
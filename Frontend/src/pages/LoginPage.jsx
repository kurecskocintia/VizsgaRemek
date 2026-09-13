import { useState } from "react";
import { login } from "../api/authApi";

export default function LoginPage({ onLogin, go }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);

  async function handleSubmit(e) {
    e.preventDefault();

    setError("");
    setLoading(true);

    try {
      const user = await login(email, password);

      onLogin(user);
      go("recipes");
    } catch (err) {
      setError(
        err.response?.data ||
        "Sikertelen bejelentkezés."
      );
    } finally {
      setLoading(false);
    }
  }

  return (
    <main className="page">
      <div className="page-title">
        <p className="eyebrow">ACCOUNT</p>
        <h1>Bejelentkezés</h1>
        <p>
          Jelentkezz be, hogy elérd és kezeld a saját receptjeidet.
        </p>
      </div>

      <div className="card auth-card">
        <form className="form" onSubmit={handleSubmit}>
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
              autoComplete="current-password"
            />
          </label>

          {error && (
            <div className="auth-error">
              {error}
            </div>
          )}

          <button
            className="primary"
            type="submit"
            disabled={loading}
          >
            {loading ? "Bejelentkezés..." : "Bejelentkezés"}
          </button>
        </form>

        <p className="auth-switch">
          Még nincs fiókod?{" "}
          <button onClick={() => go("register")}>
            Regisztráció
          </button>
        </p>
      </div>
    </main>
  );
}
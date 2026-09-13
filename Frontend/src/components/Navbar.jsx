export default function Navbar({
  page,
  setPage,
  user,
  onLogout
}) {
  return (
    <nav className="nav">
      <div className="nav-inner">

        <button
          className="brand"
          onClick={() => setPage("home")}
        >
          🍕 Pizza Maestro
        </button>

        <div className="nav-links">

          <button
            className={page === "home" ? "active" : ""}
            onClick={() => setPage("home")}
          >
            Főoldal
          </button>

          <button
            className={page === "calculator" ? "active" : ""}
            onClick={() => setPage("calculator")}
          >
            Kalkulátor
          </button>

          <button
            className={page === "recipes" ? "active" : ""}
            onClick={() => setPage("recipes")}
          >
            Receptek
          </button>

          {user ? (
            <>
              <span className="user-name">
                {user.userName}
              </span>

              <button onClick={onLogout}>
                Kilépés
              </button>
            </>
          ) : (
            <>
              <button
                className={page === "login" ? "active" : ""}
                onClick={() => setPage("login")}
              >
                Bejelentkezés
              </button>

              <button
                className={page === "register" ? "active" : ""}
                onClick={() => setPage("register")}
              >
                Regisztráció
              </button>
            </>
          )}

        </div>
      </div>
    </nav>
  );
}
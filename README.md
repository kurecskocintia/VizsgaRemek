# Pizza Maestro

Nápolyi pizzatészta-hozzávaló kalkulátor vizsgaprojekthez.

## Technológiák
- Frontend: React + Vite
- Backend: ASP.NET Core Web API (.NET 8)
- Adatbázis: MySQL + Entity Framework Core
- Dokumentáció: `docs/`

## Indítás

### Frontend
```powershell
cd Frontend
npm install
npm run dev
```

### Backend
A .NET 8 SDK és MySQL szükséges. Az `appsettings.json` connection stringjét állítsd be, majd:
```powershell
cd Backend/PuzzaMaestro.API
dotnet restore
dotnet run --urls "https://localhost:7000;http://localhost:5000"
```

Az API Swagger felülete: `https://localhost:7000/swagger`.

## Fontos
A kalkulátor élesztőmennyisége gyakorlati becslés, nem laboratóriumi fermentációs modell. Az AVPN-jelölés a hivatalos 2024-es szabályzatban szereplő, vízhez/liszthez viszonyított arányokból számított hidratációs és sótartományra épül.

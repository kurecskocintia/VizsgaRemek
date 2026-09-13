# Pizza Maestro – projekt- és felhasználói dokumentáció

## 1. Bevezetés
A Pizza Maestro egy reszponzív webalkalmazás, amely nápolyi pizzatészta tervezését segíti. A cél, hogy a felhasználó a kívánt tésztagombócok száma, tömege, hidratációja, sótartalma és fermentációs körülményei alapján gyorsan megkapja a szükséges alapanyag-mennyiségeket.

## 2. A feladat célja
A projekt külön frontend és backend részből áll. A frontend JavaScript-alapú React keretrendszert használ, a backend ASP.NET Core Web API, az adatokat pedig relációs MySQL adatbázis tárolja.

## 3. Célcsoport
Az alkalmazás kezdő és haladó otthoni pizzakészítők számára készült. Különösen hasznos lehet azoknak, akik változó darabszámmal, hidratációval vagy fermentációs idővel dolgoznak.

## 4. Fő funkciók
A felhasználó megadhatja a gombócok számát és tömegét, a hidratációt, a sót, az élesztő/kovász típusát, valamint a szobahőmérsékletű és hűtős fermentáció időtartamát és hőmérsékletét. Az alkalmazás kiszámítja a liszt, víz, só és élesztő/kovász mennyiségét.

## 5. AVPN háttér
Az AVPN 2024-es szabályzata 1 liter vízhez 40–60 g sót, friss sörélesztőből 0,1–3 g-ot, illetve a liszt mennyiségétől és körülményektől függő paramétereket ad meg. Az AVPN hidratációs ismertetője szerint a szabályzatban szereplő víz/liszt arány 1:1,8 és 1:1,6 között van, ami körülbelül 55–62% hidratáció. Ezeket az alkalmazás zöld/piros jelzéssel mutatja.

## 6. Hidratáció
A hidratáció képlete: víz gramm / liszt gramm × 100. A kalkulátor a beállított hidratáció alapján osztja szét a teljes tésztatömeget lisztre és vízre.

## 7. Só
A só százalékos értéke a liszt tömegéhez viszonyított baker's percentage. A felület 2,5–3,75%-ot tekint zöld tartománynak, amely megfelel a 40–60 g só / liter víz AVPN-tartományának a 55–62%-os hidratációs sávban.

## 8. Friss élesztő
A friss élesztő mennyisége a fermentációs idő és hőmérséklet alapján becslés. Hosszabb és melegebb fermentációhoz kevesebb élesztő szükséges.

## 9. Szárított élesztő
A kalkulátor a friss élesztő becsült mennyiségét 3-mal osztja, összhangban az AVPN friss/szárított 1:3 arányú átváltásával.

## 10. Folyékony kovász
A li.co.li. vízből és lisztből álló természetes kovász. Az alkalmazás a kovász liszt- és víztartalmát külön is kezeli, hogy ne duplázza meg ezeket a teljes receptben.

## 11. Lievito madre
A lievito madre szilárdabb természetes kovász. A kalkulátor külön prefermentként kezeli, és a kovászban lévő lisztet és vizet levonja a fő tésztából.

## 12. Fermentációs modell
A modell külön kezeli a szobahőmérsékletű és a hűtős időt. A hűtős idő csökkentett fermentációs súllyal szerepel az élesztő becslésében. Ez nem helyettesíti a saját élesztő/kovász aktivitásának megfigyelését.

## 13. Frontend
A frontend React komponensekből épül fel. Az `App.jsx` kezeli a fő oldalváltást, a komponensek pedig külön felelősségeket kapnak. A `DoughForm` a bemenetekért, a `ResultPanel` az eredményekért felel.

## 14. API kommunikáció
Az Axios kliens az ASP.NET Core API-t hívja. A kalkuláció POST kéréssel történik az `/api/calculator` végpontra. A receptek GET kéréssel érhetők el az `/api/recipes` végponton.

## 15. Backend
A backend ASP.NET Core Web API. A kontrollerek fogadják a HTTP kéréseket, a szolgáltatás végzi a kalkulációt, az Entity Framework Core pedig az adatbázis elérését biztosítja.

## 16. Adatmodell
A projektben a `Recipe` entitás reprezentálja az adatbázisban tárolt receptet. A tábla azonosítót, nevet, fermentációs típust, hidratációt, sótartalmat és leírást tartalmaz.

## 17. Adatbázis
MySQL relációs adatbázis használható. Az Entity Framework Core Code First megközelítéssel kezeli az entitást. A kezdeti receptek seed adatokként kerülnek definiálásra.

## 18. Reszponzivitás
A CSS media query-k segítségével a kétoszlopos elrendezés kis képernyőn egyoszlopossá válik. A navigáció, űrlapok és eredménypanelek mobil kijelzőn is használhatók.

## 19. Hibakezelés
Ha az API nem érhető el, a frontend felhasználói üzenetet jelenít meg. A backend hibás alapparaméterek esetén HTTP 400 választ ad.

## 20. Biztonság
A fejlesztői CORS beállítás jelenleg minden originről engedélyez kéréseket. Éles rendszerben ezt a frontend konkrét domainjére kell korlátozni. A connection stringben szereplő jelszót GitHubra feltölteni nem szabad.

## 21. Telepítés
A frontendhez Node.js, a backendhez .NET 8 SDK, az adatbázishoz MySQL szükséges. A frontend `npm install` és `npm run dev`, a backend `dotnet restore` és `dotnet run` parancsokkal indítható.

## 22. Tesztelési terv
Tesztelni kell a minimális és maximális gombócszámot, a különböző hidratációkat, sótartalmakat, élesztőtípusokat, nulla hűtési időt, hosszú hűtést, valamint az API elérhetetlenségét.

## 23. Felhasználói útmutató
A felhasználó megnyitja a Kalkulátor oldalt, megadja a recept paramétereit, kiválasztja a fermentáció típusát, majd a Recept kiszámítása gombot használja. Az eredménypanelen megjelennek a hozzávalók és az AVPN-jelzések.

## 24. GitHub leadás
A projekt gyökerét Git repositoryként kell kezelni. A `node_modules`, build outputok és titkos konfigurációk kerüljenek `.gitignore` alá. A dokumentáció a repository `docs` könyvtárában található.

## 25. Összegzés
A Pizza Maestro teljes webes alkalmazásként demonstrálja a frontend, backend és relációs adatbázis együttműködését. A projekt továbbfejleszthető autentikációval, receptszerkesztéssel, felhasználói profilokkal, pontosabb fermentációs modellel és többnyelvű felülettel.

## Forrásjegyzék
- Associazione Verace Pizza Napoletana: Il Disciplinare, 2024.
- Associazione Verace Pizza Napoletana: L'idratazione negli impasti.
- Associazione Verace Pizza Napoletana: I lieviti in pizzeria.
- React dokumentáció.
- Vite dokumentáció.
- ASP.NET Core dokumentáció.
- Entity Framework Core dokumentáció.
- MySQL dokumentáció.

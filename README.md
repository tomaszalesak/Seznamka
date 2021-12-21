# FI-PV179

Seznamka : .NET 6 Web API, SPA klient v Reactu a TypeScriptu

## Sample video

https://drive.google.com/file/d/1miF-keIvC7s4PoRnp8fzsU3qUAo-J2IQ/view?usp=sharing

## Zadání

Projektom bude implementovať webovú aplikáciu, systém na zoznamovanie ľudí online. Systém bude umožňovať užívateľovi vytvoriť si profil, na ktorý sa bude prihlasovať - spôsob prihlasovania je ponechaný na vás. Pri vytváraní profilu užívateľ vyplní rôzne údaje o sebe na základe ktorých sa dajú následne filtrovať. Užívateľ bude schopný zobraziť si ostatných užívateľov a zároveň medzi nimi bude vedieť filtrovať, parametre filtrovania ponecháme na vás (napríklad vzdialenosť, pohlavie, váha, etc.) Výhodou bude ak implementujete možnosť skryť vlastný profil pred užívateľmi, ktorí nevyhovujú ich požiadavkám. Po nadviazaní kontaktu s iným užívateľom si môžu užívatelia navzájom vymieňať správy - Realtime chat, za pomoci SignalR. Užívateľ bude vedieť zablokovať iných užívateľov, ktorí sa mu následne nebudú zobrazovať. Všetko ostatné je ponechané na vás a vašej kretivite.

## How to

- prerequisities are .NET 6 (VS 2022), SQL Server and NodeJS
- add migrations `dotnet ef migrations add "InitialMigration" --project src\Infrastructure --startup-project src\WebAPI --output-dir Persistence\Migrations`
- database created automatically during migration, database connection string is managed in appsettings.json
- start WebApi project in solution and go to `src/WebClient` and run `yarn` and `yarn start` for local development
- API swagger interface will run on `https://localhost:7298/swagger/index.html` and frontend on `http://localhost:3000/`

## Autoři

- Tomáš Zálešák, UČO 506475
- Jan Sladký, UČO 506465
- Marek Laššák, UČO 485289

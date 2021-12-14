# FI-PV179

Seznamka : .NET 6 Web API, SPA klient v Reactu a TypeScriptu

## Zadání

Projektom bude implementovať webovú aplikáciu, systém na zoznamovanie ľudí online. Systém bude umožňovať užívateľovi vytvoriť si profil, na ktorý sa bude prihlasovať - spôsob prihlasovania je ponechaný na vás. Pri vytváraní profilu užívateľ vyplní rôzne údaje o sebe na základe ktorých sa dajú následne filtrovať. Užívateľ bude schopný zobraziť si ostatných užívateľov a zároveň medzi nimi bude vedieť filtrovať, parametre filtrovania ponecháme na vás (napríklad vzdialenosť, pohlavie, váha, etc.) Výhodou bude ak implementujete možnosť skryť vlastný profil pred užívateľmi, ktorí nevyhovujú ich požiadavkám. Po nadviazaní kontaktu s iným užívateľom si môžu užívatelia navzájom vymieňať správy - Realtime chat, za pomoci SignalR. Užívateľ bude vedieť zablokovať iných užívateľov, ktorí sa mu následne nebudú zobrazovať. Všetko ostatné je ponechané na vás a vašej kretivite.

## How to

- add migrations `dotnet ef migrations add "InitialMigration" --project src\Infrastructure --startup-project src\WebAPI --output-dir Persistence\Migrations`
- database updated automatically

## Autoři

- Tomáš Zálešák, UČO 506475
- Jan Sladký, UČO 506465
- Marek Laššák, UČO 485289

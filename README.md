# Ruvvean.Library

Narzędziowa biblioteka .NET od **Ruvvean** – lekka, prosta w użyciu i gotowa do dystrybucji przez **GitHub Packages (NuGet)**.

![Ruvvean Library](assets/icon.png)

---

## Spis treści

- [Wymagania](#wymagania)
- [Instalacja](#instalacja)
  - [GitHub Packages: konfiguracja źródła](#github-packages-konfiguracja-źródła)
  - [Instalacja pakietu](#instalacja-pakietu)
- [Szybki start](#szybki-start)
- [API](#api)
- [Wydawanie nowej wersji](#wydawanie-nowej-wersji)
  - [Automatyczna publikacja (GitHub Actions)](#automatyczna-publikacja-github-actions)
  - [Ręczna publikacja lokalna](#ręczna-publikacja-lokalna)
- [Dobre praktyki wersjonowania](#dobre-praktyki-wersjonowania)
- [Rozwiązywanie problemów](#rozwiązywanie-problemów)
- [Wsparcie i kontakt](#wsparcie-i-kontakt)
- [Licencja](#licencja)

---

## Wymagania

- .NET SDK **8.0** lub nowszy
- Konto GitHub z dostępem do **GitHub Packages**
- (Opcjonalnie do publikacji lokalnej) **Personal Access Token (PAT)** z uprawnieniami: `write:packages`, `read:packages`

## Instalacja

### GitHub Packages: konfiguracja źródła

Utwórz/uzupełnij plik `nuget.config` w katalogu repozytorium lub w profilu użytkownika:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <!-- Zastąp OWNER nazwą konta/organizacji GitHub -->
    <add key="github" value="https://nuget.pkg.github.com/OWNER/index.json" />
    <add key="nuget" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

Jeśli instalujesz pakiety lokalnie poza CI, dodaj źródło z PAT (jednorazowo):

```bash
dotnet nuget add source https://nuget.pkg.github.com/OWNER/index.json   --name github --username OWNER --password YOUR_GITHUB_PAT --store-password-in-clear-text
```

### Instalacja pakietu

```bash
dotnet add package Ruvvean.Library --source "github"
```

## Szybki start

```csharp
using Ruvvean.Library;

Console.WriteLine(Greeter.Hello("World"));
// => Hello, World! — from Ruvvean.Library
```

## API

### `Greeter.Hello(string name) : string`

Zwraca powitanie zawierające przekazaną nazwę.

- **Parametry**: `name` – tekst do wstawienia w powitaniu.
- **Zwraca**: sformatowany łańcuch powitalny.

> Własne typy i funkcje dodawaj w folderze `src/Ruvvean.Library/`, pamiętając o aktualizacji dokumentacji XML (///) i changeloga.

## Wydawanie nowej wersji

Zalecamy semantyczne wersjonowanie: `MAJOR.MINOR.PATCH`.

1. Upewnij się, że `PackageId`, `Authors`, `Company`, `RepositoryUrl` są poprawne w `Ruvvean.Library.csproj`.
2. Zaktualizuj numer wersji albo użyj tagów Git (preferowane).
3. Wydaj tag:
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

### Automatyczna publikacja (GitHub Actions)

Workflow `publish.yml` pakuje i publikuje paczkę na **GitHub Packages** po wypchnięciu taga `v*.*.*`. Używa wbudowanego `GITHUB_TOKEN` (wystarczy, gdy publikujesz do paczek w tym samym repozytorium).

### Ręczna publikacja lokalna

Spakuj i wypchnij paczkę z lokalnego środowiska:

```bash
dotnet pack ./src/Ruvvean.Library/Ruvvean.Library.csproj -c Release -o ./artifacts
dotnet nuget push ./artifacts/*.nupkg --source "github" --skip-duplicate
```

Jeśli nie masz jeszcze skonfigurowanego źródła z tokenem:

```bash
dotnet nuget add source https://nuget.pkg.github.com/OWNER/index.json   --name github --username OWNER --password YOUR_GITHUB_PAT --store-password-in-clear-text
```

## Dobre praktyki wersjonowania

- **MAJOR** – zmiany niekompatybilne (breaking changes).
- **MINOR** – nowe funkcje zachowujące kompatybilność.
- **PATCH** – poprawki błędów i drobne usprawnienia.
- Oznaczaj releasy tagami `vX.Y.Z`, changelog prowadź w `CHANGELOG.md` (opcjonalnie).

## Rozwiązywanie problemów

- **401/403 przy instalacji** – sprawdź ważność PAT oraz czy ma `read:packages` (i `write:packages` przy publikacji).
- **404 nie znajduje pakietu** – upewnij się, że źródło `github` wskazuje właściwego `OWNER` i że używasz poprawnego `PackageId`.
- **Ikona/README nie wyświetla się** – sprawdź wpisy w `.csproj`: `PackageReadmeFile`, `PackageIcon` oraz czy pliki są pakowane (`<None ... Pack="true" ...>`).

## Wsparcie i kontakt

Problemy i pomysły: zakładka **Issues** w repozytorium GitHub.  
W sprawach biznesowych: skontaktuj się z zespołem **Ruvvean**.

## Licencja

Projekt jest objęty licencją **MIT**. Szczegóły w pliku `LICENSE`.

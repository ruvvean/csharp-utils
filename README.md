# Ruvvean.Library

A .NET utility library by **Ruvvean** – lightweight, easy to use, and ready for distribution via **GitHub Packages (NuGet)**.


<img src="assets/icon_nuget.png" alt="Ruvvean Library" width="60" height="60" />

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
  - [GitHub Packages: Source Configuration](#github-packages-source-configuration)
  - [Package Installation](#package-installation)
- [Quick Start](#quick-start)
- [Releasing a New Version](#releasing-a-new-version)
  - [Automatic Publishing (GitHub Actions)](#automatic-publishing-github-actions)
  - [Manual Local Publishing](#manual-local-publishing)
- [Versioning Best Practices](#versioning-best-practices)
- [Troubleshooting](#troubleshooting)
- [Support & Contact](#support--contact)
- [License](#license)

---

## Requirements

- .NET SDK **9.0** or newer
- GitHub account with access to **GitHub Packages**
- (Optional for local publishing) **Personal Access Token (PAT)** with permissions: `write:packages`, `read:packages`

## Installation

### GitHub Packages: Source Configuration

Create or update the `nuget.config` file in your repository directory or user profile:
If installing packages locally outside CI, add the source with PAT (one-time):
### Package Installation
## Quick Start

## Releasing a New Version

Semantic versioning is recommended: `MAJOR.MINOR.PATCH`.

1. Ensure `PackageId`, `Authors`, `Company`, `RepositoryUrl` are correct in `Ruvvean.Library.csproj`.
2. Update the version number or use Git tags (preferred).
3. Release a tag:
### Automatic Publishing (GitHub Actions)

The `publish.yml` workflow packs and publishes the package to **GitHub Packages** after pushing a `v*.*.*` tag. It uses the built-in `GITHUB_TOKEN` (sufficient when publishing to packages in the same repository).

### Manual Local Publishing

Pack and push the package from your local environment:
If you haven't configured the source with a token yet:
## Versioning Best Practices

- **MAJOR** – breaking changes.
- **MINOR** – new features, backward compatible.
- **PATCH** – bug fixes and minor improvements.
- Tag releases as `vX.Y.Z`, maintain a changelog in `CHANGELOG.md` (optional).

## Troubleshooting

- **401/403 on installation** – check PAT validity and ensure it has `read:packages` (and `write:packages` for publishing).
- **404 package not found** – ensure the `github` source points to the correct `ruvvean` and you use the correct `PackageId`.
- **Icon/README not displayed** – check `.csproj` entries: `PackageReadmeFile`, `PackageIcon`, and that files are packed (`<None ... Pack="true" ...>`).

## Support & Contact

Issues and ideas: **Issues** tab in the GitHub repository.  
For business inquiries: contact the **Ruvvean** team.

## License

This project is licensed under the **MIT** license. See the `LICENSE` file for details.

# InstaAPI


Ce projet est un mini système de gestion de produits, fait en **.NET** avec deux parties :

- **InstawebAPI** : l’API (backend) qui gère les produits (CRUD + stock).
- **ClientAPI** : l’application MVC (frontend serveur) qui consomme l’API.

L’objectif est simple : créer, modifier, supprimer des produits, et gérer leur stock (ajouter / retirer) depuis l’interface.

---

## 1) Ce que fait le projet

### Côté API (`InstawebAPI`)
- Créer un produit
- Lister les produits
- Lire un produit par ID
- Modifier un produit
- Supprimer un produit
- Ajouter du stock
- Retirer du stock

### Côté Client (`ClientAPI`)
- Afficher la liste des produits
- Aller sur la page **Détails** d’un produit
- Ajouter / retirer du stock depuis les boutons de la page Détails
- Modifier et supprimer un produit

---

## 2) Stack technique

- **ASP.NET Core Web API** (backend)
- **ASP.NET Core MVC** (client)
- **Entity Framework Core** (accès base de données)
- **SQL Server LocalDB** (configuration de base)

---

## 3) Structure du repo

```text
InstaAPI.sln
├── InstawebAPI/      # API REST
├── ClientAPI/        # Client MVC
└── README.md
```

---

## 4) Routes principales API

Base URL API (en local) : `https://localhost:7169/`

> Les ports peuvent changer selon votre `launchSettings.json`.

### Produits
- `GET /api/produit` → liste des produits
- `GET /api/produit/{id}` → détail d’un produit
- `POST /api/produit` → créer un produit
- `PUT /api/produit/{id}` → modifier un produit
- `DELETE /api/produit/{id}` → supprimer un produit

### Utilisateurs
- `GET /api/user` → liste des utilisateurs
- `POST /api/user` → créer un utilisateur client
- `PUT /api/user/{id}` → mettre à jour un utilisateur admin

---

## 5) Lancer le projet en local

## Prérequis
- .NET SDK (version compatible .NET du projet)
- SQL Server LocalDB (ou adapter la connexion DB)

### Étapes
1. Cloner le repo
2. Ouvrir le dossier dans votre IDE (Visual Studio / VS Code)
3. Vérifier les chaînes de connexion dans :
   - `InstawebAPI/appsettings.json`
   - `ClientAPI/appsettings.json`
4. Appliquer les migrations (si nécessaire)
5. Lancer **InstawebAPI**
6. Lancer **ClientAPI**
7. Ouvrir l’URL du client dans le navigateur

---


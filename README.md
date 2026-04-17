# InstaAPI

Bienvenue 👋

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

### Stock
- `POST /api/produit/{id}/ajouter-stock?quantite=5`
- `POST /api/produit/{id}/retirer-stock?quantite=2`

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

## 6) Exemple de flux utilisateur

1. Je crée un produit (nom, prix, stock)
2. Je vais dans **Détails du produit**
3. Je tape une quantité dans :
   - “Quantité à ajouter” puis bouton **Ajouter**
   - ou “Quantité à retirer” puis bouton **Retirer**
4. Le stock est mis à jour
5. Si la quantité est invalide (ex: négative, ou retrait > stock), un message d’erreur s’affiche

---

## 7) Notes importantes (style débutant)

- Le code est volontairement écrit de façon lisible et directe.
- La logique métier de stock est dans le modèle/service (ex: stock insuffisant).
- Le client MVC appelle l’API via `HttpClient`.
- Les erreurs de stock sont renvoyées simplement et affichées côté client.

---

## 8) Idées d’amélioration

- Ajouter des tests unitaires et d’intégration
- Ajouter une validation plus claire des champs côté vue
- Ajouter une authentification plus complète (JWT + rôles)
- Améliorer les messages utilisateur (succès/erreur)

---

## 9) Merci

Projet pédagogique 💙

Si vous êtes débutant(e), prenez le temps de lire chaque couche dans cet ordre :
1. `Models`
2. `Services`
3. `Controllers`
4. `Views`

C’est la meilleure manière de comprendre calmement tout le flux.

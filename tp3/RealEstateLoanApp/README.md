
# Readme - Simulateur de Crédit Immobilier en C#

Ce projet est un simulateur de crédit immobilier écrit en C# qui calcule le coût total de l'emprunt (emprunt + intérêts) et les mensualités, puis génère un fichier CSV en sortie. Voici un guide pour comprendre et utiliser ce projet.

## 1. Execution

Pour exécuter le code, utilisez la commande suivante dans votre terminal après vous être placé dans le répertoire racine du projet :

```bash
dotnet run [(int) loanAmount] [(int) duration] [(double) nominalRate]
```

Assurez-vous de remplacer `loanAmount`, `duration` et `nominalRate` par les valeurs appropriées pour votre simulation de crédit immobilier.

## 2. Tests

Ce projet suit une approche de développement piloté par les tests (TDD) avec l'utilisation de XUnit pour les tests unitaires. Chaque classe a son propre fichier de tests, par exemple `ConstantAmortizationTests.cs`. Les données de test sont fournies dynamiquement en utilisant des `InlineData` avec `Theory`. Chaque fonction de test vérifie un point spécifique du code, par exemple `DurationIsBetweenMinAndMaxTest()` qui vérifie si la durée de l'emprunt est entre 9 et 25 ans.

Pour exécuter les tests, utilisez la commande suivante dans votre terminal après vous être placé dans le répertoire racine du projet :

```bash
dotnet test
```

## 3. Bonnes pratiques de codage

Ce projet est conçu en suivant les bonnes pratiques de codage, notamment :

- **Design Pattern Strategy**: Le code utilise le design pattern Strategy pour pouvoir gérer les différents types d'amortissement (constant, linéaire, in fine...) et gérer les différentes générations de fichiers possibles (CSV, PDF, TXT...). Bien que seuls l'amortissement constant et la génération de fichiers CSV soient implémentés pour le moment, cette structure permet une évolutivité et une modularité accrues.
  
- **Respect des principes SOLID**: Le code respecte les principes SOLID, notamment le principe de responsabilité unique (Single Responsibility Principle) en séparant les différentes fonctionnalités dans des classes distinctes. Par exemple, la fonction `CalculateMonthlyPayment()` est responsable uniquement du calcul du paiement mensuel. De plus, le principe d'injection de dépendances (Dependency Injection Principle) est utilisé dans différentes classes, et le principe d'ouverture/fermeture (Open/Closed Principle) est respecté grâce à l'application du design pattern Strategy.

- **Interfaces et Convention de Nommage**: Le code utilise des interfaces pour définir les contrats entre les différentes parties du système, favorisant ainsi la flexibilité et l'extensibilité du code. Enfin, une convention de nommage cohérente est suivie, utilisant Upper Camel Case pour les méthodes et Lower Camel Case pour les variables.
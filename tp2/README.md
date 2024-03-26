# Séance 2 T&V : Reprise d’un projet Legacy

## I. Les difficultés liées à la validation

Le logiciel, bien que fonctionnel dans l’ensemble, contient plusieurs freins à sa validation. Des tests d’acceptation ont donc d’abord été réalisés et des bugs ont été relevés :
- Au niveau du jeu Morpion :
  - Quand on choisit une case, le pion du joueur est inséré simultanément à deux endroits au lieu d’un seul endroit (celui que l’on a choisi).
  - Le jeu ne s’arrête pas lorsqu’il y a égalité.
  - Il est possible d’écrire directement la lettre X dans une case alors qu’il ne devrait avoir que la touche [Entrer] autorisée.
- Au niveau du jeu Puissance 4 :
  - Il n’est parfois pas possible de mettre un pion dans la dernière colonne. Lorsque cela est possible, 3 pions sont insérés simultanément au lieu d’un seul.
  - Lorsque 4 pions du même joueur se suivent dans une colonne, la victoire ne marche pas toujours.

Concernant le design, le prestataire a scindé le logiciel en 3 fichiers :
- Program.cs : Point d’entrée du programme
- Morpion.cs : Fonctionnalités du jeu Morpion.
- PuissanceQuatre.cs : Fonctionnalités du jeu PuissanceQuatre.

À première vue, le programme contient plusieurs répétitions de code, violant le principe DRY (Don’t Repeat Yourself). Par exemple, dans Program.cs, la fonction Main() contient deux switch alors qu’un seul pourrait suffire. Dans Morpion.cs et PuissanceQuatre.cs, les fonctions tourJoueur() et tourJoueur2() font sensiblement la même chose et pourraient être réunies en une seule.

On observe aussi une violation du principe SOLID SP (Single Responsability) car les classes Morpion et PuissanceQuatre se retrouvent à faire l’initialisation des grilles, l’affichage, la gestion des tours, la logique de jeu, et ainsi de suite. Pour les méthodes, c’est la même histoire : la méthode BoucleJeu() gère à la fois les sorties console et la gestion des tours. Egalement, la méthode verifVictoire() n’est pas scindée en plusieurs petites méthodes qui traiteraient chacune d’un aspect de la vérification (vérification par ligne, par colonne et en diagonale). La méthode est donc très difficilement compréhensible.

```cs
public bool verifVictoire(char c) =>
     grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c && grille[3, 0] == c ||
     grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c && grille[3, 1] == c ||
     grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c && grille[3, 2] == c ||
     grille[0, 3] == c && grille[1, 3] == c && grille[2, 3] == c && grille[3, 3] == c ||
     grille[0, 4] == c && grille[1, 4] == c && grille[2, 4] == c && grille[3, 4] == c ||
     grille[0, 5] == c && grille[1, 5] == c && grille[2, 5] == c && grille[3, 5] == c ||
     grille[0, 6] == c && grille[1, 6] == c && grille[2, 6] == c && grille[3, 6] == c ||
     grille[0, 0] == c && grille[0, 1] == c && grille[0, 2] == c && grille[0, 3] == c ||
     grille[0, 1] == c && grille[0, 2] == c && grille[0, 3] == c && grille[0, 4] == c ||
     grille[0, 2] == c && grille[0, 3] == c && grille[0, 3] == c && grille[0, 5] == c ||
     grille[0, 3] == c && grille[0, 4] == c && grille[0, 5] == c && grille[0, 6] == c ||
     grille[1, 0] == c && grille[1, 1] == c && grille[1, 2] == c && grille[1, 3] == c ||
     grille[1, 1] == c && grille[1, 2] == c && grille[1, 3] == c && grille[1, 4] == c ||
     grille[1, 2] == c && grille[1, 3] == c && grille[1, 4] == c && grille[1, 5] == c ||
     grille[1, 4] == c && grille[1, 4] == c && grille[1, 5] == c && grille[1, 6] == c ||
     grille[2, 0] == c && grille[2, 1] == c && grille[2, 2] == c && grille[2, 3] == c ||
     grille[2, 1] == c && grille[2, 2] == c && grille[2, 3] == c && grille[2, 4] == c ||
     grille[2, 2] == c && grille[2, 3] == c && grille[2, 3] == c && grille[2, 5] == c ||
     grille[2, 3] == c && grille[2, 4] == c && grille[2, 5] == c && grille[2, 6] == c ||
     grille[3, 0] == c && grille[3, 1] == c && grille[3, 2] == c && grille[3, 3] == c ||
     grille[3, 1] == c && grille[3, 2] == c && grille[3, 3] == c && grille[3, 4] == c ||
     grille[3, 2] == c && grille[3, 3] == c && grille[3, 4] == c && grille[3, 5] == c ||
     grille[3, 3] == c && grille[3, 4] == c && grille[3, 5] == c && grille[3, 6] == c ||
     grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c && grille[3, 3] == c ||
     grille[0, 1] == c && grille[1, 2] == c && grille[2, 3] == c && grille[3, 4] == c ||
     grille[0, 2] == c && grille[1, 3] == c && grille[2, 4] == c && grille[3, 5] == c ||
     grille[0, 3] == c && grille[1, 4] == c && grille[2, 5] == c && grille[3, 6] == c ||
     grille[0, 3] == c && grille[1, 2] == c && grille[2, 1] == c && grille[3, 0] == c ||
     grille[0, 4] == c && grille[1, 4] == c && grille[2, 2] == c && grille[3, 1] == c ||
     grille[0, 5] == c && grille[1, 3] == c && grille[2, 3] == c && grille[3, 2] == c ||
     grille[0, 6] == c && grille[1, 5] == c && grille[2, 4] == c && grille[3, 3] == c;
```

Un autre principe SOLID qui est violé est celui du Open/Closed. Le code prend actuellement en charge les jeux Morpion et Puissance Quatre, l'introduction d'un nouveau jeu nécessiterait de modifier la classe Program pour inclure une nouvelle branche dans la logique de sélection du jeu. Il serait préférable d'avoir une classe abstraite Jeu et des implémentations concrètes distinctes pour Morpion et Puissance Quatre. Cela permet d'ajouter de nouveaux jeux sans modifier le code existant.

Enfin, le code est en « franglais », devant plutôt être monolingue pour une meilleure compréhension. De plus, il manque des commentaires pour expliquer le fonctionnement d’une méthode ou d’une condition particulière et il y a du « dead code » dans tourJoueur() et tourJoueur2(), code inutilisé et devant être supprimé.

```cs
case ConsoleKey.LeftArrow:
    if (column <= 0)
    {
        column = 6;
    }
    else
    {
        column = column - 1;
    }
    break;

//case ConsoleKey.UpArrow:
//    if (row <= 0)
//    {
//        row = 3;
//    }
//    else
//    {
//        row = row - 1;
//    }
//    break;

//case ConsoleKey.DownArrow:
//    if (row >= 3)
//    {
//        row = 0;
//    }
//    else
//    {
//        row = row + 1;
//    }
//    break;
...
```

Autre point, une complexité cyclomatique élevée du programme à certains endroits du code avec de nombreuses conditions imbriquées.

```cs
while (!quiterJeu)
{
    grille = new char[4, 7]
    {
        { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
    };
    while (!quiterJeu)
    {
        if (tourDuJoueur)
        {
            tourJoueur();
            if (verifVictoire('X'))
            {
                finPartie("Le joueur 1 à gagné !");
                break;
            }
        }
        else
        {
            tourJoueur2();
            if (verifVictoire('O'))
            {
                finPartie("Le joueur 2 à gagné !");
                break;
            }
        }
        tourDuJoueur = !tourDuJoueur;
        if (verifEgalite())
        {
            finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
            break;
        }
    }
    ...
}
```

Enfin, on pourrait noter l’absence d’implémentation de la gestion des erreurs pour les entrées utilisateur.

## II. Les méthodes de résolution de ces problèmes

Dans la première partie, nous avons discuté des problématiques du logiciel qui étaient un frein à sa validation. Dans cette deuxième partie, nous allons mettre en place les différentes actions permettant de valider l’existant. Cela passera par la refactorisation du code et le testing :
- 1ère étape : Revoir le code Morpion.cs et PuissanceQuatre.cs en créant des plus petites fonctions afin de respecter le principe Single Responsability et faire du debugging au passage.
- 2ème étape : Le code étant revu, le diviser en créant plusieurs classes et interfaces :
  - Créer une classe abstraite Jeu qui va définir les fonctionnalités de base d’un jeu. Les règles spécifiques seront implémentées dans les classes enfants Morpion et PuissanceQuatre.
  - Créer une interface SortieJeu qui va définir les méthodes d'affichage d’un jeu. Pour l’instant, seule la classe SortieConsole, gérant les sorties en mode console, implémentera cette interface. Plus tard, nous pourrions implémenter une nouvelle classe SortieUI pour les sorties en mode interface graphique.
  - Créer une classe Joueur qui va définir les comportements et attributs d’un joueur (qu’il soit un robot ou un humain).
- 3ème étape : Revoir la méthode Main qui va instancier un jeu (Morpion ou Puissance 4), instancier l'interface d'affichage (uniquement SortieConsole pour le moment) et démarrer la boucle du jeu.
- 4ème étape : Faire des tests unitaires du refactoring avec XUnit.

Les avantages d’une telle architecture sont multiples :
- Flexibilité et modularité : Permet de facilement ajouter de nouveaux jeux en héritant de la classe abstraite Jeu.
- Réutilisabilité : La classe SortieConsole peut être réutilisée pour d'autres jeux.
- Testabilité : Facilite l'écriture de tests unitaires pour chaque module.

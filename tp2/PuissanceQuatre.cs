using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class PuissanceQuatre : Jeu
    {
        public PuissanceQuatre()
        {
            grille = new char[4, 7];
        }

        public void InitialiserGrille()
        {
            grille = new char[4, 7]
            {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };
        }

        public void AfficherPlateau()
        {
            Console.WriteLine();
            Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}  |  {grille[0, 3]}  |  {grille[0, 4]}  |  {grille[0, 5]}  |  {grille[0, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}  |  {grille[1, 3]}  |  {grille[1, 4]}  |  {grille[1, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[2, 0]}  |  {grille[2, 1]}  |  {grille[2, 2]}  |  {grille[2, 3]}  |  {grille[2, 4]}  |  {grille[2, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[3, 0]}  |  {grille[3, 1]}  |  {grille[3, 2]}  |  {grille[3, 3]}  |  {grille[3, 4]}  |  {grille[3, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
        }

        public void AfficherGagnant()
        {
            int numeroJoueur = tourDuJoueur ? 1 : 2;
            Console.WriteLine("Le joueur " + numeroJoueur.ToString() + " a gagné !");
        }

        public void AfficherEgalite()
        {
            Console.WriteLine("Egalité !");
        }
        public void AfficherMessageChoixCaseVide()
        {
            Console.WriteLine("Choisir une case vide et appuyer sur [Entrer]");
        }

        public void AfficherMessageErreurTouche()
        {
            Console.WriteLine("Appuyer sur une touche valide.");
        }

        public void AfficherMessageFinPartie()
        {
            Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
        }

        public void BoucleJeu()
        {
            while (!quitterJeu)
            {
                InitialiserGrille();

                while (!quitterJeu)
                {
                    TourJoueur();
                    if (VerifierVictoire())
                    {
                        FinPartie(true);
                        break;
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (VerifierEgalite())
                    {
                        FinPartie();
                        break;
                    }
                }
                if (!quitterJeu)
                {
                    ChoixFinPartie();
                }
            }
        }

        public override void ChoixFinPartie()
        {
            AfficherMessageFinPartie();
            GetKey:
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    Console.Clear();
                    BoucleJeu();
                    break;
                case ConsoleKey.Escape:
                    quitterJeu = true;
                    Console.Clear();
                    break;
                default:
                    goto GetKey;
            }
        }


        public void TourJoueur()
        {
            var (row, column) = (0, 0);
            tourEstJoue = false;

            while (!quitterJeu && !tourEstJoue)
            {
                Console.Clear();
                AfficherPlateau();
                Console.WriteLine();
                AfficherMessageChoixCaseVide();
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

                System.ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        (row, column) = DeplacerCurseur(row, column, key);
                        break;
                    case ConsoleKey.Enter:
                        PlacerPion(row, column);
                        break;
                    case ConsoleKey.Escape:
                        TerminerJeu();
                        break;
                    default:
                        AfficherMessageErreurTouche();
                        break;
                }
            }
        }

        public override (int, int) DeplacerCurseur(int row, int column, System.ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    if (column >= 6)
                    {
                        column = 0;
                    }
                    else
                    {
                        column = column + 1;
                    }
                    break;
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
            }

            return (row, column);
        }
        public override char ObtenirPion()
        {
            return tourDuJoueur ? 'X' : 'O';
        }


        public override bool VerifierVictoire()
        {
            char c = ObtenirPion();
            return grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c && grille[3, 0] == c ||
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
        }

        public override bool VerifierEgalite() =>
            grille[0, 0] != ' ' && grille[0, 1] != ' ' && grille[0, 2] != ' ' && grille[0, 3] != ' ' && grille[0, 4] != ' ' && grille[0, 5] != ' ' && grille[0, 6] != ' ' &&
            grille[1, 0] != ' ' && grille[1, 1] != ' ' && grille[1, 2] != ' ' && grille[1, 3] != ' ' && grille[1, 4] != ' ' && grille[1, 5] != ' ' && grille[1, 6] != ' ' &&
            grille[2, 0] != ' ' && grille[2, 1] != ' ' && grille[1, 2] != ' ' && grille[2, 3] != ' ' && grille[2, 4] != ' ' && grille[2, 5] != ' ' && grille[2, 6] != ' ' &&
            grille[3, 0] != ' ' && grille[3, 1] != ' ' && grille[3, 2] != ' ' && grille[3, 3] != ' ' && grille[3, 4] != ' ' && grille[3, 5] != ' ' && grille[3, 5] != ' ';


        public override void FinPartie(bool jeuTermineParVictoire = false)
        {
            Console.Clear();
            AfficherPlateau();
            if (jeuTermineParVictoire)
                AfficherGagnant();
            else
                AfficherEgalite();
        }

        public override void TerminerJeu()
        {
            quitterJeu = true;
            Console.Clear();
        }
    }
}

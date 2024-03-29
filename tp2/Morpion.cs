﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion : Jeu
    {
        public Morpion()
        {
            grille = new char[3, 3];
        }

        public void InitialiserGrille()
        {
            grille = new char[3, 3]
            {
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
            };
        }

        public void AfficherPlateau()
        {
            Console.WriteLine();
            Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille[2, 0]}  |  {grille[2, 1]}  |  {grille[2, 2]}");
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

        public override void BoucleJeu()
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

        public override void TourJoueur()
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
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
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
                    if (column >= 2)
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
                        column = 2;
                    }
                    else
                    {
                        column = column - 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (row <= 0)
                    {
                        row = 2;
                    }
                    else
                    {
                        row = row - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (row >= 2)
                    {
                        row = 0;
                    }
                    else
                    {
                        row = row + 1;
                    }
                    break;
            }

            return (row, column);
        }

        public override char ObtenirPion()
        {
            return tourDuJoueur ? 'X' : 'O';
        }

        public override void PlacerPion(int row, int column)
        {
            if (grille[row, column] is ' ')
            {
                grille[row, column] = ObtenirPion();
                tourEstJoue = true;
                quitterJeu = false;
            }
        }

        public override bool VerifierVictoire()
        {
            char c = ObtenirPion();
            return VictoireParLigne(c) || VictoireParColonne(c) || VictoireParDiagonale(c);
        }

        public override bool VictoireParLigne(char c)
        {
            return grille[0, 0] == c && grille[0, 1] == c && grille[0, 2] == c ||
                   grille[1, 0] == c && grille[1, 1] == c && grille[1, 2] == c ||
                   grille[2, 0] == c && grille[2, 1] == c && grille[2, 2] == c; 
        }

        public override bool VictoireParColonne(char c)
        {
            return grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c ||
                   grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c ||
                   grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c;
        }

        public override bool VictoireParDiagonale(char c)
        {
            return grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c ||
                   grille[2, 0] == c && grille[1, 1] == c && grille[0, 2] == c;
        }

        public override bool VerifierEgalite()
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

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

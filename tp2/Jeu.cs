using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    internal abstract class Jeu
    {
        public bool quitterJeu = false;
        public bool tourEstJoue = false;
        public bool tourDuJoueur = true;
        public char[,] grille;

        public abstract void BoucleJeu();
        public abstract void ChoixFinPartie();
        public abstract void TourJoueur();
        public abstract (int, int) DeplacerCurseur(int row, int column, System.ConsoleKey key);
        public abstract char ObtenirPion();
        public abstract void PlacerPion(int row, int column);
        public abstract bool VerifierVictoire();
        public abstract bool VictoireParLigne(char c);
        public abstract bool VictoireParColonne(char c);
        public abstract bool VictoireParDiagonale(char c);
        public abstract bool VerifierEgalite();
        public abstract void FinPartie(bool jeuTermineParVictoire);
        public abstract void TerminerJeu();
    }
}

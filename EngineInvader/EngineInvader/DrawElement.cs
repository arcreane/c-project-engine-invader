using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineInvader
{
    //Classe permettant de regrouper toute la logique de dessin de tous les éléments du jeu
    abstract public class DrawElement
    {
        //Information pour savoir si l'élément doit être détruit ou non
        //Comme il est contenu dans une liste (dans la classe programme) cela permet de signaler à celle ci
        //de le sortir de la liste, sans que celle ci ait besoin de connaitre la logique de destruction (sorti de l'écran,
        //détruit par le joueur....)
        public bool IsDestroyed { get; internal set; } = false;
        
        
        //Coordonnée dans la console
        public int X { get; set; }
        
        //Le Y est particulier par rapport à X, si l'élément sort de la console alors il doit être détruit
        //On doit donc avoir une logique spéciale dans le set
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; if (value == Console.WindowHeight-1) IsDestroyed = true; }
        }

        //Coordonnée de l'élément à la boucle précédente
        public int PrevX { get; set; }
        public int PrevY { get; set; }

        //Informations servant à afficher l'objet
        public char DisplayChar { get; set; }
        public ConsoleColor DrawColor { get; set; }

        //Constructeur permettant de positionner l'élément à sa création
        protected DrawElement(int x, int y)
        {
            X = x;
            Y = y;
        }

        //Methode de dessin
        internal void Draw(bool display)
        {
            Console.ForegroundColor = DrawColor;
            Console.SetCursorPosition(PrevX, PrevY);
            Console.Write(" ");
            Console.SetCursorPosition(X, Y);
            if(display)
                Console.Write(DisplayChar);
            PrevX = X;
            PrevY = Y;
        }

        //Méthode de Déplacement. Doit être redéfinie dans chaque classe enfant
        public abstract void Move();

    }
}

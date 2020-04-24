using System;
namespace EngineInvader
{
    abstract public class Player : DrawElement
    {
      
        public Player(int x, int y) : base (x,y)
        {
            DisplayChar = 'X';
            DrawColor = ConsoleColor.Red;
        }

        public override void Move()
        {
            //Récupérer quand on appuie sur les touches gauche et droite 
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.LeftArrow && X > 0)
                    X--;
                else if (Console.ReadKey(true).Key == ConsoleKey.RightArrow && X < Console.WindowWidth - 1)
                    X++;

                else if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    actionspeciale();

            }
        }

        protected abstract void actionspeciale();
    }
}

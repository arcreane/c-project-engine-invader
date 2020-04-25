using System;
using System.Timers;
namespace EngineInvader
{
    public class Player : DrawElement
    {
        //Variable speed qui va être affecté à
        //chaque classe enfant avec une valeure différente
        public int Speed = 5;
        static Player MyPlayer;
        public Player(int x, int y) : base (x,y)
        {
            DisplayString = "X";
            //Le timer pour définir la vitesse de récupération de touche
            //de chaque véhicule
            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += t_Elapsed;
            t.Interval = Speed;
            t.Start();
        }

        private static void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            MyPlayer.Move();
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
                    SpecialAction();
            }
        }

        protected override void SpecialAction()
        {
            throw new NotImplementedException();
        }
    }
}

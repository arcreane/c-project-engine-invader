using System;
using System.Timers;
namespace EngineInvader
{
    public class Tank : Player
    {
        static Tank MyTank;
        static List<DrawElement> elements;
        public Tank(int x, int y) : base(x, y)
        {
            DisplayString = "O[]O";
            EraseString = "    ";
            DrawColor = ConsoleColor.Red;
            Speed = 100;
            
        }

        //Le tank est invinsible contre certains obstacles pendant 10s
        protected override void SpecialAction()
        {
            System.Timers.Timer tankTimer = new System.Timers.Timer();
            tankTimer.Elapsed += tankTimer_Elapsed;
            tankTimer.Interval = 10000;
            tankTimer.Start();
        }

        private static void tankTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                if (i > 0 && elements[i].X == MyTank.X && elements[i].Y == MyTank.Y)
                {
                    MyTank.IsDestroyed = false;
                }
            }
        }
    }
}
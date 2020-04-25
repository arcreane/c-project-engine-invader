using System;
using System.Timers;
namespace EngineInvader
{
    public class Moto : Player
    {
        public DestructionWire destructionWire = new DestructionWire;
        static Tank MyTank;
        public Moto(int x, int y) : base(x, y)
        {
            DisplayString = "-!-";
            EraseString = "   ";
            DrawColor = ConsoleColor.Red;
            Speed = 10;
        }

        //La moto est invinsible contre DestructionWire pendant 30s
        protected override void SpecialAction()
        {
            System.Timers.Timer motoTimer = new System.Timers.Timer();
            motoTimer.Elapsed += motoTimer_Elapsed;
            motoTimer.Interval = 30000;
            motoTimer.Start();
        }

        private static void motoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            for (int i = destructionWire.Count - 1; i >= 0; i--)
            {
                if (i > 0 && destructionWire[i].X == MyMoto.X && destructionWire[i].Y == MyMoto.Y)
                {
                    MyTank.IsDestroyed = false;
                }
            }
        }
    }
}

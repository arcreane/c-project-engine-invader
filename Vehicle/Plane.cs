using System;
namespace EngineInvader
{
    public class Plane : Player
    {
        public Plane(int x, int y) : base(x, y)
        {
            DisplayString = "oÔo";
            EraseString = "   ";
            DrawColor = ConsoleColor.Red;
            Speed = 50;
        }

        //L'avion lance des rockets
        protected override void SpecialAction()
        {
            DisplayString = "*";
            EraseString = " ";
            DrawColor = ConsoleColor.Red;
            RocketMove();
        }
        public override void RocketMove()
        {
            Y--;
        }
    }
}

using System;
namespace EngineInvader
{
    public class Moto : Player
    {
        public Moto(int x, int y) : base(x, y)
        {
            DisplayString = "-!-";
            EraseString = "  ";
            DrawColor = ConsoleColor.Red;
            Speed = 10;
        }

        //La moto est encore plus rapide
        protected override void SpecialAction()
        {
        }
    }
}

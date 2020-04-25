using System;
namespace EngineInvader
{
    public class Moto : Player
    {
        public Moto(int x, int y) : base(x, y)
        {
            DisplayString = "8";
            EraseString = " ";
            DrawColor = ConsoleColor.Red;
            Speed = 1;
        }

        //protected override void specialeAction()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

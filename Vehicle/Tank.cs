using System;
namespace EngineInvader
{
    public class Tank : Player
    {
        public Tank(int x, int y) : base(x, y)
        {
            DisplayString = "O[]O";
            EraseString = "    ";
            DrawColor = ConsoleColor.Red;
            Speed = 200;
        }

        //protected override void specialeAction())
        //{
        //    throw new NotImplementedException();
        //}
    }
}
 
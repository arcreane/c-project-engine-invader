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
            Speed = 250;
        }

        //protected override void actionspeciale()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
 
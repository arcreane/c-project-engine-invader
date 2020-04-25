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

        //protected override void specialeAction()
        //{
        //    MyPlayerIsInvinsble();
        //}
    }
}

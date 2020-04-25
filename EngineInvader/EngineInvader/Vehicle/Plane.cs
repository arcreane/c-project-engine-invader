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
            Speed = 200;
        }

        //protected override void actionspeciale()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

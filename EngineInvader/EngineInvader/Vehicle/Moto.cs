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
            Speed = 150;
        }

        //protected override void actionspeciale()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

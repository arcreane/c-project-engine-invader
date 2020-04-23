using System;
namespace EngineInvader
{
    public class Moto : Player
    {
        //public int Speed { get; set; }
        public Moto(int x, int y) : base(x, y)
        {
            //Speed = 5;
            DisplayChar = 'X';
            DrawColor = ConsoleColor.Red;
        }
    }
}

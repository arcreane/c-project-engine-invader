using System;
namespace EngineInvader
{
    public class Plane : Player
    {
        public Plane(int x, int y) : base(x, y)
        {
            DisplayChar = 'X';
            DrawColor = ConsoleColor.Blue;
        }
    }
}

using System;
namespace EngineInvader
{
    public class Plane : DrawElement
    {
        public Plane(int x, int y) : base(x,y)
        {
            DisplayChar = 'P';
            DrawColor = ConsoleColor.Green;
        }

        //Simple déplacement vertical
        public override void Move()
        {
            Y++;
        }
    }
}

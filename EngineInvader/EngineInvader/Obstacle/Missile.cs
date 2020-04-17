using System;
namespace EngineInvader
{
    public class Missile : DrawElement
    {
        public Missile(int x, int y) : base(x, y)
        {
            DisplayChar = 'M';
            DrawColor = ConsoleColor.Yellow;
        }

        //Simple déplacement vertical
        public override void Move()
        {
            Y++;
        }
    }
}

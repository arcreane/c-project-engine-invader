using System;
namespace EngineInvader
{
    public class Missile : DrawElement
    {
        public Missile(int x, int y) : base(x, y)
        {
            DisplayString = "##";
            EraseString = "  ";
            DrawColor = ConsoleColor.DarkCyan;
        }

        //Simple déplacement vertical
        public override void Move()
        {
            Y++;
        }
    }
}

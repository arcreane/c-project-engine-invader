using System;
namespace EngineInvader
{
    public class DestructionWire : DrawElement
    {
        public DestructionWire(int x, int y) : base(x, y)
        {
            DisplayString = "##";
            EraseString = "  ";
            DrawColor = ConsoleColor.DarkGray;
        }

        //Simple déplacement vertical
        public override void Move()
        {
            Y++;
        }
    }
}

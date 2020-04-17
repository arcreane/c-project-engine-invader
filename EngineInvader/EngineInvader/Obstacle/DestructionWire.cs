using System;
namespace EngineInvader.Enemy
{
    public class DestructionWire : DrawElement
    {
        public DestructionWire(int x, int y) : base(x, y)
        {
            DisplayChar = 'D';
            DrawColor = ConsoleColor.Red;
        }

        //Simple déplacement vertical
        public override void Move()
        {
            Y++;
        }
    }
}

using System;
namespace EngineInvader
{
    public class AerialBattery : DrawElement
    {
        public AerialBattery(int x, int y) : base(x, y)
        {
            DisplayString = "##";
            EraseString = "  ";
            DrawColor = ConsoleColor.Blue;
        }

        //Simple déplacement vertical
        public override void Move()
        {
            Y++;
        }
    }
}

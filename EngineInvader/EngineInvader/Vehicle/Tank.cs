using System;
namespace EngineInvader
{
    public class Tank : Player
    {
        public Tank(int x, int y) : base(x, y)
        {
            DisplayChar = 'X';
            DrawColor = ConsoleColor.Yellow;
        }


        protected override void actionspeciale()
        {
            throw new NotImplementedException();
        }
    }
}

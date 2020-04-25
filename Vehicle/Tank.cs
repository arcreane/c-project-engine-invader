﻿using System;
namespace EngineInvader
{
    public class Tank : Player
    {
        public Tank(int x, int y) : base(x, y)
        {
            DisplayString = "O[]O";
            EraseString = "    ";
            DrawColor = ConsoleColor.Red;
            Speed = 200;
        }

        //Le tank est invinsible durant la durée du timer
        protected override void SpecialAction()
        {i   
        }
    }
}
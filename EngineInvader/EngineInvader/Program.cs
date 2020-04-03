using System;
using System.Timers;

namespace EngineInvader
{
    class MainClass
    {
        static String display;
        static int score;
        public static void Main(string[] args)
        {
            display = "*";
            score = 0;
            Timer t = new Timer();
            t.Elapsed += Refresh;
            t.Interval = 1000;
            Console.WriteLine(score);
            Console.CursorTop = score;
            Console.CursorLeft = score;

            //t.Start();
            while(true)
            { }
        }

        private static void Refresh(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            score++;
            Console.CursorTop = score;
            Console.CursorLeft = 0;

            Console.Write(display);
            Console.CursorTop = score+2;
            Console.CursorLeft = 5;

            Console.Write(display);
            Console.CursorTop = score;
            Console.CursorLeft = 10;

            Console.Write(display);
            Console.CursorTop = score+2;
            Console.CursorLeft = 15;

            Console.Write(display);
            Console.CursorTop = score;
            Console.CursorLeft = 20;

            Console.Write(display);
        }
    }
}

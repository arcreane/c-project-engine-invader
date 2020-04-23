using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace EngineInvader
{
    class MainClass
    {
        class Program
        {
            //Liste des éléments à dessiner 
            static List<DrawElement> elements;
            static Player MyPlayer;
            static void Main(string[] args)
            {
                //Démarage et choix du véhicule
                int vehicleChoosing;
                Console.WriteLine("Hello and welcome to EngineInvader.");
                Console.WriteLine("Choose your vehicle please.");
                Console.WriteLine("1 - Moto");
                Console.WriteLine("2 - Plane");
                Console.WriteLine("3 - Tank");

                vehicleChoosing = int.Parse(Console.ReadLine());

                switch (vehicleChoosing)
                {
                    case 1:
                        Console.WriteLine("Moto");
                        break;
                    case 2:
                        Console.WriteLine("Plane");
                        break;
                    case 3:
                        Console.WriteLine("Tank");
                        break;
                    default:
                        Console.WriteLine("Please choose between 1, 2, 3");
                        break;
                }

                Console.CursorVisible = false;

                //Le player doit être créé à part pour pouvoir le manipuler tout seul
                MyPlayer = new Player(50, Console.WindowHeight - 5);

                //Liste des éléments à dessiner (dont le joueur)
                elements = new List<DrawElement>();
                elements.Add(MyPlayer);
                Invaders();

                //Générer des index aléatoires pour chaque obstcales
                void Invaders()
                {
                Random rnd = new Random();
                elements.Add(new AerialBattery(Console.WindowWidth / rnd.Next(1,10), rnd.Next(1, 10)));
                elements.Add(new DestructionWire(Console.WindowWidth / rnd.Next(1, 10), rnd.Next(1, 10)));
                elements.Add(new Missile(Console.WindowWidth / rnd.Next(1, 10), rnd.Next(1, 10)));
                }

                while (MyPlayer.IsDestroyed == false)
                {
                    Invaders();
                }

                //Le timer qui permet d'avoir des actions qui se passent parallèlement
                //L'interval correspond à la durée entre 2 événement "Elapsed"
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = 200;
                timer.Start();
                
                //La gestion des mouvements du joueur doit être plus fine que la boucle de jeu, on la met donc dans un
                //while true pour le faire le plus rapidement possible
                while (true)
                {
                    MyPlayer.Move();
                    //Si le joueur est détruit, le jeu s'arrete
                    if (MyPlayer.IsDestroyed)
                    {
                        timer.Stop();
                        break;
                    }

                }
                //Etre sur que le timer a bien fini sa boucle avant de nettoyer l'écran
                Thread.Sleep(200);
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER");
                Console.ReadLine();
            }

            //Méthode appelé dans un thread en parallèle pour que le programme puissent faire simultanément plusieurs chose
            private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(0, 0);
                //Pour tous les éléments à dessiner, on appels également leur méthode de déplacement et si ils
                //sortent de l'écran on les supprime de la liste
                for (int i = elements.Count - 1; i >= 0; i--)
                {
                    elements[i].Draw(true);
                    elements[i].Move();
                    //Si un élément est sur la même case que le player et n'est pas le player lui même
                    if (i > 0 && elements[i].X == MyPlayer.X && elements[i].Y == MyPlayer.Y)
                    {
                        MyPlayer.IsDestroyed = true;
                    }
                    if (elements[i].IsDestroyed)
                    {
                        elements[i].Draw(false);
                        elements.RemoveAt(i);
                    }
                }
            }
    
        }
    }
}

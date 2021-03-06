﻿using System;
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
            private static int score;
            private static int level;
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
                        MyPlayer = new Moto(50, Console.WindowHeight - 5);

                        break;
                    case 2:
                        Console.WriteLine("Plane");
                        MyPlayer = new Plane(50, Console.WindowHeight - 5);
                        break;
                    case 3:
                        Console.WriteLine("Tank");
                        MyPlayer = new Tank(50, Console.WindowHeight - 5);
                        break;
                    default:
                        Console.WriteLine("Please choose between 1, 2, 3");
                        break;
                }

                Console.CursorVisible = false;

                //Liste des éléments à dessiner (dont le joueur)
                elements = new List<DrawElement>();
                elements.Add(MyPlayer);
                Invaders();

                Console.Clear();

                //Le timer qui permet d'avoir des actions qui se passent parallèlement
                //L'interval correspond à la durée entre 2 événement "Elapsed"
                //Variable du score
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = 200;
                timer.Start();
                score = 0;
                level = 1;

                while (true)
                {
                    //Si le joueur est détruit, le jeu s'arrete
                    if (MyPlayer.IsDestroyed)
                    {
                        timer.Stop();
                        break;
                    }
                }

                //Etre sur que le timer a bien fini sa boucle avant de nettoyer l'écran
                //Affichage game obver
                Thread.Sleep(200);
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                string str = "Game Over" + "\n" + "Your score is: " + score + "\n" + "Press 1 for replay";
                Console.WriteLine(str);

                //Proposer au joueur de rejouer
                System.Diagnostics.ProcessStartInfo
                myInfo = new System.Diagnostics.ProcessStartInfo();
                myInfo.FileName = "EngineInvader.exe";
                int replay;
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
                replay = int.Parse(Console.ReadLine());
                switch (replay)
                {
                    case 1:
                        System.Diagnostics.Process.Start(myInfo);
                        break;
                    case 2:
                        Console.WriteLine("Please close the consol");
                        break;
                    default:
                        Console.WriteLine("Please press 1 or close the consol");
                        break;
                }
            }

            //Générer des index aléatoires pour chaque obstcales à dessiner
            static void Invaders()
            {
                Random rnd = new Random();
                elements.Add(new AerialBattery(Console.WindowWidth - rnd.Next(1, Console.WindowWidth - 1), rnd.Next(2, 10)));
                elements.Add(new DestructionWire(Console.WindowWidth - rnd.Next(1, Console.WindowWidth - 1), rnd.Next(2, 10)));
                elements.Add(new Missile(Console.WindowWidth - rnd.Next(1, Console.WindowWidth - 1), rnd.Next(2, 10)));
            }

            //Méthode appelé dans un thread en parallèle pour que le programme puissent faire simultanément plusieurs chose
            private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                Console.SetCursorPosition(0, 0);
                string str2 = "Score: " + score;
                Console.WriteLine(str2);
                string str3 = "Level: " + level;
                Console.WriteLine(str3);

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
                        //Plus il y'a déléments supprimés plus la diffiuclté augmente
                        elements[i].Draw(false);
                        elements.RemoveAt(i);
                        score++;
                        if (score > 150*level)
                        {
                            level++;
                            //Changer la vitesse du timer ici
                        }
                    }
                }
                if (elements.Count < 20)
                    Invaders();
            }
        }
    }
}

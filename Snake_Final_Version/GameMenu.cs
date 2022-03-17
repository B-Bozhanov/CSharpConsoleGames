using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Snake
{
    class GameMenu
    {

        public void WellcomeSreen()
        {
            Visualizer visualizer = new Visualizer();
            GameSettings settings = new GameSettings();

            settings.ConsoleSettings();
            Random generator = new Random();
            int loadingTime = 0;

            string screen = $"Wellcome";
            string loading = "loading...";
            Coordinates wellcomeText = new Coordinates(settings.ConsoleRow / 2, settings.ConsoleCol / 2 - 5);

            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (true)
            {
                TimeSpan seconds = timer.Elapsed;
                visualizer.Write(screen, wellcomeText.Row, wellcomeText.Col, ConsoleColor.Yellow);
                visualizer.Write(loading, wellcomeText.Row + 1, wellcomeText.Col, ConsoleColor.Yellow);

                loadingTime = 0;// generator.Next(5, 12);
                if (seconds.Seconds == loadingTime)
                {
                    timer.Reset();
                    Console.Clear();
                    break;
                }
            }

            while (true)
            {
                string[] menuElements = new string[]
                   {
                      "New Game",
                      "Dificult",
                      "Settings",
                      "Exit"
                   };
                string element = null;
                element = GameOptions(menuElements, settings);

                if (element == "New Game")
                {

                }
                else if (element == "Dificult")
                {

                }
                else if (element == "Settings")
                {
                    Console.Clear();
                    while (true)
                    {
                        string[] settingsOptions = new string[]
                        {
                           "Screen size",
                           "Dificult",
                           "Field Color",
                           "Snake Color",
                           "Snake Length",
                           "Back"
                        };
                        string settingsElement = GameOptions(settingsOptions, settings);
                        if (settingsElement == "Screen size")
                        {
                            while (true)
                            {
                                Console.Clear();
                                string[] screenSize = new string[]
                                {
                                  "Small",
                                  "Medium",
                                  "Large",
                                  "Back"
                                };
                                string currentScreen = GameOptions(screenSize, settings);
                                if (currentScreen == "Small")
                                {
                                    settings.ConsoleRow = 15;
                                    settings.ConsoleCol = 60;
                                    //settings = new GameSettings(15, 60);
                                }
                                else if (currentScreen == "Medium")
                                {
                                    settings.ConsoleRow = 30;
                                    settings.ConsoleCol = 120;
                                }
                                else if (currentScreen == "Large")
                                {
                                    settings.ConsoleRow = 46;
                                    settings.ConsoleCol = 192;
                                }
                                else if (currentScreen == "Back")
                                {
                                    Console.Clear();
                                    break;
                                }
                                settings.ConsoleSettings();
                            }
                        }
                        else if (settingsElement == "Dificult")
                        {

                        }
                        else if (settingsElement == "Field Color")
                        {

                        }
                        else if (settingsElement == "Snake Color")
                        {

                        }
                        else if (settingsElement == "Snake Length")
                        {

                        }
                        else if (settingsElement == "Back")
                        {
                            Console.Clear();
                            break;
                        }
                    }

                }
                else if (element == "Exit")
                {
                    Console.Clear();

                    visualizer.Write("Are you sure ?", settings.ConsoleRow / 2, settings.ConsoleCol / 2 - 7, ConsoleColor.Yellow);
                    visualizer.Write("y \\ n", settings.ConsoleRow / 2 + 1, settings.ConsoleCol / 2 - 3, ConsoleColor.Yellow);

                    string pressedKey = GetKeyboarKeyPressed();
                    if (pressedKey == "y")
                    {
                        Console.Clear();
                        visualizer.Write("Good bye !", settings.ConsoleRow / 2 + 3, settings.ConsoleCol / 2 - 4, ConsoleColor.Red);
                        Thread.Sleep(400);
                        Environment.Exit(0);
                    }
                    else if (pressedKey == "n")
                    {
                        Console.Clear();
                    }
                }
            }
            //while (true)
            //{
            //    // Print menu options
            //    for (int i = 0; i < menuElements.Length; i++)
            //    {
            //        Console.SetCursorPosition(menu.Col, menu.Row);
            //        visualizer.Write(menuElements[i], menu.Row + i, menu.Col, ConsoleColor.Yellow);
            //        menuElementsPossition.Add(new Coordinates(menu.Row + i, menu.Col));
            //    }
            //    int cursorDirection = 0;
            //    bool isEnterPressed = false;

            //    if (Console.KeyAvailable)
            //    {
            //        ConsoleKeyInfo key = Console.ReadKey();
            //        if (key.Key == ConsoleKey.DownArrow)
            //        {
            //            cursorDirection = 1;
            //        }
            //        if (key.Key == ConsoleKey.UpArrow)
            //        {
            //            cursorDirection = -1;
            //        }
            //        if (key.Key == ConsoleKey.Enter)
            //        {
            //            isEnterPressed = true;
            //        }
            //    }

            //    visualizer.Write(" ", cursor.Row, cursor.Col);
            //    cursor.Row += cursorDirection;

            //    if (cursor.Row < menu.Row)
            //    {
            //        cursor.Row = menu.Row;
            //    }
            //    if (cursor.Row > menu.Row + menuElements.Length - 1)
            //    {
            //        cursor.Row = menu.Row + menuElements.Length - 1;
            //    }

            //    visualizer.Write("*", cursor.Row, cursor.Col, ConsoleColor.Yellow);

            //    if (isEnterPressed)
            //    {
            //        for (int i = 0; i < menuElementsPossition.Count; i++)
            //        {
            //            if (menuElementsPossition[i].Row == cursor.Row && menuElementsPossition[i].Col == menu.Col)
            //            {
            //                if (menuElements[i] == "Exit")
            //                {
            //                    Console.Clear();

            //                    visualizer.Write("Are you sure ?", settings.ConsoleRow / 2, settings.ConsoleCol / 2 - 7, ConsoleColor.Yellow);
            //                    visualizer.Write("y \\ n", settings.ConsoleRow / 2 + 1, settings.ConsoleCol / 2 - 3, ConsoleColor.Yellow);

            //                    string pressedKey = GetKeyboarKeyPressed();
            //                    if (pressedKey == "y")
            //                    {
            //                        Console.Clear();
            //                        Environment.Exit(0);
            //                    }
            //                    else if (pressedKey == "n")
            //                    {
            //                        Console.Clear();
            //                        break;
            //                    }
            //                }
            //                if (menuElements[i] == "Settings")
            //                {
            //                    menuElements = new string[]
            //                    {
            //                        "Screen size",
            //                        "Dificult",
            //                        "Field Color",
            //                        "Snake Color",
            //                        "Snake Length"
            //                    };
            //                    break;
            //                }
            //                if (menuElements[i] == "Screen size")
            //                {
            //                    Console.Clear();
            //                    menuElements = new string[]
            //                    {
            //                        "Small",
            //                        "Medium",
            //                        "Large"
            //                    };
            //                    break;
            //                }
            //                if (menuElements[i] == "Small")
            //                {
            //                    GameSettings gameSettings = new GameSettings();
            //                    gameSettings.ConsoleRow = 15;
            //                    gameSettings.ConsoleCol = 60;
            //                }
            //            }
            //        }
            //    }
            //    Thread.Sleep(40);
            //}
        }
        public string GetKeyboarKeyPressed()
        {
            Visualizer visualizer = new Visualizer(); // TODO: Something with this !!!!!!!!!
            GameSettings settings = new GameSettings(); // and This !!!!!!

            string pressedKey = string.Empty;
            string timeToExit = "Time to exit - 10  seconds";

            Stopwatch secToExit = new Stopwatch();
            secToExit.Start();
            while (true)
            {
                TimeSpan timer = secToExit.Elapsed;
                if (timer.Seconds >= 15)
                {
                    visualizer.Write(timeToExit, settings.ConsoleRow / 2 + 5, (settings.ConsoleCol / 2) - (timeToExit.Length / 2), ConsoleColor.Red);
                    visualizer.Write((timer.Seconds - 15).ToString(), settings.ConsoleRow / 2 + 6, (settings.ConsoleCol / 2), ConsoleColor.Red);
                }
                if (timer.Seconds == 25)
                {
                    Console.Clear();
                    visualizer.Write("Good bye !", settings.ConsoleRow / 2 + 3, settings.ConsoleCol / 2 - 4, ConsoleColor.Red);
                    Thread.Sleep(400);
                    Environment.Exit(0);
                }
                ConsoleKeyInfo key;
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Y)
                    {
                        pressedKey = "y";
                        break;
                    }
                    if (key.Key == ConsoleKey.N)
                    {
                        pressedKey = "n";
                        break;
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        pressedKey = "enter";
                        break;
                    }
                }
            }

            return pressedKey;
        }
        public string GameOptions(string[] menuElements, GameSettings settings)
        {
            //GameSettings settings = new GameSettings();
            Visualizer visualizer = new Visualizer();
            Coordinates menu = new Coordinates(settings.ConsoleRow / 2, settings.ConsoleCol / 2 - 6);
            Coordinates cursor = new Coordinates(menu.Row, menu.Col - 2);
            Dictionary<Coordinates, string> menuElementsPossition = new Dictionary<Coordinates, string>();

            while (true)
            {
                // Print menu options
                for (int i = 0; i < menuElements.Length; i++)
                {
                    Console.SetCursorPosition(menu.Col, menu.Row);
                    visualizer.Write(menuElements[i], menu.Row + i, menu.Col, ConsoleColor.Yellow);
                    menuElementsPossition.Add(new Coordinates(menu.Row + i, menu.Col), menuElements[i]);
                }

                int cursorDirection = 0;
                bool isEnterPressed = false;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        cursorDirection = 1;
                    }
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        cursorDirection = -1;
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        isEnterPressed = true;
                    }
                }
                // Move cursor
                visualizer.Write(" ", cursor.Row, cursor.Col);
                cursor.Row += cursorDirection;
                // Check if cursor is out from the menu
                if (cursor.Row < menu.Row)
                {
                    cursor.Row = menu.Row;
                }
                if (cursor.Row > menu.Row + menuElements.Length - 1)
                {
                    cursor.Row = menu.Row + menuElements.Length - 1;
                }

                visualizer.Write("*", cursor.Row, cursor.Col, ConsoleColor.Yellow);

                if (isEnterPressed)
                {
                    foreach (var possition in menuElementsPossition)
                    {
                        if (possition.Key.Row == cursor.Row)
                        {
                            Console.Clear();
                            return possition.Value;
                        }
                    }
                }
                Thread.Sleep(40);
            }
        }
    }
}

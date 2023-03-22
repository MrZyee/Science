using System;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;  //zatrzymanie wyświetlania kursora
            bool exit = false;
            double frameRate = 1000 / 5.0;
            DateTime lastDate = DateTime.Now;
            Meal meal = new Meal();
            //game loop
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();  //odczytanie klawisza od użytkownika

                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            //x
                            break;
                        case ConsoleKey.RightArrow:
                            //x
                            break;
                        case ConsoleKey.UpArrow:
                            //x
                            break;
                        case ConsoleKey.DownArrow:
                            //x
                            break;
                    }
                }

                if ((DateTime.Now - lastDate).TotalMilliseconds >= frameRate)
                {
                    // game action
                    lastDate = DateTime.Now;
                }
            }
        }
    }
}
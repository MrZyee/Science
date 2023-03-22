using System;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;  //zatrzymanie wyświetlania kursora
            bool exit = false;
            double frameRate = 1000 / 5.0; //ilość klatek na sekundę z czasem zdobywania jedzenia ona się zwiększa
            DateTime lastDate = DateTime.Now;
            Meal meal = new Meal();
            Snake snake = new Snake();

            //game loop
            while (!exit)
            {
                if (Console.KeyAvailable) // przechwytujemy sterowanie 
                {
                    ConsoleKeyInfo input = Console.ReadKey();  //odczytanie klawisza od użytkownika

                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                    }
                }

                if ((DateTime.Now - lastDate).TotalMilliseconds >= frameRate) //obsługa naszych klatek
                {
                    // game action
                    snake.Move();

                    if (meal.CurrentTarget.X == snake.HeadPosition.X && meal.CurrentTarget.Y == snake.HeadPosition.Y) //zbieranie jedzenia 
                    {
                        snake.EatMeal();
                        meal = new Meal();
                        frameRate /= 1.1; // współczynnik zwiększania prędkości po każdym zebraniu jedzenia
                    }

                    if (snake.GameOver) //warunek kończenia gry
                    {
                        Console.Clear();
                        Console.WriteLine($"Game Over Your Score: {snake.Length}"); // zakończenie gry + wyświetlanie wyniku (długości węża)
                        exit = true;
                        Console.ReadLine();
                    }

                    lastDate = DateTime.Now;
                }
            }
        }
    }
}
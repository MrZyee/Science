using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : ISnake
    {
        public int Length { get; set; } = 1;  //Długość początkowa
        public Direction Direction { get; set; } = Direction.Right; // Pierwszy ruch w prawo
        public Coordinate HeadPosition { get; set; } = new Coordinate(); //określenie głowy węża czyli gdzie zaczyna 
        List<Coordinate> Tail { get; set; } = new List<Coordinate> (); //ogon i korpus węża

        private bool outOfRange = false; //zmianna określająca wyjechanie węża po za zakres planszy

        public bool GameOver
        {
            get {
                return
                    (Tail.Where(c => c.X == HeadPosition.X
                    && c.Y == HeadPosition.Y).ToList().Count > 1);
                    }  //zwracamy wartośc która będzie bool'em kiedy głową wjedziemy w jakąś część ogona to kończymy grę
                 
        }

        public void EatMeal()
        {
            Length++;
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.Left:
                    
                    break;
                case Direction.Right:
                    HeadPosition.X++;
                    break;
                case Direction.Up:
                    HeadPosition.Y--;
                    break;
                case Direction.Down:
                    HeadPosition.Y++;
                    break;
            }
            try
            {
                Console.SetCursorPosition(HeadPosition.X, HeadPosition.Y);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("@");
            }
            catch (ArgumentOutOfRangeException)
            {
                outOfRange = true;
            }
            
        }
    }

    public enum Direction { Left, Right, Up, Down };

}

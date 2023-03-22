using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : ISnake
    {
        public int Length { get; set; } = 5;  //Długość początkowa
        public Direction Direction { get; set; } = Direction.Right; // Kierunek w którym wąż podąża na początku rozgrywki
        public Coordinate HeadPosition { get; set; } = new Coordinate(); //określenie głowy węża czyli gdzie zaczyna 
        List<Coordinate> Tail { get; set; } = new List<Coordinate> (); // koordynaty ogona i korpusu węża

        private bool outOfRange = false; //zmianna określająca wyjechanie węża po za zakres planszy

        public bool GameOver
        {
            get {
                return
                    (Tail.Where(c => c.X == HeadPosition.X
                    && c.Y == HeadPosition.Y).ToList().Count > 1) || outOfRange;
                    }  //zwracamy wartośc która będzie bool'em kiedy głową wjedziemy w jakąś część ogona to kończymy grę
                 
        }

        public void EatMeal() //zwiększanie długości węża 
        {
            Length++;
        }

        public void Move() // ruch węża - zmieniamy koordynaty węża
        {
            switch (Direction)
            {
                case Direction.Left:
                    HeadPosition.X--;
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
                Tail.Add(new Coordinate(HeadPosition.X, HeadPosition.Y));

                // na początek długość ogona jest 1. Więc jeśli nam przekroczy to jaka ona powinna być
                if (Tail.Count > this.Length) //warunek - co ma się stać kiedy wielkośc ogona jest większa niż jest długość węża
                {
                    var endTail = Tail.First(); //usuwany ostatni element z listy 
                    Console.SetCursorPosition(endTail.X, endTail.Y); 
                    Console.Write(" ");
                    Tail.Remove(endTail);// usuwamy ostatni element z konsoli 
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                outOfRange = true;
            }
            
        }
    }

    public enum Direction { Left, Right, Up, Down };

}

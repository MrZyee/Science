using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Meal
    {
        public Meal() //randomowo pojawianie się jedzenia na planszy
        {
            Random rand = new Random();
            var x =rand.Next(1, 20);
            var y =rand.Next(1, 20);
            CurrentTarget = new Coordinate(x, y); // przypisanie do propertisa z tego powodu że będzemy potrzebowali na zewnątrz zobaczyć jaki jest ten CurrentTarget żeby zrobic sprawdzenie w grze czy nasz snake zjadł ten posiłek
            Draw();
        }

        public Coordinate CurrentTarget { get; set; }

        void Draw() //rysowanie jedzenia dla węża
        {
            Console.SetCursorPosition(CurrentTarget.X, CurrentTarget.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$");
        }
    }
}

using System;

namespace TicTacToe
{
    internal class Program
    {
        static int[] board = new int[9];
        static void Main(string[] args)
        { 
            board[0] = 0;
            board[1] = 0;
            board[2] = 0;
            board[3] = 1;
            board[4] = 2;
            board[5] = 0;
            board[6] = 0;
            board[7] = 0;
            board[8] = 1;

            printBoard();

            int humanTurn = int.Parse(Console.ReadLine());
        }

        private static void printBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                //drukowanie tablicy do gry
                //Console.WriteLine("Square " + i + " contains " + board[i]);

                if (board[i] == 0)
                {
                    Console.Write(".");
                }
                if (board[i] == 1)
                {
                    Console.Write("X");
                }
                if (board[i] == 2)
                {
                    Console.Write("O");
                }
                // drukowanie w nowej lini po 3 zmiennej

                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }

            }
        }
    }
}
using System;

namespace TicTacToe
{
    internal class Program
    {
        static int[] board = new int[9];
        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                board[0] = 0;
            }


            int humanTurn = -1;
            int computerTurn = -1;
            Random rand = new Random();

            while (checkForWinner() == 0)
            {
                while (humanTurn == -1 || board[humanTurn] != 0)
                {
                    Console.WriteLine("Please enter a number from 0 to 8");
                    humanTurn = int.Parse(Console.ReadLine());
                    Console.WriteLine("You typed " + humanTurn);
                }
                board[humanTurn] = 1;

                while (computerTurn == -1 || board[computerTurn] != 0)
                {
                    computerTurn = rand.Next(8);
                    Console.WriteLine("Computer chooses " + computerTurn);
                }
                board[computerTurn] = 2;
                printBoard();
            }
            Console.WriteLine("Player " + checkForWinner() + " won the game!");
            Console.ReadKey();
        }

        private static int checkForWinner()
        {
            // top row
            if (board[0] == board[1] && board[1] == board[2])
            {
                return board[0];
            }
            // second row
            if (board[3] == board[4] && board[4] == board[5])
            {
                return board[3];
            }
            //third row
            if (board[6] == board[7] && board[7] == board[8])
            {
                return board[6];
            }
            //first column
            if (board[0] == board[3] && board[3] == board[6])
            {
                return board[0];
            }
            //second columen
            if (board[1] == board[4] && board[4] == board[7])
            {
                return board[1];
            }
            //third column
            if (board[2] == board[5] && board[5] == board[8])
            {
                return board[2];
            }
            //first diagonal
            if (board[0] == board[4] && board[4] == board[8])
            {
                return board[0];
            }
            //second diagonal
            if (board[2] == board[4] && board[4] == board[6])
            {
                return board[2];
            }

            return 0;
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
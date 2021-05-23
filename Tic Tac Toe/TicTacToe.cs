using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class TicTacToe
    {
        // Main game loop
        public void run()
        {
            // Main game loop.
            while (true)
            {
                // Set up
                Board board = new Board();
                Console.WriteLine();

                board.print();
                Console.WriteLine();

                // Main game loop
                while (true)
                {
                    board.getXInput();
                    Console.WriteLine();

                    board.print();
                    Console.WriteLine();

                    if(board.GameOver)
                    {
                        Console.WriteLine("X wins!");
                        Console.WriteLine();
                        break;
                    }

                    board.getOInput();
                    Console.WriteLine();

                    board.print();
                    Console.WriteLine();

                    if (board.GameOver)
                    {
                        Console.WriteLine("O wins!");
                        Console.WriteLine();
                        break;
                    }
                }

                // Play again?  (If yes, create a new board.)
                Console.WriteLine("GAME OVER! Play again?");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
                string inputString;
                bool inputIsValid = false;
                int input;

                while (!inputIsValid)
                {
                    Console.Write("Input Selection: ");
                    inputString = Console.ReadLine();
                    if (Int32.TryParse(inputString, out input))
                    {
                        switch (input)
                        {
                            case 1:
                                inputIsValid = true;
                                break;
                            case 2:
                                inputIsValid = true;
                                Console.WriteLine("Thanks for playing!");
                                return;
                            default:
                                Console.WriteLine("Error: Input is not a valid option. Try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Input is not a valid integer. Try again.");
                    }
                }
            }
        }
    }
}

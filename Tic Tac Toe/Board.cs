using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        enum Player { HUMAN, COMPUTER };
        enum State { EMPTY, X, O };

        private State[] boardArray = new State[9];
        private Player firstPlayer;
        private bool gameOver;
        //private State winner;

        public bool GameOver
        {
            get { return gameOver; }
            set { this.gameOver = value; }
        }

        public Board()
        {
            // Initialize all values to empty.
            for(int i = 0; i < 9; i++)
            {
                boardArray[i] = State.EMPTY;
            }

            this.getFirstPlayer();

            this.gameOver = false;
            //this.winner = State.EMPTY;
        }

        public void getXInput()
        {
            // If first player (X) is human...
            if(firstPlayer == Player.HUMAN)
            {
                this.getPlayerInput(State.X);
            }
            // If first player is a computer...
            else
            {
                this.getComputerInput(State.X);
            }

            // Check for win.
            this.checkWin(State.X);
        }

        public void getOInput()
        {
            // If first player (X) is the computer...
            if (firstPlayer == Player.COMPUTER)
            {
                this.getPlayerInput(State.O);
            }
            // If first player is a human...
            else
            {
                this.getComputerInput(State.O);
            }

            // Check for win.
            this.checkWin(State.O);
        }

        private void getPlayerInput(State state)
        {
            Console.Write("Input target column (1-3): ");
            int targetColumn = getTarget() - 1;

            Console.Write("Input target row (1-3): ");
            int targetRow = getTarget() - 1;

            // Set target to the input state.
            boardArray[targetColumn + (targetRow * 3)] = state;
        }

        private int getTarget()
        {
            string inputString;
            bool inputIsValid = false;
            int input;

            while (!inputIsValid)
            {
                inputString = Console.ReadLine();
                if (Int32.TryParse(inputString, out input))
                {
                    switch (input)
                    {
                        case 1:
                        case 2:
                        case 3:
                            return input;
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

            return 0;
        }

        private void getComputerInput(State state)
        {
            // For now, just fill in the first empty spot starting from the top left.
            for (int i = 0; i < 9; i++)
            {
                if (boardArray[i] == State.EMPTY)
                {
                    boardArray[i] = state;
                    break;
                }
            }
        }

        private void checkWin(State state)
        {
            // There are only eight ways to win.

            // Fill a row (3 ways), fill a column (3 ways), fill a diagonal (2 ways)
            if (
                (boardArray[0] == state && boardArray[1] == state && boardArray[2] == state) ||
                (boardArray[3] == state && boardArray[4] == state && boardArray[5] == state) ||
                (boardArray[6] == state && boardArray[7] == state && boardArray[8] == state) ||

                (boardArray[0] == state && boardArray[3] == state && boardArray[6] == state) ||
                (boardArray[1] == state && boardArray[4] == state && boardArray[7] == state) ||
                (boardArray[2] == state && boardArray[5] == state && boardArray[8] == state) ||

                (boardArray[0] == state && boardArray[4] == state && boardArray[8] == state) ||
                (boardArray[2] == state && boardArray[4] == state && boardArray[6] == state))
                this.gameOver = true;

        }

        private void getFirstPlayer()
        {
            Console.WriteLine("Who will go first? (Note: First player is X.)");
            Console.WriteLine("1 - Human");
            Console.WriteLine("2 - Computer");

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
                            this.firstPlayer = Player.HUMAN;
                            inputIsValid = true;
                            break;
                        case 2:
                            this.firstPlayer = Player.COMPUTER;
                            inputIsValid = true;
                            break;
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

            Console.WriteLine("Understood. " + this.firstPlayer + " will go first.");
        }

        public void print()
        {
            printLine(1);
            printLineBorder();
            printLine(2);
            printLineBorder();
            printLine(3);
        }

        private void printLine(int line)
        {
            int lineAdder = (line - 1) * 3;

            for (int i = 0 + lineAdder; i < 3 + lineAdder; i++)
            {
                Console.Write("\t");

                //Console.Write(arr[i]);
                switch(boardArray[i])
                {
                    case State.EMPTY:
                        Console.Write(" ");
                        break;
                    case State.X:
                        Console.Write("X");
                        break;
                    case State.O:
                        Console.Write("O");
                        break;
                }

                if (i < 2 + lineAdder)
                    Console.Write("\t|");
            }

            Console.WriteLine();
        }

        private void printLineBorder()
        {
            Console.Write("\t----------------------------------");
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Figgle;

namespace Battleship2.Models
{
    public class GameManager
    {
        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("                                  Let's Play                           ");
            Console.WriteLine();
            Console.WriteLine(FiggleFonts.CyberLarge.Render("BATTLESHIP"));
            Console.WriteLine();
            Console.WriteLine("(1) Play Game with 20 turns (Hard Mode - You can have 3 wrong guesses)");
            Console.WriteLine("(2) Play Game with 30 turns (Moderate Mode - You can have 13 wrong guesses)");
            Console.WriteLine("(3) Play Game with 40 turns (Easy Mode - You can have 23 wrong guesses)");
            Console.WriteLine("(4) Exit");
            Console.WriteLine();
            Console.WriteLine("Would you like to play on Hard(Select 1), Moderate(Select 2), or Easy(Select 3): ");
            Console.WriteLine();
        }

        public string[,] PlayGrid()
        {
            int rows = 9;
            int columns = 9;

            string[,] board = new string[rows, columns];  // 2 Dimensional Array

            int uBound0 = board.GetUpperBound(0);
            int uBound1 = board.GetUpperBound(1);
            for (int i = 0; i <= uBound0; i++)
            {
                for (int j = 0; j <= uBound1; j++)
                {
                    board[i, j] = " * ";
                }
            }
            board[0, 0] = "   ";
            board[0, 1] = " 1 ";
            board[0, 2] = " 2 ";
            board[0, 3] = " 3 ";
            board[0, 4] = " 4 ";
            board[0, 5] = " 5 ";
            board[0, 6] = " 6 ";
            board[0, 7] = " 7 ";
            board[0, 8] = " 8 ";
            board[1, 0] = " A ";
            board[2, 0] = " B ";
            board[3, 0] = " C ";
            board[4, 0] = " D ";
            board[5, 0] = " E ";
            board[6, 0] = " F ";
            board[7, 0] = " G ";
            board[8, 0] = " H ";

            return board;
        }

        public string[,] PlayGridBadGuesses()
        {
            int rows = 9;
            int columns = 9;

            string[,] board = new string[rows, columns];  // 2 Dimensional Array

            int uBound0 = board.GetUpperBound(0);
            int uBound1 = board.GetUpperBound(1);
            for (int i = 0; i <= uBound0; i++)
            {
                for (int j = 0; j <= uBound1; j++)
                {
                    board[i, j] = " X ";
                }
            }
            board[0, 0] = "   ";
            board[0, 1] = " 1 ";
            board[0, 2] = " 2 ";
            board[0, 3] = " 3 ";
            board[0, 4] = " 4 ";
            board[0, 5] = " 5 ";
            board[0, 6] = " 6 ";
            board[0, 7] = " 7 ";
            board[0, 8] = " 8 ";
            board[1, 0] = " A ";
            board[2, 0] = " B ";
            board[3, 0] = " C ";
            board[4, 0] = " D ";
            board[5, 0] = " E ";
            board[6, 0] = " F ";
            board[7, 0] = " G ";
            board[8, 0] = " H ";

            return board;
        }

        public void Run()
        {
            while (true)
            {
                Grid grid = new Grid();
                string[,] Board = grid.PlaceShips();                //actual board
                string[,] playBoard = PlayGrid();                   //what the user sees
                string[,] playBoardBadGuess = PlayGridBadGuesses(); //grid of X's

                //These are needed to keep track of guesses and if a boat was sunk
                int B = 0;
                int C = 0;
                int S = 0;
                int R = 0;
                int D = 0;
                int wrongGuesses = 0;
                int rightGuesses = 0;
                int loopTimes = 0;
                int wrongGuessMatch = 0;


                DisplayMainMenu();
                string selection = Console.ReadLine();
                if (selection == "1") //determine how many times the run method loops and how many times the player can be wrong
                {
                    loopTimes = 20;
                    wrongGuessMatch = 4;
                }
                else if (selection == "2")
                {
                    loopTimes = 30;
                    wrongGuessMatch = 14;
                }
                else if (selection == "3")
                {
                    loopTimes = 40;
                    wrongGuessMatch = 24;
                }
                else
                {
                    Console.WriteLine("Thanks for playing!");
                    return;
                }

                for (int i = 1; i <= loopTimes; i++)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        grid.DisplayGrid(playBoard); //display the board for user
                        if((wrongGuessMatch - 1) - wrongGuesses > 0)
                        {
                            Console.WriteLine($"You have {(wrongGuessMatch - 1) - wrongGuesses} wrong guesses left. Use them wisely!");
                        }
                        else
                        {
                            Console.WriteLine("DON'T MESS UP! Only 1 more wrong guess!");
                        }
                        Console.WriteLine();
                        Console.WriteLine("GUESS: ");

                        string guess = Console.ReadLine().ToUpper(); //e.g. A1
                        if (guess.Length != 2)
                        {
                            Console.WriteLine("Your response must be a letter and a number (e.g. A1). Press Enter To Try again.");
                            Console.ReadLine();
                            continue;
                        }

                        string guessLet = guess.Substring(0, 1); //A
                        string guessNum = guess.Substring(1, 1); //1


                        string letToNum = PossibleGuesses[guessLet]; //1
                        int letToNum1 = int.Parse(letToNum);
                        int guessNum1 = int.Parse(guessNum);
                        playBoard[letToNum1, guessNum1] = Board[letToNum1, guessNum1]; //assign the user board the value from the actual board
                        if (playBoard[letToNum1, guessNum1] == " * ") //if it's a *, they missed
                        {
                            wrongGuesses++; //add to wrongGuesses count
                            playBoard[letToNum1, guessNum1] = playBoardBadGuess[letToNum1, guessNum1]; //change value to an X
                            if (wrongGuesses == wrongGuessMatch) //You lose if you have over 3 wrong guesses
                            {
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(FiggleFonts.BigChief.Render("You Lose!"));
                                Console.WriteLine("Press Enter to see where all the ships were hiding.");
                                Console.ReadLine();
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;

                                grid.DisplayGrid(Board);
                                Console.WriteLine("Press enter to play again!");
                                Console.ReadLine();
                                break;
                            }
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine(FiggleFonts.Bell.Render("You Missed!"));
                            Console.WriteLine("Press Enter to Guess Again. ");
                        }
                        else //if actual board is NOT a *
                        {
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;

                            switch (playBoard[letToNum1, guessNum1]) //add 1 to the assigned variable so we can keep track of when the ship is sunk
                            {
                                case " B ":
                                    B++;
                                    break;
                                case " S ":
                                    S++;
                                    break;
                                case " R ":
                                    R++;
                                    break;
                                case " D ":
                                    D++;
                                    break;
                                case " C ":
                                    C++;
                                    break;
                            }

                            if (B == 4)
                            {
                                Console.WriteLine(FiggleFonts.Big.Render("You sank my BattleShip!!"));
                                B--; //take one away from variable so it only shows that one time
                            }
                            else if (S == 3)
                            {
                                Console.WriteLine(FiggleFonts.Big.Render("You sank my Submarine!!"));
                                S--;
                            }
                            else if (R == 3)
                            {
                                Console.WriteLine(FiggleFonts.Big.Render("You sank my Cruiser!!"));
                                R--;
                            }
                            else if (D == 2)
                            {
                                Console.WriteLine(FiggleFonts.Big.Render("You sank my Destroyer!!"));
                                D--;
                            }
                            else if (C == 5)
                            {
                                Console.WriteLine(FiggleFonts.Big.Render("You sank my Carrier!!"));
                                C--;
                            }
                            else
                            {
                                if (rightGuesses == 17)
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine(FiggleFonts.Bell.Render("You Hit Me!"));
                                }
                            }
                            rightGuesses++; //add one to rightguesses - it only takes 17 to win
                                if (rightGuesses == 17)
                                {
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;

                                Console.WriteLine(FiggleFonts.Ivrit.Render("YOU WIN!"));
                                Console.WriteLine("CONGRATS ON BEATING THE COMPUTER!");
                                Console.WriteLine("Press Enter to Play Again");
                                    Console.ReadLine();
                                    break;
                                }
                                Console.WriteLine("Press Enter to Guess Again. ");
                        }
                        Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine("Your response must be a letter (between A-H) and a number (between 1-8). Press Enter To Try again.");
                        Console.ReadLine();
                    }
                }


            }

        }

        private Dictionary<string, string> PossibleGuesses = new Dictionary<string, string>()
        {
            {"A", "1" },
            {"B", "2" },
            {"C", "3" },
            {"D", "4" },
            {"E", "5" },
            {"F", "6" },
            {"G", "7" },
            {"H", "8" }
        };


    }
}

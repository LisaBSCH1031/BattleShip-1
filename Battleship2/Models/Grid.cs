using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship2.Models
{
    public class Grid
    {
        public string[,] PlaceShips() //IT WORKS!!!!!!
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

            List<Ship> ships = new List<Ship>() //list of ships (5)
            {
            new Carrier(),
            new BattleShip(),
            new Cruiser(),
            new SubMarine(),
            new Destroyer(),
            };

            Random rnd = new Random();
            foreach (Ship s in ships)
            {
                string value1 = s.Label(); //hold the value of the ship - e.g. D, B, C...

                int i1 = rnd.Next(1, s.Max()); //generate random numbers in 2D array for starting point
                int i2 = rnd.Next(1, s.Max());

                int i1save = i1; //save starting point
                int i2save = i2;
                bool orientation = RandomOrientation(); //horizontal(true) or vertical(false)

                if (orientation == true) //                                              &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                {
                    for (int x = 1; x < s.LengthOfShip(); x++) //loop through for length of ship
                    {
                        if (board[i1, i2] == " * ") //check starting point - if *, move on
                        {
                            i2++; //add one to the columns
                            if (board[i1, i2] == " * ") //check if *
                            {
                                continue; //if *, continue with the loop
                            }
                            else
                            {
                                i1 = rnd.Next(1, s.Max()); //if not *, generate new starting point
                                i2 = rnd.Next(1, s.Max());
                                i1save = i1; //resave starting point
                                i2save = i2;
                                x = 0; //start the loop over
                                continue; //continue with loop
                            }
                        }
                        else
                        {
                            i1 = rnd.Next(1, s.Max()); //if starting point not *, generate new starting point
                            i2 = rnd.Next(1, s.Max());
                            i1save = i1; //resave starting point
                            i2save = i2;
                            x = 0; //start the loop over
                            continue; //continue with loop
                        }
                    }
                }
                else
                {
                    for (int x = 1; x < s.LengthOfShip(); x++) //loop through for length of ship
                    {
                        if (board[i1, i2] == " * ") //check starting point - if *, move on
                        {
                            i1++; //add one to the columns
                            if (board[i1, i2] == " * ") //check if *
                            {
                                continue; //if *, continue with the loop
                            }
                            else
                            {
                                i1 = rnd.Next(1, s.Max()); //if not *, generate new starting point
                                i2 = rnd.Next(1, s.Max());
                                i1save = i1; //resave starting point
                                i2save = i2;
                                x = 0; //start the loop over
                                continue; //continue with loop
                            }
                        }
                        else
                        {
                            i1 = rnd.Next(1, s.Max()); //if starting point not *, generate new starting point
                            i2 = rnd.Next(1, s.Max());
                            i1save = i1; //resave starting point
                            i2save = i2;
                            x = 0; //start the loop over
                            continue; //continue with loop
                        }
                    }

                }                                                                   //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                board[i1save, i2save] = value1; //all cells have been checked now, use the saved starting point and assign value

                if (orientation == true)
                {
                    for (int x = 1; x < s.LengthOfShip(); x++) //loop through for length of ship
                    {
                        i2save++;
                        board[i1save, i2save] = value1;
                    }
                }
                else
                {
                    for (int x = 1; x < s.LengthOfShip(); x++) //loop through for length of ship
                    {
                        i1save++;
                        board[i1save, i2save] = value1;
                    }
                }
            }
            return board;
        }

        public bool RandomOrientation()
        {
            Random rnd = new Random();
            int i3 = rnd.Next(0, 2);
            if (i3 == 1)
            {
                return true; //HORIZONTAL
            }
            return false; //VERTICAL
        }



        public void DisplayGrid(string[,] arr)
        {
            Console.Clear();
            string res;
            int uBound0 = arr.GetUpperBound(0); //Gets highest index for 2d array at index 0
            int uBound1 = arr.GetUpperBound(1); //Gets highest index for 2d array at index 1
            for (int i = 0; i <= uBound0; i++)
            {
                for (int j = 0; j <= uBound1; j++)
                {
                    res = arr[i, j];
                    Console.Write(string.Format("{0} ", res));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public string[,] PlayGrid() //show grid of just stars
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
            board[0, 1] = " 0 ";
            board[0, 2] = " 1 ";
            board[0, 3] = " 2 ";
            board[0, 4] = " 3 ";
            board[0, 5] = " 4 ";
            board[0, 6] = " 5 ";
            board[0, 7] = " 6 ";
            board[0, 8] = " 7 ";
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

    }
}

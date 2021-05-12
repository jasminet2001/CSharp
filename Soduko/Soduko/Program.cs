using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku s = new Sudoku();
            bool stop = false;

            while (!stop)
            {
                Console.WriteLine("Add: 1, Delete:2, Print: 3, Exit: 4");
                int n = int.Parse(Console.ReadLine());

                if (n == 1)
                {
                    s.Add();
                    Console.WriteLine("After adding numbers: ");
                    s.printBoard();
                    continue;
                }
                if (n == 2)
                {
                    s.Delete();
                    Console.WriteLine("After deleting number: ");
                    s.printBoard();
                    continue;
                }
                if (n == 3)
                {
                    s.printBoard();
                    continue;
                }
                if (n == 4)
                {
                    stop = true;
                    break;
                }
            }
        }
    }

    class Sudoku
    {
        public int[,] Board = new int[,]
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        public Sudoku() { }

        //adding to the Board
        public void Add()
        {
            Console.Write("Enter row: ");
            int Row = int.Parse(Console.ReadLine());

            Console.Write("Enter column: ");
            int Col = int.Parse(Console.ReadLine());

            Console.Write("Enter number: ");
            int Num = int.Parse(Console.ReadLine());

            Solve(Row, Col, Num);
        }

        //deletes a number
        public void Delete()
        {
            Console.Write("Enter row: ");
            int Row = int.Parse(Console.ReadLine());

            Console.Write("Enter column: ");
            int Col = int.Parse(Console.ReadLine());

            Board[Row-1, Col-1] = 0;
        }

        private void Solve(int row, int col, int num)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (i == row-1 && j == col-1 && Board[row-1,col-1]==0)
                    {
                        //change this part
                        if (isValid(i, j, num))
                        {
                            Board[i, j] = num;
                            return;

                            //do i need these?
                            //if (Solve(Board, row, col, num))
                            //    return true;
                            //else
                            //    Board[i, j] = 0;
                        }
                    }
                }
            }
        }

        private bool isValid(int row, int col, int c)
        {
            for (int i = 0; i < 9; i++)
            {
                //check row  
                if (Board[i, col] != 0 && Board[i, col] == c)
                    return false;
                //check column  
                if (Board[row, i] != 0 && Board[row, i] == c)
                    return false;
                //check 3*3 block  
                if (Board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != 0 && 
                    Board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c)
                    return false;
            }
            return true;
        }

        //print function
        public void printBoard()
        {
            Console.WriteLine("+-----+-----+-----+-----+-----+-----+");

            for (int i = 1; i < 10; ++i)
            {
                for (int j = 1; j < 10; ++j)
                    Console.Write(" | {0}", Board[i - 1, j - 1]);
                    Console.WriteLine();

                Console.WriteLine(" | ");
                if (i % 3 == 0) Console.WriteLine("+-----+-----+-----+-----+-----+-----+");
            }
        }
    }
}

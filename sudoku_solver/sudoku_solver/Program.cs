using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_solver
{
    class Program
    {
        public static bool isSafe(int[,] board, int row, int col, int num)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[row, i] == num) 
                    return false;

            
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[i, col] == num) 
                    return false;

            
            int squareroot = (int)Math.Sqrt(board.GetLength(0));
            int rowStart = row - row % squareroot;
            int colStart = col - col % squareroot;

            for (int i = rowStart; i < rowStart + squareroot; i++)
                for (int j = colStart; j < colStart + squareroot; j++)
                    if (board[i, j] == num)
                        return false; 

            
            return true;
        }

        public static bool box(int[,] board, int n)
        {
            int row = 0;
            int col = 0;

            bool isEmpty = true; 

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) 
                {
                    if (board[i, j] == 0) 
                    {
                        row = i; 
                        col = j; 

                        

                        isEmpty = false; 
                        break;
                    }
                }
                if (!isEmpty) 
                {
                    break;
                }
            }

            
            if (isEmpty) 
            {
                return true;
            }


            for (int num = 1; num <= n; num++)
            {
                if (isSafe(board, row, col, num)) 
                {
                    board[row, col] = num; 
                    if (box(board, n)) 
                    {
                        return true;
                    }
                    else
                    {
                        board[row, col] = 0; 
                    }
                }
            }
            return false;
        }

        public static void print(int[,] board, int N)
        {
            
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(" ");
                }
                Console.Write("\n");

                if ((i + 1) % (int)Math.Sqrt(N) == 0)
                {
                    Console.Write("");
                }
            }
        }

        public static void Main(String[] args)
        {

            int[,] board = new int[,] 
            {
            {8, 6, 0, 0, 1, 7, 0, 0, 0},
            {0, 0, 0, 0, 0, 6, 0, 3, 0},
            {5, 0, 2, 0, 9, 0, 1, 0, 0},
            {6, 9, 0, 2, 0, 4, 3, 5, 1},
            {4, 7, 5, 9, 0, 1, 8, 0, 6},
            {0, 0, 0, 8, 0, 5, 0, 7, 0},
            {7, 0, 6, 0, 0, 0, 0, 9, 3},
            {0, 0, 0, 0, 0, 9, 6, 0, 2},
            {0, 0, 0, 0, 5, 0, 0, 0, 0}
            };

            int N = board.GetLength(0); 

            if (box(board, N))
                print(board, N);
            else
                Console.Write("No solution");
        }
    }
}

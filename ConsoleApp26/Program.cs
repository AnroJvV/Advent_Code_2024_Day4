using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("==========================================Data Set==================================");
        string filePath = "--File Path--";
       
        var grid = ReadNumbersFromFile(filePath);

        foreach (var item in grid)
        {
            Console.Write(item);
        }
        Console.WriteLine();
        Console.WriteLine("===================================================================================");
        Console.ReadLine();

        var horizontalResult = CheckHorizontal(grid);
        var horizontalReverseResult = CheckHorizontalReversed(grid);
        var verticalResult = CheckVertical(grid);
        var verticalReverseResult = CheckVerticalReversed(grid);
        var diagonalLeftResult = CheckDiagonalLeft(grid);
        var diagonalLeftReverseResult = CheckDiagonalLeftReversed(grid);
        var diagonalRightResult = CheckDiagonalRight(grid);
        var diagonalRightReverseResult = CheckDiagonalRightReversed(grid);

        var result = horizontalResult + horizontalReverseResult + verticalResult + verticalReverseResult + diagonalLeftResult + diagonalLeftReverseResult + diagonalRightResult + diagonalRightReverseResult;

        Console.WriteLine("Total amount of XMAS: " + result);
    }

    public static char[,] ReadNumbersFromFile(string filePath)
    {

        string[] lines = File.ReadAllLines(filePath);
        char[,] grid = new char[lines.Length, 140];

        try
        {
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (int j = 0; j < 140; j++)
                {
                    grid[i, j] = line[j];
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return grid;
    }

    public static int CheckHorizontal(char[,] grid)
    {
        int xmas = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            string row = "";
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                row += grid[i, j];
            }
            xmas += FindXmas(row);
        }
        return xmas;
    }

    public static int CheckHorizontalReversed(char[,] grid)
    {
        int xmas = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            string row = "";
            for (int j = grid.GetLength(1) - 1; j >= 0; j--)
            {
                row += grid[i, j];
            }
            xmas += FindXmas(row);
        }
        return xmas;
    }

    public static int CheckVertical(char[,] grid)
    {
        int xmas = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            string row = "";
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                row += grid[j, i];
            }
            xmas += FindXmas(row);
        }
        return xmas;
    }

    public static int CheckVerticalReversed(char[,] grid)
    {
        int xmas = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            string row = "";
            for (int j = grid.GetLength(1) - 1; j >= 0; j--)
            {
                row += grid[j, i];
            }
            xmas += FindXmas(row);
        }
        return xmas;
    }

    public static int CheckDiagonalLeft(char[,] grid)
    {
        int xmas = 0;
        //Get long diagonal
        string longDiagRow = "";
        for (int i = 0; i < grid.GetLength(0); i++)
        {           
            longDiagRow += grid[i, i];            
        }
        xmas += FindXmas(longDiagRow);

        //Get Horizontal diagonal
        for (int y = 1; y < grid.GetLength(0) - 3; y++ )
        {
            string row = "";
            var coord = y;
            for (int x = 0; x <= (grid.GetLength(0) - 1) - y; x++)
            {                
                row += grid[x, coord];
                coord++;
            }
            xmas += FindXmas(row);
        }

        //Get Vertical diagonal
        for (int x = 1; x < grid.GetLength(0) - 3; x++)
        {
            string row = "";
            var coord = x;
            for (int y = 0; y <= (grid.GetLength(0) - 1) - x; y++)
            {                
                row += grid[coord,y];
                coord++;
            }
            xmas += FindXmas(row);
        }
        return xmas;
    }

    public static int CheckDiagonalLeftReversed(char[,] grid)
    {
        int xmas = 0;
        //Get long diagonal
        string longDiagRow = "";
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            longDiagRow += grid[i, i];
        }
        char[] charArray = longDiagRow.ToCharArray();
        Array.Reverse(charArray);
        string reversedLongDiagRow = new string(charArray);
        xmas += FindXmas(reversedLongDiagRow);
        

        //Get Horizontal diagonal
        for (int y = 1; y < grid.GetLength(0) - 3; y++)
        {
            string row = "";
            var coord = y;
            for (int x = 0; x <= (grid.GetLength(0) - 1) - y; x++)
            {
                row += grid[x, coord];
                coord++;
            }
            char[] charArray2 = row.ToCharArray();
            Array.Reverse(charArray2);
            string reversedRow = new string(charArray2);
            xmas += FindXmas(reversedRow);
        }

        //Get Vertical diagonal
        for (int x = 1; x < grid.GetLength(0) - 3; x++)
        {
            string row = "";
            var coord = x;
            for (int y = 0; y <= (grid.GetLength(0) - 1) - x; y++)
            {
                row += grid[coord, y];
                coord++;
            }
            char[] charArray2 = row.ToCharArray();
            Array.Reverse(charArray2);
            string reversedRow = new string(charArray2);
            xmas += FindXmas(reversedRow);
        }
        return xmas;
    }

    public static int CheckDiagonalRight(char[,] grid)
    {
        int xmas = 0;
        //Get long diagonal
        string longDiagRow = "";
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            longDiagRow += grid[i, (grid.GetLength(0) - 1) - i];          
        }
        xmas += FindXmas(longDiagRow);

        //Get Horizontal diagonal        
        for (int y = grid.GetLength(0) - 2; y >= 3; y--)
        {
            string row = "";
            var coord = y;
            for (int x = 0; x <= y; x++)
            {               
                row += grid[x, coord];
                coord--;
            }
            xmas += FindXmas(row);

        }

        //Get Vertical diagonal
        for (int x = 1; x < grid.GetLength(0) - 3; x++)
        {
            string row = "";
            var coord = x;
            for (int y = grid.GetLength(0) - 1; y >= x; y--)
            {                
                row += grid[coord, y];
                coord++;
            }
            xmas += FindXmas(row);
        }

        return xmas;               
    }

    public static int CheckDiagonalRightReversed(char[,] grid)
    {
        int xmas = 0;
        //Get long diagonal
        string longDiagRow = "";
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            longDiagRow += grid[i, (grid.GetLength(0) - 1) - i];
        }
        char[] charArray = longDiagRow.ToCharArray();
        Array.Reverse(charArray);
        string reversedLongDiagRow = new string(charArray);
        xmas += FindXmas(reversedLongDiagRow);

        //Get Horizontal diagonal        
        for (int y = grid.GetLength(0) - 2; y >= 3; y--)
        {
            string row = "";
            var coord = y;
            for (int x = 0; x <= y; x++)
            {
                row += grid[x, coord];
                coord--;
            }
            char[] charArray2 = row.ToCharArray();
            Array.Reverse(charArray2);
            string reversedRow = new string(charArray2);
            xmas += FindXmas(reversedRow);

        }

        //Get Vertical diagonal
        for (int x = 1; x < grid.GetLength(0) - 3; x++)
        {
            string row = "";
            var coord = x;
            for (int y = grid.GetLength(0) - 1; y >= x; y--)
            {
                row += grid[coord, y];
                coord++;
            }
            char[] charArray2 = row.ToCharArray();
            Array.Reverse(charArray2);
            string reversedRow = new string(charArray2);
            xmas += FindXmas(reversedRow);
        }

        return xmas;
    }  

    public static int FindXmas(string row)
    {
        string word = "XMAS";

        
        int count = Regex.Matches(row,Regex.Escape(word)).Count;

        return count;
    }

}
    
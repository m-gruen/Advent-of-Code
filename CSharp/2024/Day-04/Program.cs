// Advent of Code 2024 Day 4

using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

var lines = File.ReadAllLines("input-short.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    var grid = makeGrid(lines);
    var directions = getDirection();
    int rows = grid.GetLength(0);
    int cols = grid.GetLength(1);

    var XmasCount = 0;
    string word = "XMAS";

    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            if (grid[r, c] == 'X')
            {
                foreach (var (dr, dc) in directions)
                {
                    int rd = r, cd = c, k;
                    for (k = 0; k < word.Length; k++)
                    {
                        if (rd < 0 || rd >= rows || cd < 0 || cd >= cols || grid[rd, cd] != word[k]) { break; }
                        rd += dr;
                        cd += dc;
                    }
                    if (k == word.Length) { XmasCount++; }
                }
            }
        }
    }

    return XmasCount;
}

int Part2(string[] lines)
{
    var grid = makeGrid(lines);
    (int, int)[] directions = [
        (-1, -1),
        (-1, 1),
        (1, -1),
        (1, 1)
    ];

    int rows = grid.GetLength(0);
    int cols = grid.GetLength(1);

    var XmasCount = 0;

    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            if (grid[r, c] == 'A')
            {
                var mCount = 0;
                var sCount = 0;
                var sPosition = new List<(int, int)>();
                var mPosition = new List<(int, int)>();

                foreach (var (dr, dc) in directions)
                {
                    int rd = r, cd = c;

                    if (rd < 0 || rd >= rows || cd < 0 || cd >= cols) { break; }
                    if (grid[rd, cd] == 'M')
                    {
                        mCount++;
                        mPosition.Add((rd, cd));
                    }
                    if (grid[rd, cd] == 'S')
                    {
                        sCount++;
                        sPosition.Add((rd, cd));
                    }
                    rd += dr;
                    cd += dc;
                }

                if (mCount == 2 && sCount == 2)
                {
                    XmasCount++;
                }
            }
        }
    }

    return XmasCount;
}

char[,] makeGrid(string[] lines)
{
    char[,] grid = new char[lines.Length, lines[0].Length];
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            grid[i, j] = lines[i][j];
        }
    }
    return grid;
}

(int, int)[] getDirection()
{
    return [
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, -1),
        (0, 1),
        (1, -1),
        (1, 0),
        (1, 1)
    ];
}
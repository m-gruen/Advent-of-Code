// Advent of Code 2024 Day 4

using System.Globalization;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    char[,] grid = new char[lines.Length, lines[0].Length];
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            grid[i, j] = lines[i][j];
        }
    }

    int rows = grid.GetLength(0);
    int cols = grid.GetLength(1);
    var XmasCount = 0;
    string word = "XMAS";
    (int, int)[] directions =
    [
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, -1),
        (0, 1),
        (1, -1),
        (1, 0),
        (1, 1)
    ];

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
    return 0;
}
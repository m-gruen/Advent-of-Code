// Advent of Code 2024 Day 6


var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    var grid = makeGrid(lines);
    var exited = false;
    while (!exited)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '^')
                {
                    exited = MoveUp(grid, i, j);
                }
                else if (grid[i][j] == 'v')
                {
                    exited = MoveDown(grid, i, j);
                }
                else if (grid[i][j] == '<')
                {
                    exited = MoveLeft(grid, i, j);
                }
                else if (grid[i][j] == '>')
                {
                    exited = MoveRight(grid, i, j);
                }

                if (exited) { break; }
            }
            if (exited) { break; }
        }
    }

    return grid.SelectMany(row => row).Count(c => c == 'X') + 1;
}

int Part2(string[] lines)
{
    return 0;
}

char[][] makeGrid(string[] lines) => lines.Select(line => line.ToCharArray()).ToArray();

bool isInside(char[][] grid, int i, int j) => i >= 0 && i < grid.Length && j >= 0 && j < grid[0].Length;

bool MoveUp(char[][] grid, int i, int j)
{
    if (!isInside(grid, i - 1, j) || grid[i - 1][j] == '#')
    {
        grid[i][j] = '>';
    }
    else
    {
        grid[i - 1][j] = '^';
        grid[i][j] = 'X';
    }
    return !isInside(grid, i - 1, j);
}

bool MoveDown(char[][] grid, int i, int j)
{
    if (!isInside(grid, i + 1, j) || grid[i + 1][j] == '#')
    {
        grid[i][j] = '<';
    }
    else
    {
        grid[i + 1][j] = 'v';
        grid[i][j] = 'X';
    }
    return !isInside(grid, i + 1, j);
}

bool MoveLeft(char[][] grid, int i, int j)
{
    if (!isInside(grid, i, j - 1) || grid[i][j - 1] == '#')
    {
        grid[i][j] = '^';
    }
    else
    {
        grid[i][j - 1] = '<';
        grid[i][j] = 'X';
    }
    return !isInside(grid, i, j - 1);
}

bool MoveRight(char[][] grid, int i, int j)
{
    if (!isInside(grid, i, j + 1) || grid[i][j + 1] == '#')
    {
        grid[i][j] = 'v';
    }
    else
    {
        grid[i][j + 1] = '>';
        grid[i][j] = 'X';
    }
    return !isInside(grid, i, j + 1);
}

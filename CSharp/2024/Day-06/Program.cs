// Advent of Code 2024 Day 6

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    var grid = makeGrid(lines);
    var visited = new HashSet<(int, int)>();
    var pos = GetStartingPos(grid);

    while (isInside(grid, pos.Item1, pos.Item2))
    {
        visited.Add(pos);
        var nextPos = Direction.GetNextPos(pos.Item1, pos.Item2);
        if (!isInside(grid, nextPos.Item1, nextPos.Item2)) { break; }
        else if (grid[nextPos.Item1][nextPos.Item2] == '#') { Direction.ChangeDir(); }
        else { pos = nextPos; }
    }

    return visited.Count;
}

int Part2(string[] lines)
{
    var grid = makeGrid(lines);
    var start = GetStartingPos(grid);

    var loopCount = 0;

    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            if (grid[i][j] != '^')
            {
                var temp = grid[i][j];
                grid[i][j] = '#';

                var visited = new HashSet<(int, int, Dir)>();
                var pos = (start.Item1, start.Item2, Dir.Up);
                Direction.currentDir = Dir.Up;

                while (isInside(grid, pos.Item1, pos.Item2))
                {
                    if (visited.Contains(pos)) { loopCount++; break; }
                    visited.Add(pos);
                    var nextPos = Direction.GetNextPosAndDir(pos.Item1, pos.Item2);
                    if (!isInside(grid, nextPos.Item1, nextPos.Item2)) { break; }
                    else if (grid[nextPos.Item1][nextPos.Item2] == '#') 
                    { 
                        Direction.ChangeDir(); 
                        pos = (pos.Item1, pos.Item2, Direction.currentDir);
                    }
                    else { pos = nextPos; }
                }

                grid[i][j] = temp;
            }
        }
    }

    return loopCount;
}

char[][] makeGrid(string[] lines) => lines.Select(line => line.ToCharArray()).ToArray();

bool isInside(char[][] grid, int i, int j) => i >= 0 && i < grid.Length && j >= 0 && j < grid[0].Length;

(int, int) GetStartingPos(char[][] grid)
{
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            if (grid[i][j] == '^') { return (i, j); }
        }
    }

    return (0, 0);
}

class Direction
{
    public static Dir currentDir = Dir.Up;
    public static (int, int) GetNextPos(int i, int j)
    {
        return currentDir switch
        {
            Dir.Up => (i - 1, j),
            Dir.Down => (i + 1, j),
            Dir.Left => (i, j - 1),
            Dir.Right => (i, j + 1),
            _ => (0, 0),
        };
    }

    public static (int, int, Dir) GetNextPosAndDir(int i, int j)
    {
        return currentDir switch
        {
            Dir.Up => (i - 1, j, Dir.Up),
            Dir.Down => (i + 1, j, Dir.Down),
            Dir.Left => (i, j - 1, Dir.Left),
            Dir.Right => (i, j + 1, Dir.Right),
            _ => (0, 0, Dir.Up),
        };
    }

    public static void ChangeDir()
    {
        currentDir = currentDir switch
        {
            Dir.Up => Dir.Right,
            Dir.Right => Dir.Down,
            Dir.Down => Dir.Left,
            Dir.Left => Dir.Up,
            _ => Dir.Up,
        };
    }
}

enum Dir
{
    Up,
    Down,
    Left,
    Right
}

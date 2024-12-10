// Advent of Code 2024 Day 10

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    var grid = MakeGrid(lines);
    var startingPoints = GetAllStartingPoints(grid);
    var count = 0;

    foreach (var (x, y) in startingPoints)
    {
        HashSet<(int, int)> visited = [];
        Queue<(int, int)> queue = [];
        queue.Enqueue((x, y));

        while (queue.Count > 0)
        {
            var (i, j) = queue.Dequeue();

            if (!visited.Contains((i, j)))
            {
                visited.Add((i, j));

                if (grid[i][j] == 9)
                {
                    count++;
                }
                else
                {
                    CheckDirections(grid, queue, i, j);
                }
            }
        }
    }

    return count;
}

int Part2(string[] lines)
{
    var grid = MakeGrid(lines);
    var count = 0;

    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] == 0)
            {
                int nineCount = 0;
                FindPaths(grid, i, j, ref nineCount);
                count += nineCount;
            }
        }
    }

    return count;
}

int[][] MakeGrid(string[] lines) => [.. lines.Select(line => line.Select(c => c - '0').ToArray())];

List<(int, int)> GetAllStartingPoints(int[][] grid)
{
    List<(int, int)> startingPoints = [];
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] == 0)
            {
                startingPoints.Add((i, j));
            }
        }
    }
    return startingPoints;
}

void CheckDirections(int[][] grid, Queue<(int, int)> queue, int x, int y)
{
    if (x > 0 && grid[x - 1][y] == grid[x][y] + 1) { queue.Enqueue((x - 1, y)); }
    if (x < grid.Length - 1 && grid[x + 1][y] == grid[x][y] + 1) { queue.Enqueue((x + 1, y)); }
    if (y > 0 && grid[x][y - 1] == grid[x][y] + 1) { queue.Enqueue((x, y - 1)); }
    if (y < grid[x].Length - 1 && grid[x][y + 1] == grid[x][y] + 1) { queue.Enqueue((x, y + 1)); }
}

void FindPaths(int[][] grid, int x, int y, ref int count)
{
    if (grid[x][y] == 9)
    {
        count++;
        return;
    }

    int[][] directions = [[-1, 0], [1, 0], [0, -1], [0, 1]];
    foreach (var dir in directions)
    {
        int newX = x + dir[0];
        int newY = y + dir[1];
        if (IsInGrid(grid, newX, newY) && grid[newX][newY] == grid[x][y] + 1)
        {
            FindPaths(grid, newX, newY, ref count);
        }
    }
}

bool IsInGrid(int[][] grid, int x, int y) => x >= 0 && x < grid.Length && y >= 0 && y < grid[x].Length;

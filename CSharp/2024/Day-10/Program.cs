// Advent of Code 2024 Day 10

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    var grid = MakeGrid(lines);

    var count = 0;
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] == 0)
            {
                HashSet<(int, int)> visited = [];
                Queue<(int, int)> queue = [];
                queue.Enqueue((i, j));

                while (queue.Count > 0)
                {
                    var (x, y) = queue.Dequeue();

                    if (!visited.Contains((x, y)))
                    {
                        visited.Add((x, y));

                        if (grid[x][y] == 9)
                        {
                            count++;
                        }
                        else
                        {
                            CheckDirections(grid, queue, x, y);
                        }
                    }
                }
            }
        }
    }

    return count;
}

int Part2(string[] input)
{
    return 0;
}

int[][] MakeGrid(string[] lines) => [.. lines.Select(line => line.Select(c => c - '0').ToArray())];

void CheckDirections(int[][] grid, Queue<(int, int)> queue, int x, int y)
{
    if (x > 0 && grid[x - 1][y] == grid[x][y] + 1) { queue.Enqueue((x - 1, y)); }
    if (x < grid.Length - 1 && grid[x + 1][y] == grid[x][y] + 1) { queue.Enqueue((x + 1, y)); }
    if (y > 0 && grid[x][y - 1] == grid[x][y] + 1) { queue.Enqueue((x, y - 1)); }
    if (y < grid[x].Length - 1 && grid[x][y + 1] == grid[x][y] + 1) { queue.Enqueue((x, y + 1)); }
}

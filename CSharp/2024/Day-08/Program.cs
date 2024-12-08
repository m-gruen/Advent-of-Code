// Advent of Code 2024 Day 7

using System.Drawing;

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

long Part1(string[] lines)
{
    var grid = MakeGrid(lines);

    var visited = new HashSet<Point>();

    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] != '.')
            {
                for (int k = 0; k < grid.Length; k++)
                {
                    for (int l = 0; l < grid[k].Length; l++)
                    {
                        if (grid[k][l] == grid[i][j] && (i != k || j != l))
                        {
                            var point1 = new Point(i, j);
                            var point2 = new Point(k, l);

                            var distanceX = DistanceX(point1, point2);
                            var distanceY = DistanceY(point1, point2);

                            var pointA = new Point(point1.X + distanceX, point1.Y + distanceY);
                            if (IsInGrid(grid, pointA))
                            {
                                visited.Add(pointA);
                            }

                            var pointB = new Point(point2.X - distanceX, point2.Y - distanceY);
                            if (IsInGrid(grid, pointB) && grid[pointB.X][pointB.Y] == '.')
                            {
                                visited.Add(pointB);
                            }
                        }
                    }
                }
            }
        }
    }

    return visited.Count;
}

int Part2(string[] lines)
{
    var grid = MakeGrid(lines);

    var visited = new HashSet<Point>();

    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] != '.')
            {
                for (int k = 0; k < grid.Length; k++)
                {
                    for (int l = 0; l < grid[k].Length; l++)
                    {
                        if (grid[k][l] == grid[i][j] && (i != k || j != l))
                        {
                            var point1 = new Point(i, j);
                            var point2 = new Point(k, l);
                            visited.Add(point1);
                            visited.Add(point2);

                            var distanceX = DistanceX(point1, point2);
                            var distanceY = DistanceY(point1, point2);

                            var pointA = new Point(point1.X + distanceX, point1.Y + distanceY);
                            while (IsInGrid(grid, pointA))
                            {
                                visited.Add(pointA);
                                pointA = new Point(pointA.X + distanceX, pointA.Y + distanceY);
                            }

                            var pointB = new Point(point2.X - distanceX, point2.Y - distanceY);
                            while (IsInGrid(grid, pointB) && grid[pointB.X][pointB.Y] == '.')
                            {
                                visited.Add(pointB);
                                pointB = new Point(pointB.X - distanceX, pointB.Y - distanceY);
                            }
                        }
                    }
                }
            }
        }
    }

    return visited.Count;
}

char[][] MakeGrid(string[] lines) => [.. lines.Select(line => line.ToCharArray())];

int DistanceX(Point point1, Point point2) => point1.X - point2.X;
int DistanceY(Point point1, Point point2) => point1.Y - point2.Y;

bool IsInGrid(char[][] grid, Point point) => point.X >= 0 && point.X < grid.Length && point.Y >= 0 && point.Y < grid[0].Length;
record Point(int X, int Y);
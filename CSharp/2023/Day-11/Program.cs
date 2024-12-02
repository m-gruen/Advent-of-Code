// AoC 2023 Day 11

var lines = File.ReadAllLines("data.txt");

Console.WriteLine($"Part 1: {Part1(lines)}");
Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    List<Row> emptyRows = [];
    List<Column> emptyColumns = [];
    List<Point> points = [];

    FindEmptyRowsAndColumn(lines, emptyRows, emptyColumns);
    FindAllPoints(lines, points);

        foreach(var p in points)
    {
        System.Console.WriteLine($"{p.X},{p.Y}");
    }

    return CalculateDistance(points, emptyRows, emptyColumns, 2);
}

int Part2(string[] lines)
{
    List<Row> emptyRows = [];
    List<Column> emptyColumns = [];
    List<Point> points = [];

    FindEmptyRowsAndColumn(lines, emptyRows, emptyColumns);
    FindAllPoints(lines, points);

    return 0;
}

void FindEmptyRowsAndColumn(string[] lines, List<Row> emptyRows, List<Column> emptyColumns)
{
    for (int i = 0; i < lines.Length; i++)
    {
        if (!lines[i].Contains('#'))
        {
            emptyRows.Add(new Row(i));
        }
    }

    for (int j = 0; j < lines[0].Length; j++)
    {
        bool isEmptyColumn = true;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i][j] == '#')
            {
                isEmptyColumn = false;
                break;
            }
        }
        if (isEmptyColumn)
        {
            emptyColumns.Add(new Column(j));
        }
    }
}

void FindAllPoints(string[] lines, List<Point> points)
{
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[0].Length; j++)
        {
            if (lines[i][j] == '#')
            {
                points.Add(new Point(i, j));
            }
        }
    }
}

int CalculateDistance(List<Point> point, List<Row> emptyRows, List<Column> emptyColumns, int multiplier)
{
    var sum = 0;

    for (int i = 0; i < point.Count; i++)
    {
        for (int j = i + 1; j < point.Count; j++)
        {
            sum += CalculateDistanceFormPointToPoint(point[i], point[j], emptyRows, emptyColumns, multiplier);
        }
    }

    return sum;
}

int CalculateDistanceFormPointToPoint(Point p1, Point p2, List<Row> emptyRows, List<Column> emptyColumns, int multiplier)
{
    var distance = 0;
    if (p1.X == p2.X && p1.Y == p2.Y)
    {
        return 0;
    }
    else if (p1.X == p2.X)
    {
        distance = Math.Abs(p1.Y - p2.Y) - 1;
        var emptyColumnsCount = emptyColumns.Count(c => c.J == p1.X);
        distance += emptyColumnsCount * multiplier;
    }
    else if (p1.Y == p2.Y)
    {
        distance = Math.Abs(p1.X - p2.X) - 1;
        var emptyRowsCount = emptyRows.Count(r => r.I == p1.Y);
        distance += emptyRowsCount * multiplier;
    }
    else
    {
        var x = Math.Abs(p1.X - p2.X) - 1;
        var y = Math.Abs(p1.Y - p2.Y) - 1;
        distance = x + y;
        var emptyRowsCount = emptyRows.Count(r => r.I >= Math.Min(p1.Y, p2.Y) && r.I <= Math.Max(p1.Y, p2.Y));
        var emptyColumnsCount = emptyColumns.Count(c => c.J >= Math.Min(p1.X, p2.X) && c.J <= Math.Max(p1.X, p2.X));
        distance += (emptyRowsCount + emptyColumnsCount) * multiplier;
    }

    System.Console.WriteLine($"Distance from {p1.X},{p1.Y} to {p2.X},{p2.Y} is {distance}");

    return distance;
}

class Point(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}

class Row(int i)
{
    public int I { get; set; } = i;
}

class Column(int j)
{
    public int J { get; set; } = j;
}

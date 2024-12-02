// Advent of Code 2024: Day 1

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    List<int> index1 = new();
    List<int> index2 = new();

    foreach (var line in lines)
    {
        var parts = line.Split("   ");

        index1.Add(int.Parse(parts[0]));
        index2.Add(int.Parse(parts[1]));
    }

    index1.Sort();
    index2.Sort();

    var sumDiff = 0;

    for (int i = 0; i < index1.Count; i++)
    {
        sumDiff += Math.Abs(index1[i] - index2[i]);
    }

    return sumDiff;
}


int Part2(string[] lines)
{
    return 0;
}

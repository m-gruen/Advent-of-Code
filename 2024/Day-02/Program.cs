// Advent of Code 2024: Day 1

using System.Linq.Expressions;

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    var countSafe = 0;

    foreach (var line in lines)
    {
        var parts = line.Split(' ').Select(int.Parse).ToArray();

        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = 1; i < parts.Length; i++)
        {
            var diff = parts[i] - parts[i - 1];

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                isIncreasing = false;
                isDecreasing = false;
                break;
            }

            if (diff < 0)
            {
                isIncreasing = false;
            }
            else if (diff > 0)
            {
                isDecreasing = false;
            }
        }

        if (isIncreasing || isDecreasing)
        {
            countSafe++;
        }
    }

    return countSafe;
}


int Part2(string[] lines)
{
    return 0;
}

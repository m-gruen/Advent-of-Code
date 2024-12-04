// Advent of Code 2024 Day 3

using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    var countMul = 0;

    foreach (var line in lines)
    {
        var matches = Regex.Matches(line, @"mul\(\d{1,3},\d{1,3}\)");

        foreach (Match match in matches)
        {
            var parts = match.Value[4..^1].Split(',').Select(int.Parse).ToArray();
            countMul += parts[0] * parts[1];
        }
    }

    return countMul;
}

int Part2(string[] lines)
{
    return 0;
}
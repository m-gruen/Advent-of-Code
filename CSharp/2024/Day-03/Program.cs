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
    var countMul = 0;
    var mulEnabled = true;

    foreach (var line in lines)
    {
        var parts = Regex.Split(line, @"(do\(\)|don't\(\))");

        foreach (var part in parts)
        {
            if (part == "do()")
            {
                mulEnabled = true;
            }
            else if (part == "don't()")
            {
                mulEnabled = false;
            }
            else if (mulEnabled)
            {
                var matches = Regex.Matches(part, @"mul\(\d{1,3},\d{1,3}\)");

                foreach (Match match in matches)
                {
                    var partsMul = match.Value[4..^1].Split(',').Select(int.Parse).ToArray();
                    countMul += partsMul[0] * partsMul[1];
                }
            };
        }
    }

    return countMul;
}
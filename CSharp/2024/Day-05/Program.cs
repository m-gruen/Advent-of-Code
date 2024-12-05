// Advent of Code 2024 Day 5

var lines = File.ReadAllText("input.txt")
    .Split("\n\n")
    .Select(l => l.Split("\n"))
    .ToArray();

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[][] lines)
{
    var rules = getRules(lines[0]);
    var numberLines = getNumberLines(lines[1]);

    return numberLines
        .Where(numberLine => IsValid(numberLine, rules))
        .Sum(numberLine => numberLine[numberLine.Length / 2]);
}

int Part2(string[][] lines)
{
    var rules = getRules(lines[0]);
    var numberLines = getNumberLines(lines[1]);

    
    return 0;
}

bool IsValid(int[] numberLine, int[][] rules)
{
    foreach (var rule in rules)
    {
        if (numberLine.Contains(rule[0]) && numberLine.Contains(rule[1]) &&
            Array.IndexOf(numberLine, rule[0]) > Array.IndexOf(numberLine, rule[1]))
        {
            return false;
        }
    }
    return true;
}

int[][] getRules(string[] lines)
{
    return [.. lines
            .Select(l => l.Split('|')
            .Select(int.Parse)
            .ToArray())];
}

int[][] getNumberLines(string[] lines)
{
    return [.. lines
            .Select(l => l.Split(',')
            .Select(int.Parse)
            .ToArray())];
}

// Advent of Code 2024 Day 5

var lines = File.ReadAllText("input.txt")
    .Split("\n\n")
    .Select(l => l.Split("\n"))
    .ToArray();

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[][] lines)
{
    var rules = lines[0].Select(l => l.Split('|').Select(int.Parse).ToArray()).ToArray();
    var numberLines = lines[1]
        .Select(l => l.Split(',')
            .Select(int.Parse)
            .ToArray())
        .ToArray();

    var count = 0;
    foreach (var numberLine in numberLines)
    {
        var valid = true;
        foreach (var rule in rules)
        {
            if (numberLine.Contains(rule[0]) && numberLine.Contains(rule[1]) &&
                Array.IndexOf(numberLine, rule[0]) > Array.IndexOf(numberLine, rule[1]))
            {
                valid = false;
                break;
            }
        }

        if (valid) { count += numberLine[numberLine.Length / 2]; }
    }

    return count;
}

int Part2(string[][] lines)
{
    return 0;
}

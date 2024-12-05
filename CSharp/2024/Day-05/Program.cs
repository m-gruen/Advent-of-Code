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

    var incorrectNumberLines = numberLines
        .Where(numberLine => !IsValid(numberLine, rules))
        .ToArray();

    var rulesDict = new Dictionary<int, HashSet<int>>();
    foreach (var rule in rules)
    {
        if (!rulesDict.TryGetValue(rule[0], out HashSet<int>? value))
        {
            value = [];
            rulesDict[rule[0]] = value;
        }

        value.Add(rule[1]);
    }

    int Compare(int a, int b)
    {
        if (rulesDict.TryGetValue(a, out HashSet<int>? value1) && value1.Contains(b)) { return -1; }
        if (rulesDict.TryGetValue(b, out HashSet<int>? value2) && value2.Contains(a)) { return 1; }
        return 0;
    }

    foreach (var incorrectNumberLine in incorrectNumberLines) { Array.Sort(incorrectNumberLine, Compare); }

    return incorrectNumberLines
        .Where(numberLine => IsValid(numberLine, rules))
        .Sum(numberLine => numberLine[numberLine.Length / 2]);
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

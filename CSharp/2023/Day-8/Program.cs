// AoC 2023 Day 8

using static System.Console;

var lines = File.ReadAllLines("message.txt");

WriteLine($"Part 1: {Part1(lines)}");
WriteLine($"Part 2: {Part2(lines)}");

string GetNewDestination(string current, char direction, string[] items)
{
    string destination;
    if (direction == 'R') { destination = current.Split(" = ")[1].Split(", ")[1].TrimEnd(')'); }
    else { destination = current.Split(" = ")[1].Split(", ")[0].TrimStart('('); }
    return items.Where(x => x.StartsWith($"{destination}")).FirstOrDefault() ?? throw new Exception("No matching destination found");
}


int Part1(string[] lines)
{
    var instructions = lines[0];
    var items = lines.Skip(2).ToArray();

    int moves = 0;
    string destination = items.Where(x => x.StartsWith("AAA")).FirstOrDefault() ?? throw new Exception("No starting destination found");
    for (int i = 0; i < instructions.Length; i++)
    {
        destination = GetNewDestination(destination, instructions[i], items);
        if (i + 1 == instructions.Length && !destination.StartsWith("ZZZ")) { instructions += instructions; }
        moves++;

        if (destination.StartsWith("ZZZ")) { break; }
    }

    return moves;
}

long Part2(string[] lines)
{
    int numberOfStarts = lines.Count(x => x.Split(" = ")[0].EndsWith("A"));
    var moves = new long[numberOfStarts];
    var instructions = lines[0];
    var items = lines.Skip(2).ToArray();

    for (int i = 0; i < numberOfStarts; i++)
    {
        int movesForThisStart = 0;
        string destination = items.Where(x => x.Split(" = ")[0].EndsWith("A")).Skip(i).FirstOrDefault() ?? throw new Exception("No starting destination found");
        for (int j = 0; j < instructions.Length; j++)
        {
            destination = GetNewDestination(destination, instructions[j], items);
            if (j + 1 == instructions.Length && !destination.Split(" = ")[0].EndsWith("Z")) { instructions += instructions; }
            movesForThisStart++;

            if (destination.Split(" = ")[0].EndsWith("Z")) { break; }
        }
        moves[i] = movesForThisStart;
    }

    foreach (var item in moves)
    {
        WriteLine(item);
    }

    return kgV(moves);
}

long Gcd(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

long Lcm(long a, long b)
{
    return (a / Gcd(a, b)) * b;
}

long kgV(long[] numbers)
{
    long result = 1;
    for (long i = 0; i < numbers.Length; i++)
    {
        result = Lcm(result, numbers[i]);
    }
    return result;
}

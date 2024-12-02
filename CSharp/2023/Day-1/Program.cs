using static System.Console;

var lines = File.ReadAllLines("input.txt");

WriteLine($"Part 1: {Part1(lines)}");
WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    int sum = 0;

    foreach (var line in lines)
    {
        int first = 0, last = 0;

        foreach (var c in line)
        {
            if (char.IsDigit(c))
            {
                if (first == 0)
                {
                    first = c - '0';
                }
                else
                {
                    last = c - '0';
                }
            }
        }

        if (last == 0) { last = first; }
        sum += (first * 10) + last;
    }

    return sum;
}

int Part2(string[] lines)
{
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i]
            .Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3h")
            .Replace("four", "f4r")
            .Replace("five", "f5v")
            .Replace("six", "s6x")
            .Replace("seven", "s7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e");

        lines[i] = line;
    }

    return Part1(lines);
}
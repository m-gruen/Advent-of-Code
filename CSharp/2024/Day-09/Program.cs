// Advent of Code 2024 Day 8

var input = File.ReadAllText("input.txt");

System.Console.WriteLine($"Part 1: {Part1(input)}");
System.Console.WriteLine($"Part 2: {Part2(input)}");

long Part1(string input)
{
    var blocks = ProcessInstructions(input);

    for (int i = blocks.Count - 1; i >= 0; i--)
    {
        if (blocks[i] != -1)
        {
            var block = blocks[i];
            blocks[i] = -1;
            blocks[blocks.IndexOf(-1)] = block;
        }
    }

    blocks.RemoveAll(b => b == -1);

    return CalculateSum([.. blocks]);
}

int Part2(string input)
{
    return 0;
}

int[] MakeIntArray(string input) => [.. input.Select(c => int.Parse(c.ToString()))];

long CalculateSum(int[] array) => array.Select((n, i) => (long)n * i).Sum();

List<int> ProcessInstructions(string input)
{
    var instructions = MakeIntArray(input);
    var index = 0;
    List<int> blocks = new List<int>();

    for (int i = 0; i < instructions.Length; i++)
    {
        blocks.AddRange(Enumerable.Repeat(i % 2 == 0 ? index++ : -1, instructions[i]));
    }

    return blocks;
}

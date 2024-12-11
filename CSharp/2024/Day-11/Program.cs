// Advent of Code 2024 Day 11

var input = File.ReadAllText("input.txt");

System.Console.WriteLine($"Part 1: {Part1(input)}");
System.Console.WriteLine($"Part 2: {Part2(input)}");

long Part1(string input)
{
    var stones = MakeStoneArray(input);

    for (int i = 0; i < 25; i++)
    {
        stones = ConvertStoneArray(stones);
    }

    return stones.Sum(stone => stone.Count);
}

long Part2(string input)
{
    var stones = MakeStoneArray(input);

    for (int i = 0; i < 75; i++)
    {
        stones = ConvertStoneArray(stones);
    }

    return stones.Sum(stone => stone.Count);
}

Stone[] ConvertStoneArray(Stone[] stones)
{
    List<Stone> newStones = [];

    foreach (var stone in stones)
    {
        if (stone.Number == 0) { newStones.Add(new(1, stone.Count)); }
        else
        {
            int numDigits = (int)Math.Floor(Math.Log10(stone.Number) + 1);
            if (numDigits % 2 == 0)
            {
                int halfDigits = numDigits / 2;
                long divisor = (long)Math.Pow(10, halfDigits);
                newStones.Add(new(stone.Number / divisor, stone.Count));
                newStones.Add(new(stone.Number % divisor, stone.Count));
            }
            else { newStones.Add(new(stone.Number * 2024, stone.Count)); }
        }
    }

    for (int i = 0; i < newStones.Count - 1; i++)
    {
        int j = i + 1;
        while (j < newStones.Count)
        {
            if (newStones[i].Number == newStones[j].Number)
            {
                newStones[i] = new(newStones[i].Number, newStones[i].Count + newStones[j].Count);
                newStones.RemoveAt(j);
            }
            else { j++; }
        }
    }

    return [.. newStones];
}

Stone[] MakeStoneArray(string input) => [.. input.Split(' ').Select(long.Parse).Select(number => new Stone(number, 1L))];

record Stone(long Number, long Count);

// Advent of Code 2024 Day 11

var input = File.ReadAllText("input.txt");

System.Console.WriteLine($"Part 1: {Part1(input)}");
System.Console.WriteLine($"Part 2: {Part2(input)}");

int Part1(string input)
{
    var stones = CreateLongArray(input);

    for (int i = 0; i < 25; i++)
    {
        stones = ConvertArray(stones);
    }

    return stones.Length;
}

int Part2(string input)
{
    return 0;
}

long[] CreateLongArray(string input) => [.. input.Split(' ').Select(long.Parse)];

long[] ConvertArray(long[] stones)
{    
    var newStones = new List<long>();

    foreach (var stone in stones)
    {
        if (stone == 0)
        {
            newStones.Add(1);
        }
        else
        {
            var stoneStr = stone.ToString();
            if (stoneStr.Length % 2 == 0)
            {
                var half = stoneStr.Length / 2;
                newStones.Add(long.Parse(stoneStr[..half]));
                newStones.Add(long.Parse(stoneStr[half..]));
            }
            else
            {
                newStones.Add(stone * 2024);
            }
        }
    }

    return [.. newStones];
}

// AoC 2023 Day 15

using Microsoft.VisualBasic;

var input = File.ReadAllText("data.txt").Split(',').ToArray();

Console.WriteLine($"Part 1: {Part1(input)}");
Console.WriteLine($"Part 2: {Part2(input)}");

int Part1(string[] input)
{
    int sum = 0;

    foreach (var item in input)
    {
        int itemSum = 0;
        foreach (var c in item)
        {
            itemSum += c;
            itemSum *= 17;
            itemSum %= 256;
        }
        sum += itemSum;
    }
    return sum;
}

int Part2(string[] input)
{
    int sum = 0;
    return sum;
}
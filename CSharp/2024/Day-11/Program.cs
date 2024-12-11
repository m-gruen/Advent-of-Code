﻿// Advent of Code 2024 Day 11

using System.Globalization;

var input = File.ReadAllText("input.txt");

System.Console.WriteLine($"Part 1: {Part1(input)}");
System.Console.WriteLine($"Part 2: {Part2(input)}");

long Part1(string input)
{
    var stones = MakeTupleArray(input);

    for (int i = 0; i < 25; i++)
    {
        stones = ConvertTupleArray(stones);
    }

    return stones.Sum(stone => stone.count);
}

long Part2(string input)
{
    var stones = MakeTupleArray(input);

    for (int i = 0; i < 75; i++)
    {
        stones = ConvertTupleArray(stones);
    }

    return stones.Sum(stone => stone.count);
}

(long number, long count)[] ConvertTupleArray((long number, long count)[] stones)
{

    List<(long, long)> newStones = [];

    foreach (var (number, count) in stones)
    {
        if (number == 0) { newStones.Add((1, count)); }
        else
        {
            int numDigits = (int)Math.Floor(Math.Log10(number) + 1);
            if (numDigits % 2 == 0)
            {
                int halfDigits = numDigits / 2;
                long divisor = (long)Math.Pow(10, halfDigits);
                newStones.Add((number / divisor, count));
                newStones.Add((number % divisor, count));
            }
            else { newStones.Add((number * 2024, count)); }
        }
    }


    for (int i = 0; i < newStones.Count - 1; i++)
    {
        int j = i + 1;
        while (j < newStones.Count)
        {
            if (newStones[i].Item1 == newStones[j].Item1)
            {
                newStones[i] = (newStones[i].Item1, newStones[i].Item2 + newStones[j].Item2);
                newStones.RemoveAt(j);
            }
            else { j++; }
        }
    }

    return [.. newStones];
}

(long number, long count)[] MakeTupleArray(string input)
{
    return [.. input.Split(' ').Select(long.Parse).Select(number => (number, 1L))];
}

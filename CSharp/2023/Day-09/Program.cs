// AoC 2023 Day 9

using static System.Console;
using System.Text.Json;

var lines = File.ReadAllLines("data.txt");

WriteLine($"Part 1: {Part1(lines)}");
WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    int sum = 0;

    for (int i = 0; i < lines.Length; i++)
    {
        sum += FindNextNumber(lines[i].Split(' ').Select(int.Parse).ToArray());
    }

    return sum;
}

int Part2(string[] lines)
{
    int sum = 0;

    for (int i = 0; i < lines.Length; i++)
    {
        sum += FindPreviousNumber(lines[i].Split(' ').Select(int.Parse).ToArray());
    }

    return sum;
}

int FindNextNumber(int[] numbers)
{
    var distance = new int[numbers.Length, numbers.Length];

    // Filling the distance array
    var temp = GetDistance(numbers);
    for (int i = 0; i < temp.Length; i++)
    {
        distance[0, i] = temp[i];
    }

    for (int i = 1; i < distance.GetLength(0); i++)
    {
        temp = GetDistance(temp, i + 1);
        if (temp.All(t => t == 0)) { break; }
        for (int j = 0; j < distance.GetLength(1); j++)
        {
            distance[i, j] = temp[j];
        }
    }

    // Finding the next number
    for (int i = distance.GetLength(0) - 2; i >= 0; i--)
    {
        if (Enumerable.Range(0, distance.GetLength(1)).Any(j => distance[i, j] != 0))
        {
            for (int j = 0; j < distance.GetLength(1); j++)
            {
                if (j == distance.GetLength(1) - i - 1)
                {
                    distance[i, j] = distance[i, j - 1] + distance[i + 1, j - 1];
                }
            }
        }
    }

    return numbers.Last() + distance[0, distance.GetLength(1) - 1];
}

int FindPreviousNumber(int[] numbers)
{
    var distance = new int[numbers.Length, numbers.Length];

    // Filling the distance array
    var temp = GetDistance(numbers);
    for (int i = 0; i < temp.Length; i++)
    {
        distance[0, i] = temp[i];
    }

    for (int i = 1; i < distance.GetLength(0); i++)
    {
        temp = GetDistance(temp, i + 1);
        if (temp.All(t => t == 0)) { break; }
        for (int j = 0; j < distance.GetLength(1); j++)
        {
            distance[i, j] = temp[j];
        }
    }

    // Finding the previous number
    var test = 0;
    for (int i = distance.GetLength(0) - 1; i >= 0; i--)
    {
        test = distance[i, 0] - test;
    }

    return numbers.First() - test;
}

int[] GetDistance(int[] numbers, int line = 1)
{
    int[] distance = new int[numbers.Length];

    for (int i = 0; i < distance.Length; i++)
    {
        if (i == distance.Length - line) { break; }
        distance[i] = numbers[i + 1] - numbers[i];
    }

    return distance;
}

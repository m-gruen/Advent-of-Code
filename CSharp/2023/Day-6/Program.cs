using System.Text.Json;
using static System.Console;

var lines = File.ReadAllLines("data.txt");

int Part1(string[] lines)
{
    var time = lines[0].Split(":        ")[1].Split("     ").Select(x => int.Parse(x)).ToArray();
    var distance = lines[1].Split(":   ")[1].Split("   ").Select(x => int.Parse(x)).ToArray();

    int count = 1;
    for (int i = 0; i < time.Length; i++)
    {
        var lineCount = 0;

        var currentTime = time[i];
        var currentDistance = distance[i];

        var velocity = 0;
        var remainingTime = currentTime;
        for (int j = 0; j < currentTime; j++)
        {
            velocity += 1;
            remainingTime -= 1;

            if (velocity * remainingTime > currentDistance)
            {
                lineCount += 1;
            }
        }

        count *= lineCount;
    }

    return count;
}

long Part2(string[] lines)
{
    var time1 = lines[0].Split(":        ")[1].Split("     ");
    var distance1 = lines[1].Split(":   ")[1].Split("   ");

    var time =  long.Parse(string.Join("", time1));
    var distance = long.Parse(string.Join("", distance1));

    long count = 0;
    long velocity = 0;
    long remainingTime = time;
    for (long j = 0; j < time; j++)
    {
        velocity += 1;
        remainingTime -= 1;

        if (velocity * remainingTime > distance)
        {
            count += 1;
        }
    }

    return count;
}

WriteLine($"Part 1: {Part1(lines)}");
WriteLine($"Part 2: {Part2(lines)}");

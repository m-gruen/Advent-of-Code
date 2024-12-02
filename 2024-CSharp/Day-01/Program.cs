// Advent of Code 2024: Day 1

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    List<int> numbers1 = [];
    List<int> numbers2 = [];

    foreach (var line in lines)
    {
        var parts = line.Split("   ");

        numbers1.Add(int.Parse(parts[0]));
        numbers2.Add(int.Parse(parts[1]));
    }

    numbers1.Sort();
    numbers2.Sort();

    var sumDiff = 0;

    for (int i = 0; i < numbers1.Count; i++)
    {
        sumDiff += Math.Abs(numbers1[i] - numbers2[i]);
    }

    return sumDiff;
}


int Part2(string[] lines)
{

    List<int> numbers1 = [];
    List<int> numbers2 = [];

    foreach (var line in lines)
    {
        var parts = line.Split("   ");

        numbers1.Add(int.Parse(parts[0]));
        numbers2.Add(int.Parse(parts[1]));
    }

    var sumSimilarity = 0;

    for (int i = 0; i < numbers1.Count; i++)
    {
        var index = numbers1[i];

        var count = 0;
        foreach (var index2 in numbers2)
        {
            if (index == index2)
            {
                count++;
            }
        }

        sumSimilarity += index * count;
    }

    return sumSimilarity;
}

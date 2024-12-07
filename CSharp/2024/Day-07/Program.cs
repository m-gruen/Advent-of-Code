// Advent of Code 2024 Day 7

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

long Part1(string[] lines)
{
    long sum = 0;
    foreach (var line in lines)
    {
        var parts = line.Split(":");
        var expectedResult = long.Parse(parts[0]);
        var numbers = parts[1].Trim().Split(" ");

        if (Calculate(string.Join("+", numbers)) <= expectedResult
            && Calculate(string.Join("*", numbers)) >= expectedResult)
        {
            char[] operators = ['+', '*'];
            int combinations = (int)Math.Pow(2, numbers.Length - 1);

            for (int i = 0; i < combinations; i++)
            {
                var expression = numbers[0];
                int temp = i;

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    expression += operators[temp % 2];
                    expression += numbers[j + 1];
                    temp /= 2; // Binary shift
                }

                if (Calculate(expression) == expectedResult)
                {
                    sum += expectedResult;
                    break;
                }
            }
        }
    }

    return sum;
}

int Part2(string[] lines)
{
    return 0;
}

long Calculate(string expression)
{
    long result = 0;
    var numbers = expression.Split(['+', '*']);
    List<char> operators = [];

    foreach (char c in expression)
    {
        if (c == '+' || c == '*') { operators.Add(c); }
    }

    result = long.Parse(numbers[0]);

    for (int i = 0; i < operators.Count; i++)
    {
        var nextNumber = long.Parse(numbers[i + 1]);

        if (operators[i] == '+') { result += nextNumber; }
        else if (operators[i] == '*') { result *= nextNumber; }
    }

    return result;
}
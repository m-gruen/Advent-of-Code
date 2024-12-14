// Advent of Code 2024 Day 13

var input = File.ReadAllText("input.txt");

System.Console.WriteLine($"Part 1: {Part1(input)}");
System.Console.WriteLine($"Part 2: {Part2(input)}");

int Part1(string input)
{
    var blocks = GetBlocks(input);

    var totalCosts = 0;
    foreach (var block in blocks)
    {
        var lines = block.Split(Environment.NewLine);

        var buttonA = ParseButton(lines[0]);
        var buttonB = ParseButton(lines[1]);
        var prize = ParsePrize(lines[2]);

        var buttonBSteps = prize.X / buttonB.X;
        var buttonASteps = 0;

        var currentX = buttonBSteps * buttonB.X;

        while (true)
        {
            if (currentX == prize.X && buttonBSteps * buttonB.Y + buttonASteps * buttonA.Y == prize.Y)
            {
                totalCosts += buttonBSteps + buttonASteps * 3;
                break;
            }

            buttonBSteps--;
            var plusASteps = (prize.X - (buttonBSteps * buttonB.X + buttonASteps * buttonA.X)) / buttonA.X;

            while (plusASteps <= 0)
            {
                buttonBSteps--;
                plusASteps = (prize.X - (buttonBSteps * buttonB.X + buttonASteps * buttonA.X)) / buttonA.X;
            }

            buttonASteps += plusASteps;

            if ((prize.X - (buttonBSteps * buttonB.X + buttonASteps * buttonA.X)) / buttonB.X > 0) { buttonBSteps++; }

            if (buttonBSteps < 0) { break; }

            currentX = buttonBSteps * buttonB.X + buttonASteps * buttonA.X;
        }

    }

    return totalCosts;
}

int Part2(string input)
{
    return 0;
}

string[] GetBlocks(string input) => input.Split($"{Environment.NewLine}{Environment.NewLine}");

Button ParseButton(string line)
{
    var parts = line[10..].Split(", ");
    var x = int.Parse(parts[0][2..]);
    var y = int.Parse(parts[1][2..]);
    return new Button(x, y);
}

Prize ParsePrize(string line)
{
    var parts = line[7..].Split(", ");
    var x = int.Parse(parts[0][2..]);
    var y = int.Parse(parts[1][2..]);
    return new Prize(x, y);
}

record Button(int X, int Y);
record Prize(int X, int Y);

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

long Part2(string input)
{
    var blocks = ProcessInstructions(input);
    var holes = new List<int>();

    for (int index = 0; index < blocks.Count; index++)
    {
        if (blocks[index] == -1) { holes.Add(index); }
    }

    for (int i = blocks.Count - 1; i >= 0; i--)
    {
        if (blocks[i] != -1)
        {
            var file = new List<int>();
            for (int j = i; j >= 0 && blocks[j] == blocks[i]; j--)
            {
                file.Add(blocks[j]);
            }

            int? holeStartIndex = null;
            for (int h = 0; h <= holes.Count; h++)
            {
                bool isContiguous = true;
                for (int k = 0; k < file.Count; k++)
                {
                    if (holes[h + k] != holes[h] + k)
                    {
                        isContiguous = false;
                        break;
                    }
                }
                
                if (isContiguous)
                {
                    holeStartIndex = holes[h];
                    break;
                }
            }

            if (holeStartIndex.HasValue && holeStartIndex.Value < i)
            {
                for (int k = 0; k < file.Count; k++)
                {
                    blocks[holeStartIndex.Value + k] = file[k];
                    holes.Remove(holeStartIndex.Value + k);
                }
                for (int k = 0; k < file.Count; k++)
                {
                    blocks[i - k] = -1;
                    holes.Add(i - k);
                }
            }
            else
            {
                i -= file.Count - 1;
            }
        }
    }

    for (int i = 0; i < blocks.Count; i++)
    {
        if (blocks[i] == -1)
        {
            blocks[i] = 0;
        }
    }

    return CalculateSum([.. blocks]);
}

int[] MakeIntArray(string input) => [.. input.Select(c => int.Parse(c.ToString()))];

long CalculateSum(int[] array) => array.Select((n, i) => (long)n * i).Sum();

List<int> ProcessInstructions(string input)
{
    var instructions = MakeIntArray(input);
    var index = 0;
    List<int> blocks = [];

    for (int i = 0; i < instructions.Length; i++)
    {
        blocks.AddRange(Enumerable.Repeat(i % 2 == 0 ? index++ : -1, instructions[i]));
    }

    return blocks;
}

// Advent of Code 2024 Day 8

var input = File.ReadAllText("input-short.txt");

System.Console.WriteLine($"Part 1: {Part1(input)}");
System.Console.WriteLine($"Part 2: {Part2(input)}");

int Part1(string input)
{
    var instructions = MakeIntArray(input);

    // So basically:
    // The first number is the number of blocks from a file
    // Followed by the number of free blocks.
    // So for example:"12345"
    // Would look like this:
    // 0..111....22222 (. is a free block)

    // Then we need to know the index of the file blocks.
    // We put the index of the file in the free blocks.
    // Then we "compress" the file blocks by moving them to the left
    // So for example:
    /*
    0..111....22222
    02.111....2222.
    022111....222..
    0221112...22...
    02211122..2....
    022111222......
    */

    // Then we calculate the sum using the CalculateSum method

    // This: 2333133121414131402

    // Would look like this:
    /*
    00...111...2...333.44.5555.6666.777.888899
    009..111...2...333.44.5555.6666.777.88889.
    0099.111...2...333.44.5555.6666.777.8888..
    00998111...2...333.44.5555.6666.777.888...
    009981118..2...333.44.5555.6666.777.88....
    0099811188.2...333.44.5555.6666.777.8.....
    009981118882...333.44.5555.6666.777.......
    0099811188827..333.44.5555.6666.77........
    00998111888277.333.44.5555.6666.7.........
    009981118882777333.44.5555.6666...........
    009981118882777333644.5555.666............
    00998111888277733364465555.66.............
    0099811188827773336446555566..............
    */
    // In our case we would replace the dots with zeros

    var index = 0;
    List<int> blocks = [];

    return CalculateSum([.. blocks]);
}

int Part2(string input)
{
    return 0;
}

int[] MakeIntArray(string input) => [.. input.Select(c => int.Parse(c.ToString()))];

int CalculateSum(int[] array) => array.Select((n, i) => n * i).Sum();

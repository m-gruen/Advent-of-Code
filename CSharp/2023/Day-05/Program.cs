var input = File.ReadAllText("input.txt"); 
var endOfLine1 = input.IndexOf('\n');
var seeds = input[7..endOfLine1].Split(' ').Select(long.Parse).ToArray();
input = input[(endOfLine1 + 2)..];

var seedRanges = seeds.Select(s => new SeedRange(s, 1)).ToList();
Calculate(input, seedRanges);

seedRanges = Enumerable.Range(0, seeds.Length / 2)
    .Select(i => new SeedRange(seeds[i * 2], seeds[i * 2 + 1])).ToList();
Calculate(input, seedRanges);

static void Calculate(string input, List<SeedRange> seedRanges)
{
    var sections = input.Split("\n\n")
        .Select(section => section.Split('\n').Skip(1)
            .Select(l => l.Split(' ').Select(long.Parse).ToArray())
            .Select(l => new Map(l[0], l[1], l[2])))
        .ToArray();
    foreach(var section in sections)
    {
        var nextSeedRanges = new List<SeedRange>();
        foreach (var map in section)
        {
            while (true)
            {
                var osr = seedRanges.FirstOrDefault(s => s.Start < map.SourceRangeEnd && s.End > map.SourceRangeStart);
                if (osr.Length == 0) { break; }
                seedRanges.Remove(osr);
                var overlapStart = Math.Max(map.SourceRangeStart, osr.Start);
                var overlapEnd = Math.Min(map.SourceRangeEnd, osr.End);
                if (osr.Start < overlapStart) { seedRanges.Add(SeedRange.FromStartEnd(osr.Start, overlapStart - 1)); }
                if (osr.End > overlapEnd) { seedRanges.Add(SeedRange.FromStartEnd(overlapEnd + 1, osr.End)); }
                nextSeedRanges.Add(SeedRange.FromStartEnd(overlapStart + map.Delta, overlapEnd + map.Delta));
            }
        }
        nextSeedRanges.AddRange(seedRanges);
        seedRanges = nextSeedRanges;
    }
    Console.WriteLine(seedRanges.Min(sr => sr.Start));
}

record struct SeedRange(long Start, long Length)
{
    public static SeedRange FromStartEnd(long start, long end) => new(start, end - start + 1);
    public readonly long End => Start + Length - 1;
}

record struct Map(long DestRangeStart, long SourceRangeStart, long RangeLength)
{
    public readonly long DestRangeEnd => DestRangeStart + RangeLength - 1;
    public readonly long SourceRangeEnd => SourceRangeStart + RangeLength - 1;
    public readonly long Delta => DestRangeStart - SourceRangeStart;
}

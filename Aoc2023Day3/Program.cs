using Aoc2023Day3;

internal class Program
{
    // https://www.reddit.com/r/adventofcode/comments/189q9wv/2023_day_3_another_sample_grid_to_use/

    private static void Main(string[] args)
    {
        SchematicEngine schema = new();

        schema.ReadInput();

        SolveStar1(schema);

        SolveStar2();
    }

    private static void SolveStar1(SchematicEngine schema)
    {
        schema.FindValidPartNumbers();

        var star1 = schema.SumOfAllValidParts();

        Console.WriteLine($"total star 1: {star1}");
    }

    private static void SolveStar2()
    {
        var star2 = 0;

        Console.WriteLine($"total star 2: {star2}");
    }

    
}

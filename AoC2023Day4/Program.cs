
internal class Program
{
    private static void Main(string[] args)
    {
        SolveStar1("input.txt");

        SolveStar2("input-test.txt");
    }

    private static int CalculateElement(int n)
    {
        return (int)Math.Pow(2, n - 1);
    }

    private static void SolveStar1(string input)
    {
        var star1 = 0;

        using StreamReader reader = new(input);

        while (reader != null && !reader.EndOfStream)
        {
            var r = reader.ReadLine();

            if (r != null)
            {
                int score = 0;

                var left = r[..r.LastIndexOf('|')];

                var right = r[(r.LastIndexOf('|') + 1)..];

                string[] winning = left.Split(' ');

                string[] mine = right.Split(' ');

                for (int i = 0; i < mine.Length; i++)
                {
                    for (int y = 0; y < winning.Length; y++)
                    {
                        if (mine[i] == winning[y])
                        {
                            if (!string.IsNullOrWhiteSpace(mine[i]))
                            {
                                score++;
                            }
                        }
                    }
                }

                star1 += CalculateElement(score);
            }
        }

        Console.WriteLine($"total star 1: {star1}");
    }

    private static void SolveStar2(string input)
    {
        var star2 = 0;

        

        Console.WriteLine($"total star 2: {star2}");
    }


}
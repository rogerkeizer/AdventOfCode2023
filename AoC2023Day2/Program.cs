using AoC2023Day2;
using System.Text.RegularExpressions;

internal class Program
{
    public static readonly string Red = "red";
    public static readonly string Green = "green";
    public static readonly string Blue = "blue";

    private static void Main(string[] args)
    {
        Dictionary<int, string[]> games = ReadInput();

        SolveStar1(games);

        SolveStar2(games);
    }

    private static void SolveStar1(Dictionary<int, string[]> games)
    {
        var star1 = 0;

        foreach (var game in games)
        {
            var possible = true;

            foreach (var subset in game.Value)
            {
                var sets = subset.Split(',');

                foreach (var set in sets)
                {
                    var number = Convert.ToInt32(Regex.Match(set, @"\d+").Value);

                    if (set.Contains(Red) && number > 12)
                    {
                        possible = false;
                    }
                    if (set.Contains(Green) && number > 13)
                    {
                        possible = false;
                    }
                    if (set.Contains(Blue) && number > 14)
                    {
                        possible = false;
                    }

                    if (possible == false)
                    {
                        break;
                    }
                }
                if (possible == false)
                {
                    break;
                }
            }

            if (possible)
            {
                star1 += game.Key;
            }
        }

        Console.WriteLine($"total star 1: {star1}");
    }


    private static void SolveStar2(Dictionary<int, string[]> games)
    {
        var star2 = 0;

        foreach (var game in games)
        {
            List<SubSet> subsets = new();

            foreach (var subset in game.Value)
            {
                var sets = subset.Split(',');

                foreach (var set in sets)
                {
                    var t = set.TrimStart().Split(' ');

                    subsets.Add(new SubSet(Convert.ToInt32(t[0]), t[1]));
                }

                subsets = subsets.OrderByDescending(o => o.Number).ToList();
            }

            var highR = 0;
            var highG = 0;
            var highB = 0;

            for (int i = 0; i < subsets.Count; i++)
            {
                if (subsets[i].Color == Red && subsets[i].Number > highR)
                {
                    highR = subsets[i].Number;
                }
                if (subsets[i].Color == Green && subsets[i].Number > highG)
                {
                    highG = subsets[i].Number;
                }
                if (subsets[i].Color == Blue && subsets[i].Number > highB)
                {
                    highB = subsets[i].Number;
                }
            }

            star2 += (highR * highG * highB);
        }

        Console.WriteLine($"total star 2: {star2}");
    }

    private static Dictionary<int, string[]> ReadInput()
    {
        Dictionary<int, string[]> games = new();

        using StreamReader reader = new("input.txt");

        while (reader != null && !reader.EndOfStream)
        {
            var r = reader.ReadLine();

            if (r != null)
            {
                var line = r.Split(':');

                var key = Convert.ToInt32(Regex.Match(line[0], @"\d+").Value);

                games.Add(key, line[1].Trim().Split(';'));
            }
        }

        return games;
    }

}
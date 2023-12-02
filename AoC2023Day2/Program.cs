using System.Text.RegularExpressions;

internal class Program
{
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

                    if (set.Contains("red") && number > 12)
                    {
                        possible = false;
                    }
                    if (set.Contains("green") && number > 13)
                    {
                        possible = false;
                    }
                    if (set.Contains("blue") && number > 14)
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
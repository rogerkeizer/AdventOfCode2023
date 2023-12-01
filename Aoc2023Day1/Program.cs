using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        SolveStar1();

        SolveStar2(); 
    }

    private static void SolveStar1()
    {
        var star1 = 0;

        using StreamReader reader = new("input.txt");

        while (reader != null && !reader.EndOfStream)
        {
            var r = reader.ReadLine();

            if (r != null)
            {
                string[] numbers = Regex.Split(r, @"\D+");

                var digit = new StringBuilder();

                for (int i = 0; i < numbers.Length; i++)
                {
                    int number = int.TryParse(numbers[i], out number) ? number : 0;

                    if (number > 0)
                    {
                        digit.Append(numbers[i]);
                    }
                }

                star1 += Convert.ToInt32($"{digit[0]}{digit[^1]}");
            }
        }

        Console.WriteLine(star1);
    }

    private static void SolveStar2()
    {
        var star2 = 0;

        string[] strings = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        string[] numbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        using StreamReader reader = new("input.txt");

        while (reader != null && !reader.EndOfStream)
        {
            var comparisonType = StringComparison.OrdinalIgnoreCase;

            var matches = new Dictionary<int, string>();

            var r = reader.ReadLine();

            if (r != null)
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    int index = r.IndexOf(strings[i], comparisonType);

                    while (index != -1)
                    {
                        matches.Add(index, strings[i]);

                        index = r.IndexOf(strings[i], index + 1, comparisonType);
                    }
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    int index = r.IndexOf(numbers[i], comparisonType);

                    while (index != -1)
                    {
                        matches.Add(index, numbers[i]);

                        index = r.IndexOf(numbers[i], index + 1, comparisonType);
                    }
                }

                if (matches.Count == 1)
                {
                    matches.Add(matches.First().Key + 1, matches.First().Value);
                }
                else 
                {
                    matches = matches.OrderBy(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value);
                }

                var digit = new StringBuilder();

                int first = int.TryParse(matches.First().Value, out first) ? first : 0;

                if (first > 0)
                {
                    digit.Append(first);
                }
                else
                {
                    if (Array.IndexOf(strings, matches.First().Value) > -1)
                    {
                        digit.Append(Array.IndexOf(strings, matches.First().Value) + 1);
                    }
                }

                int last = int.TryParse(matches.Last().Value, out last) ? last : 0;

                if (last > 0)
                {
                    digit.Append(last);
                }
                else
                {
                    if (Array.IndexOf(strings, matches.Last().Value) > -1)
                    {
                        digit.Append(Array.IndexOf(strings, matches.Last().Value) + 1);
                    }
                }

                star2 += Convert.ToInt32($"{digit[0]}{digit[^1]}");
            }
        }

        Console.WriteLine(star2);
    }
}
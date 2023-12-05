namespace Aoc2023Day3
{
    internal class SchematicEngine : ISchematicEngine
    {
        private List<Part> PartNumbers { get; set; }

        private List<Symbol> Symbols { get; set; }

        public SchematicEngine() 
        {
            PartNumbers = new List<Part>();

            Symbols = new List<Symbol>();
        }

        public void ReadInput()
        {
            int y = 0;

            string match = @"1234567890";

            using StreamReader reader = new("input.txt");

            while (reader != null && !reader.EndOfStream)
            {
                var r = reader.ReadLine();

                if (r != null)
                {
                    for (int e = 0; e < r.Length; e++)
                    {
                        var length = 0;

                        while (match.Contains(r[e]) && r[e] != '.')
                        {
                            length++;

                            e++;

                            if (e == r.Length)
                            {
                                break;
                            }
                        }

                        if (length > 0)
                        {
                            var number = Convert.ToInt32(r.Substring(e - length, length));

                            PartNumbers.Add(new Part(e - length, y, number));
                        }
                    }

                    for (int e = 0; e < r.Length; e++)
                    {
                        while (!match.Contains(r[e]) && r[e] != '.')
                        {
                            Symbols.Add(new Symbol(e, y));

                            e++;

                            if (e == r.Length)
                            {
                                break;
                            }
                        }
                    }

                    y++;
                }
            }
        }

        public void FindValidPartNumbers()
        { 
            foreach (var part in PartNumbers) 
            {
                foreach(var symbol in Symbols) 
                {
                    if (part.Y == symbol.Y || part.Y - 1 == symbol.Y || part.Y + 1 == symbol.Y)
                    {
                        if (symbol.X == part.X
                         || symbol.X == part.X - 1
                         || symbol.X == part.X + 1
                         || symbol.X == part.X + part.Length
                         || symbol.X == part.X + part.Length - 1 
                         || symbol.X == part.X + part.Length + 1)
                        {
                            part.IsValid = true; 
                            break; 
                        }
                    }
                }
            }
        }

        public int SumOfAllValidParts()
        {
            var total = 0;

            foreach (var part in PartNumbers)
            {
                if (part.IsValid)
                {
                    total += part.Number;
                }
            }

            return total;
        }
    }
}

namespace Aoc2023Day3
{
    internal class Part
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }
        public int Length { get; set; }
        public bool IsValid { get; set; }

        public Part(int x, int y, int number)
        {
            X = x;
            Y = y;
            Number = number;
            Length = Number.ToString().Length;
        }
    }
}

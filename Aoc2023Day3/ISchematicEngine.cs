namespace Aoc2023Day3
{
    public interface ISchematicEngine
    {
        public void ReadInput();
        public void FindValidPartNumbers();
        int SumOfAllValidParts();
    }
}

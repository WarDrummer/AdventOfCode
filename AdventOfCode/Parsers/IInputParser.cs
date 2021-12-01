namespace AdventOfCode.Parsers
{
    public interface IInputParser<T>
    {
        T GetData();
    }
}
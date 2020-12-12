namespace AdventOfCode.Day12
{
    public interface IInstructionsInterpreter
    {
        OrientationsState State { get; }
        void Interpret(string instruction);
        int GetManhatanDistance();
    }
}
namespace AdventOfCode.Day11
{
    public interface IBusyChecker
    {
        int LimitBusyAround { get; }

        bool IsSeatReadyToBusy(int line, int column);

        bool ShouldBeEmpty(int line, int column);
    }
}

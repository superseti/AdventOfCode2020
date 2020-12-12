namespace AdventOfCode.Day11
{
    public class SeatsTurnHandler
    {
        public bool HandleTurn(SeatLayoutInfo info, IBusyChecker chequer)
        {
            for (int ixLine = 0; ixLine < info.LineCount; ixLine++)
            {
                for (int ixColumn = 0; ixColumn < info.ColumnCount; ixColumn++)
                {
                    if (info.IsSeatEmpty(ixLine, ixColumn) && chequer.IsSeatReadyToBusy(ixLine, ixColumn))
                    {
                        info.SetBookingState(ixLine, ixColumn, true);
                    }
                    if (info.IsSeatBusy(ixLine, ixColumn) && chequer.ShouldBeEmpty(ixLine, ixColumn))
                    {
                        info.SetBookingState(ixLine, ixColumn, false);
                    }
                }
            }
            return info.ApplyPendingChanges();
        }
    }
}

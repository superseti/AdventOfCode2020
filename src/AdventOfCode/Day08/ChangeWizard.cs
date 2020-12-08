namespace AdventOfCode.Day08
{
    public class ChangeWizard
    {
        public ProgramLine[] Lines { get; private set; }
        public ChangeWizard(string programLinesData) 
        {
            this.Lines = new ProgramReader().ReadProgram(programLinesData);
        }

        public ChangeInfo DetectChange()
        {
            for (int ixLine = 0; ixLine < this.Lines.Length; ixLine++)
            {
                var currentLine = this.Lines[ixLine];
                if (currentLine.Instruction == "acc") { continue; }
                this.AlternateInstruction(currentLine);

                var executor = new ProgramExecutor(this.Lines);

                var endedCorrectly = executor.ExecuteTillLoopOrEnd();

                this.AlternateInstruction(currentLine);

                if (endedCorrectly) 
                {
                    return new ChangeInfo()
                    {
                        AccumulatorValue = executor.State.AccumulatorValue,
                        LineNumber = ixLine
                    };
                }
            }

            return new ChangeInfo() {
                AccumulatorValue = 0,
                LineNumber = 0
            };
        }

        private void AlternateInstruction(ProgramLine line)
            => line.Instruction = (line.Instruction == "nop" ? "jmp" : "nop");
    }
}

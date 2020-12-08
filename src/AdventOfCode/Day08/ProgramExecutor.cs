namespace AdventOfCode.Day08
{
    public class ProgramExecutor
    {
        public ProgramExecutor(string programLinesData)
        {
            this.Lines = new ProgramReader().ReadProgram(programLinesData);
        }
        public ProgramExecutor(ProgramLine[] programLines)
        {
            this.Lines = programLines;
        }
        public ProgramLine[] Lines { get; private set; }

        public ProgramState State { get; private set; } = new ProgramState();
        public void ExecuteCurrentLine() 
        {
            var currentLine = this.Lines[this.State.CurrentLineExecuting];
            var lineDifference = currentLine.Instruction == "jmp" ? currentLine.Parameter : 1;
            var valueToAccumulate = currentLine.Instruction == "acc" ? currentLine.Parameter : 0;

            this.State.CallStack.Add(currentLine);

            this.State.AccumulatorValue += valueToAccumulate;
            this.State.CurrentLineExecuting += lineDifference;
        }

        public bool ExecuteTillLoopOrEnd()
        {
            while (!this.IsProgramTerminated() && !this.IsCurrentLineAlreadyExecute())
            {
                this.ExecuteCurrentLine();
            }
            return this.IsProgramTerminated();
        }

        private bool IsCurrentLineAlreadyExecute() => 
            !this.IsProgramTerminated() && this.State.CallStack.IndexOf(this.Lines[this.State.CurrentLineExecuting]) >= 0;

        private bool IsProgramTerminated()=> this.State.CurrentLineExecuting >= this.Lines.Length;
    }
}

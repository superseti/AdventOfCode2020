namespace AdventOfCode.Day12
{
    public class Ship<T>
        where T : IInstructionsInterpreter, new()
    {
        private readonly T interpreter;

        public Ship()
        {
            this.interpreter = new T();
        }

        public void ReadInstructions(string[] instructions)
        {
            foreach (var instruction in instructions)
            {
                this.interpreter.Interpret(instruction);
            }
        }

        public int GetManhathanDistance() => this.interpreter.GetManhatanDistance();
    }
}

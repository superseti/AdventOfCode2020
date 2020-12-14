using System;
using System.Linq;

namespace AdventOfCode.Day14
{
    public class InstructionsInterpreter
    {
        public Int64 Interpret(string[] instructions)
        {
            ProgramState state = new ProgramState();

            foreach (var instruction in instructions)
            {
                this.InterpreteInstruction(instruction, state);
            }

            return state.Values.Sum(entry => state.Calculator.Converter.ToDecimal(entry.Value));
        }

        private void InterpreteInstruction(string instruction, ProgramState state)
        {
            var data = instruction.Split('=');
            var instructionType = data[0].Trim();
            var value = data[1].Trim();

            if (instructionType == "mask")
            {
                state.Calculator.Mask = value;
                return;
            }

            var memoryPosition = int.Parse(data[0].Substring(4).Replace("]", ""));
            state.Values[memoryPosition] = state.Calculator.GetValueToApply(int.Parse(value));
        }
    }
}

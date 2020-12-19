using System;
using System.Linq;

namespace AdventOfCode.Day14
{
    public class InstructionsInterpreterV2 : IInstructionsInterpreter
    {
        public Int64 Interpret(string[] instructions)
        {
            ProgramStateV2 state = new ProgramStateV2();

            foreach (var instruction in instructions)
            {
                this.InterpreteInstruction(instruction, state);
            }

            return state.Values.Sum(entry => (Int64)entry.Value);
        }

        private void InterpreteInstruction(string instruction, ProgramStateV2 state)
        {
            var data = instruction.Split('=');
            var instructionType = data[0].Trim();
            var value = data[1].Trim();

            if (instructionType == "mask")
            {
                state.Calculator.Mask = value;
                return;
            }

            var memoryPositions = state.Calculator.GetMemoryPositions(data[0]);

            foreach (var memoryPosition in memoryPositions)
            {
                state.Values[memoryPosition] = Int64.Parse(value);
            }
        }
    }
}

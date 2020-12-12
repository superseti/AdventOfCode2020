using System;
using System.Collections.Generic;

namespace AdventOfCode.Day12
{
    public class InstructionsInterpreter : IInstructionsInterpreter
    {
        private Dictionary<char, Action<int>> handlers;
        public InstructionsInterpreter()
        {
            this.State = new OrientationsState();
            this.handlers = new Dictionary<char, Action<int>>
            {
                { 'F', this.Forward },
                { 'N', this.North },
                { 'E', this.East },
                { 'W', this.West },
                { 'S', this.South },
                { 'R', this.Right },
                { 'L', this.Left }
            };
        }

        public int GetManhatanDistance() => this.State.GetManhathanDistance();

        public Orientations Facing { get; set; } = Orientations.East;
        public OrientationsState State { get; private set; }

        public void Interpret(string instruction)
        {
            var instructionType = instruction[0];
            var value = Convert.ToInt32(instruction.Substring(1));

            this.handlers[instructionType](value);
        }

        private void Forward(int value) => this.AddValueOrientation(this.Facing, value);
        private void North(int value) => this.AddValueOrientation(Orientations.North, value);
        private void East(int value) => this.AddValueOrientation(Orientations.East, value);
        private void West(int value) => this.AddValueOrientation(Orientations.West, value);
        private void South(int value) => this.AddValueOrientation(Orientations.South, value);
        private void Right(int value) => this.Turn(value);
        private void Left(int value) => this.Turn(-value);

        private void Turn(int value) => this.Facing = this.GetTargetOrientation(this.Facing, value);

        private Orientations GetTargetOrientation(Orientations orientation, int angle)
        {
            var newOrientation = ((int)orientation + angle) % 360;
            if (newOrientation < 0) { newOrientation += 360; }
            return (Orientations)newOrientation;
        }

        private void AddValueOrientation(Orientations orientation, int value)
        {
            var currentValue = this.State.OrientationMovements[orientation];
            var opositeOrientation = this.GetTargetOrientation(orientation, 180);
            var opositeOrientationValue = this.State.OrientationMovements[opositeOrientation];
            var pendingValue = opositeOrientationValue - value;
            if (pendingValue <= 0)
            {
                this.State.OrientationMovements[opositeOrientation] = 0;
                this.State.OrientationMovements[orientation] = currentValue - pendingValue;
                return;
            }

            this.State.OrientationMovements[opositeOrientation] = pendingValue;
        }
    }
}

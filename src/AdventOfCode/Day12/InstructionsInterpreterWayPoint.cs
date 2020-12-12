using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Day12
{
    public class InstructionsInterpreterWayPoint : IInstructionsInterpreter
    {
        private Dictionary<char, Action<int>> handlers;
        public InstructionsInterpreterWayPoint()
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
            this.WaypointState = new OrientationsState();
            this.WaypointState.OrientationMovements[Orientations.East] = 10;
            this.WaypointState.OrientationMovements[Orientations.North] = 1;
        }

        public int GetManhatanDistance() => this.State.GetManhathanDistance();

        public OrientationsState WaypointState { get; private set; }
        public OrientationsState State { get; private set; }

        public void Interpret(string instruction)
        {
            var instructionType = instruction[0];
            var value = Convert.ToInt32(instruction.Substring(1));

            this.handlers[instructionType](value);
        }

        private void Forward(int value)
        {
            foreach (var orientation in this.WaypointState.OrientationMovements.Keys.ToArray())
            {
                var valueToAdd = this.WaypointState.OrientationMovements[orientation] * value;
                this.AddValueOrientation(this.State, orientation, valueToAdd);
            }
        }
        private void North(int value) => this.AddValueOrientation(this.WaypointState, Orientations.North, value);
        private void East(int value) => this.AddValueOrientation(this.WaypointState, Orientations.East, value);
        private void West(int value) => this.AddValueOrientation(this.WaypointState, Orientations.West, value);
        private void South(int value) => this.AddValueOrientation(this.WaypointState, Orientations.South, value);
        private void Right(int value) => this.Turn(value);
        private void Left(int value) => this.Turn(-value);

        private void Turn(int value)
        {
            List<KeyValuePair<Orientations, int>> newWapointStarState =
                new List<KeyValuePair<Orientations, int>>();
            foreach (var orientation in this.WaypointState.OrientationMovements.Keys)
            {
                var targetOrientation = this.GetTargetOrientation(orientation, value);
                var valueOrientation = this.WaypointState.OrientationMovements[orientation];
                newWapointStarState.Add(new KeyValuePair<Orientations, int>(targetOrientation, valueOrientation));
            }

            newWapointStarState.ForEach(orientationData =>
                this.WaypointState.OrientationMovements[orientationData.Key] = orientationData.Value);
        }

        private Orientations GetTargetOrientation(Orientations orientation, int angle)
        {
            var newOrientation = ((int)orientation + angle) % 360;
            if (newOrientation < 0) { newOrientation += 360; }
            return (Orientations)newOrientation;
        }

        private void AddValueOrientation(OrientationsState targetState, Orientations orientation, int value)
        {
            var currentValue = targetState.OrientationMovements[orientation];
            var opositeOrientation = this.GetTargetOrientation(orientation, 180);
            var opositeOrientationValue = targetState.OrientationMovements[opositeOrientation];
            var pendingValue = opositeOrientationValue - value;
            if (pendingValue <= 0)
            {
                targetState.OrientationMovements[opositeOrientation] = 0;
                targetState.OrientationMovements[orientation] = currentValue - pendingValue;
                return;
            }

            targetState.OrientationMovements[opositeOrientation] = pendingValue;
        }
    }
}

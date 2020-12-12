using AdventOfCode.Day12;
using Xunit;

namespace AdventOfCode.Tests.Day12
{
    public class ShipTests
    {
        [Fact]
        public void ReadInstructions_ShouldWork()
        {
            var instructions = new string[] {
"F10",
"N3",
"F7",
"R90",
"F11"};

            var ship = new Ship<InstructionsInterpreter>();
            ship.ReadInstructions(instructions);

            var distance = ship.GetManhathanDistance();

            var expectedDistance = 25;

            Assert.Equal(expectedDistance, distance);
        }
        [Fact]
        public void ReadInstructions_WithWaypoint_ShouldWork()
        {
            var instructions = new string[] {
"F10",
"N3",
"F7",
"R90",
"F11"};

            var ship = new Ship<InstructionsInterpreterWayPoint>();
            ship.ReadInstructions(instructions);

            var distance = ship.GetManhathanDistance();

            var expectedDistance = 286;

            Assert.Equal(expectedDistance, distance);
        }
    }
}

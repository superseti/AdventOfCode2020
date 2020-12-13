using AdventOfCode.Helpers;
using System;

namespace AdventOfCode.Day03
{
    /*
    /// --- Day 3: Toboggan Trajectory ---
    //    With the toboggan login problems resolved, you set off toward the airport.While travel by toboggan might be easy, it's certainly not safe: there's very minimal steering and the area is covered in trees.You'll need to see which angles will take you near the fewest trees.

    //Due to the local geology, trees in this area only grow on exact integer coordinates in a grid. You make a map (your puzzle input) of the open squares (.) and trees (#) you can see. For example:

    //..##.......
    //#...#...#..
    //.#....#..#.
    //..#.#...#.#
    //.#...##..#.
    //..#.##.....
    //.#.#.#....#
    //.#........#
    //#.##...#...
    //#...##....#
    //.#..#...#.#
    //These aren't the only trees, though; due to something you read about once involving arboreal genetics and biome stability, the same pattern repeats to the right many times:

    //..##.........##.........##.........##.........##.........##.......  --->
    //#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
    //.#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
    //..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
    //.#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
    //..#.##.......#.##.......#.##.......#.##.......#.##.......#.##.....  --->
    //.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
    //.#........#.#........#.#........#.#........#.#........#.#........#
    //#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...
    //#...##....##...##....##...##....##...##....##...##....##...##....#
    //.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#  --->
    //You start on the open square (.) in the top-left corner and need to reach the bottom (below the bottom-most row on your map).

    //The toboggan can only follow a few specific slopes (you opted for a cheaper model that prefers rational numbers); start by counting all the trees you would encounter for the slope right 3, down 1:

    //From your starting position at the top-left, check the position that is right 3 and down 1. Then, check the position that is right 3 and down 1 from there, and so on until you go past the bottom of the map.

    //The locations you'd check in the above example are marked here with O where there was an open square and X where there was a tree:

    //..##.........##.........##.........##.........##.........##.......  --->
    //#..O#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
    //.#....X..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
    //..#.#...#O#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
    //.#...##..#..X...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
    //..#.##.......#.X#.......#.##.......#.##.......#.##.......#.##.....  --->
    //.#.#.#....#.#.#.#.O..#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
    //.#........#.#........X.#........#.#........#.#........#.#........#
    //#.##...#...#.##...#...#.X#...#...#.##...#...#.##...#...#.##...#...
    //#...##....##...##....##...#X....##...##....##...##....##...##....#
    //.#..#...#.#.#..#...#.#.#..#...X.#.#..#...#.#.#..#...#.#.#..#...#.#  --->
    //In this example, traversing the map using this slope would cause you to encounter 7 trees.

    //Starting at the top-left corner of your map and following a slope of right 3 and down 1, how many trees would you encounter?

    //Your puzzle answer was 153.

    //The first half of this puzzle is complete! It provides one gold star: *

    //--- Part Two ---
    //Time to check the rest of the slopes - you need to minimize the probability of a sudden arboreal stop, after all.

    //Determine the number of trees you would encounter if, for each of the following slopes, you start at the top-left corner and traverse the map all the way to the bottom:

    //Right 1, down 1.
    //Right 3, down 1. (This is the slope you already checked.)
    //Right 5, down 1.
    //Right 7, down 1.
    //Right 1, down 2.
    //In the above example, these slopes would find 2, 7, 3, 4, and 2 tree(s) respectively; multiplied together, these produce the answer 336.

    //What do you get if you multiply together the number of trees encountered on each of the listed slopes ?
    */
    class ThirdDayResolver : IResolver
    {
        private readonly string[] treePattern;

        public ThirdDayResolver()
        {
            this.treePattern = new InputDataReader().GetInputDataSplitted(this);
        }

        public string ResolveFirst()
        {
            MovementRule movementRule = new MovementRule()
            {
                SpacesToBottom = 1,
                SpacesToRight = 3
            };
            var numberOfTrees = GetNumberOfTrees(movementRule);

            return $"{numberOfTrees}";
        }

        private Int64 GetNumberOfTrees(MovementRule movementRule)
        {
            Int64 numberOfTrees = 0;
            var currentPosition = new Point();
            var forest = treePattern;

            while (currentPosition.PositionY < treePattern.Length)
            {
                if (IsNeeedAnotherRepetition(currentPosition.PositionX, forest))
                {
                    forest = Duplicate(forest);
                }
                if (IsATree(currentPosition, forest)) { numberOfTrees++; }

                currentPosition = GetNextPosition(currentPosition, movementRule);
            }

            return numberOfTrees;
        }

        private Point GetNextPosition(Point currentPosition, MovementRule movementRule)
        {
            return new Point()
            {
                PositionY = currentPosition.PositionY + movementRule.SpacesToBottom,
                PositionX = currentPosition.PositionX + movementRule.SpacesToRight
            };
        }

        private bool IsATree(Point position, string[] forest)
        {
            return forest[position.PositionY][position.PositionX] == '#';
        }

        private bool IsNeeedAnotherRepetition(int positionX, string[] currentForest)
        {
            return currentForest.Length == 0 || positionX >= currentForest[0].Length;
        }

        private string[] Duplicate(string[] currentForest)
        {
            string[] result = new string[currentForest.Length];

            for (int ixRow = 0; ixRow < currentForest.Length; ixRow++)
            {
                result[ixRow] = currentForest[ixRow] + currentForest[ixRow];
            }
            return result;
        }

        public string ResolveSecond()
        {
            MovementRule movementRule1 = new MovementRule()
            {
                SpacesToBottom = 1,
                SpacesToRight = 1
            };
            MovementRule movementRule2 = new MovementRule()
            {
                SpacesToBottom = 1,
                SpacesToRight = 3
            };
            MovementRule movementRule3 = new MovementRule()
            {
                SpacesToBottom = 1,
                SpacesToRight = 5
            };
            MovementRule movementRule4 = new MovementRule()
            {
                SpacesToBottom = 1,
                SpacesToRight = 7
            };
            MovementRule movementRule5 = new MovementRule()
            {
                SpacesToBottom = 2,
                SpacesToRight = 1
            };
            var numberOfTrees1 = GetNumberOfTrees(movementRule1);
            var numberOfTrees2 = GetNumberOfTrees(movementRule2);
            var numberOfTrees3 = GetNumberOfTrees(movementRule3);
            var numberOfTrees4 = GetNumberOfTrees(movementRule4);
            var numberOfTrees5 = GetNumberOfTrees(movementRule5);

            return $"{numberOfTrees1} * {numberOfTrees2} * {numberOfTrees3} * {numberOfTrees4} * {numberOfTrees5} = {numberOfTrees1 * numberOfTrees2 * numberOfTrees3 * numberOfTrees4 * numberOfTrees5}";
        }
    }
}
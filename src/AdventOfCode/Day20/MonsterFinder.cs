using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day20
{
    public class MonsterFinder
    {
        private readonly Regex monsterRegex = new Regex(@"(\n).{18,}(#).+\n.*(#.{4}##.{4}##.{4}###).*\n.{1,}(#.{2}#..#..#..#..#.{3,})");
        public int CountMonsters(string[] picture)
        {
            ManipulaterTiles manipulator = new ManipulaterTiles();
            var result = this.CountMonstersInFlippedPositions(picture, manipulator);

            if (result > 0) { return result; }

            var pictureFlipped = manipulator.FlipPicture(picture);
            result = this.CountMonstersInFlippedPositions(pictureFlipped, manipulator);

            return result;
        }

        private int CountMonstersInFlippedPositions(string[] picture, ManipulaterTiles manipulator)
        {
            var pictureRotated = picture;
            var result = this.CountMonstersInPosition(pictureRotated);
            if (result > 0) { return result; }

            for (int ix = 0; ix < 3; ix++)
            {
                pictureRotated = manipulator.RotatePicture(pictureRotated);
                result = this.CountMonstersInPosition(pictureRotated);
                if (result > 0) { return result; }
            }

            return result;
        }

        private int CountMonstersInPosition(string[] picture)
        {
            var wholePicture = "\n" + string.Join("\n", picture);
            var possibleMonsters = this.monsterRegex.Matches(wholePicture);

            return possibleMonsters.Count;

            var result = 0;

            for (int ix = 0; ix < possibleMonsters.Count; ix++)
            {
                var match = possibleMonsters[ix];

                var lines = match.Value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var firstLineInit = match.Groups[1].Index;

                var positionSecondLineElement = match.Groups[3].Index - lines[0].Length - firstLineInit;
                var positionThridLineElement = positionSecondLineElement + 2; //match.Groups[4].Index - lines[1].Length - lines[0].Length - firstLineInit;
                var positionFirstLineElement = positionSecondLineElement + 18 - 1;

                if (lines[2].Length > positionThridLineElement && lines[2][positionThridLineElement] == '#')
                {
                    if (lines[0][positionFirstLineElement] == '#')
                    {
                        result++;
                    }
                    else
                    {
                    }
                }
            }

            return result;
        }

        public int GetWaterRoughness(Tile topLeftTile)
        {
            var picture = new ConcatenatorTiles().Concatenate(topLeftTile);
            var numberOfWaterMarks = picture.Sum(line => line.Count(charLine => charLine == '#'));

            var monsterSize = 15;

            var numberOfMonsters = this.CountMonsters(picture);

            return numberOfWaterMarks - monsterSize * numberOfMonsters;
        }
    }
}

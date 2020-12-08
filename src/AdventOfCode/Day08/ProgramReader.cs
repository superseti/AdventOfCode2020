using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day08
{
    public class ProgramReader
    {
        public ProgramLine[] ReadProgram(string programLinesData)
        {
            List<ProgramLine> lines = new List<ProgramLine>();
            var matches = new Regex("(\\w+) ([+|-]\\d+)").Matches(programLinesData);
            for (int ixMatch = 0; ixMatch < matches.Count; ixMatch++)
            {
                var currentMatch = matches[ixMatch];
                lines.Add(new ProgramLine()
                {
                    Instruction = currentMatch.Groups[1].Value,
                    Parameter = Convert.ToInt32(currentMatch.Groups[2].Value),
                    LineNumber = ixMatch
                });
            }
            return lines.ToArray();
        }
    }
}

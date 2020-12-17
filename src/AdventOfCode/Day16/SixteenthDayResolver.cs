using AdventOfCode.Helpers;
using System.Linq;
using System;

namespace AdventOfCode.Day16
{
    public class SixteenthDayResolver : IResolver
    {
        public string ResolveFirst()
        {
            string[] inputData = new InputDataReader().GetInputDataSplittedByBlankLine(this);
            var tickets = new TicketsConverter().GetTickets(inputData[2]);
            return new ErrorRateCalculator(inputData[0]).GetErrorsRate(tickets).ToString();
        }

        public string ResolveSecond()
        {
            string[] inputData = new InputDataReader().GetInputDataSplittedByBlankLine(this);
            var fields = new FieldDetector().DetectFields(inputData[0], inputData[2]);

            var myTicket = new TicketsConverter().GetTickets(inputData[1]).First();

            var fieldsDeparture = fields.Where(field => field.Rule.Name.StartsWith("departure "));

            Int64 result = 1;

            foreach (var field in fieldsDeparture)
            {
                result *= myTicket.Values[field.Position].Value;
            }

            return result.ToString();
        }
    }
}

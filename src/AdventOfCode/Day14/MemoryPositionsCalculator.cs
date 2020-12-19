using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Day14
{
    public class MemoryPositionsCalculator
    {
        private int[] floatingPositions;
        private string mask;
        private Dictionary<char, Func<char, char>> handlers;
        public MemoryPositionsCalculator()
        {
            this.Converter = new BinaryConverter();
            this.handlers = new Dictionary<char, Func<char, char>>
            {
                { '1', this.ForcePositionValue },
                { '0', this.LetPassPositionValue },
                { 'X', this.FloatPositionValue }
            };
        }
        public string Mask
        {
            get => this.mask;
            set
            {
                this.mask = value;
                var newFloatingPositions = new List<int>();
                for (int ix = 0; ix < this.mask.Length; ix++)
                {
                    if (this.mask[ix] == 'X') { newFloatingPositions.Add(ix); }
                }
                this.floatingPositions = newFloatingPositions.ToArray();
            }
        }

        public BinaryConverter Converter { get; private set; }

        public string GetValueToApply(int decimalValue)
        {
            var binaryValue = this.Converter.ToBinary(decimalValue).Reverse().ToArray();
            var value = this.Mask.Replace('X', '0').ToCharArray();

            Parallel.For(0, binaryValue.Length, ix => this.ApplyValuePosition(value, ix, binaryValue));

            return string.Join("", value);
        }

        internal IEnumerable<Int64> GetMemoryPositions(string dataPosition)
        {
            var memoryPosition = int.Parse(dataPosition.Substring(4).Replace("]", ""));
            var resultFloatPosition = this.GetValueToApply(memoryPosition);

            var baseMemoryDir = resultFloatPosition.Replace('X', '0');

            var memoryPositions = this.DecryptFloatingPositions(baseMemoryDir, this.floatingPositions);

            return memoryPositions.Select(position => this.Converter.ToDecimal(position));
        }

        private IEnumerable<string> DecryptFloatingPositions(string baseMemoryAddress, IEnumerable<int> floatingPositions)
        {
            var currentFloatingPositions = new List<int>(floatingPositions);

            var currentPosition = currentFloatingPositions[0];
            currentFloatingPositions.RemoveAt(0);

            var result0 = this.ReplaceFloatingPosition(baseMemoryAddress, currentPosition, '0');
            var result1 = this.ReplaceFloatingPosition(baseMemoryAddress, currentPosition, '1');

            List<string> memoryPositions = new List<string>();

            if (currentFloatingPositions.Count == 0)
            {
                memoryPositions.Add(result0);
                memoryPositions.Add(result1);
            }
            else
            {
                memoryPositions.AddRange(this.DecryptFloatingPositions(result0, currentFloatingPositions));
                memoryPositions.AddRange(this.DecryptFloatingPositions(result1, currentFloatingPositions));
            }

            return memoryPositions;
        }

        private string ReplaceFloatingPosition(string memoryAddress, int floatingPosition, char value)
        {
            var result = memoryAddress.ToCharArray()
                .Take(floatingPosition)
                .Append(value)
                .Concat(memoryAddress.Skip(floatingPosition + 1));

            return string.Join("", result.ToArray());
        }

        private void ApplyValuePosition(char[] value, int position, char[] binaryValue)
        {
            var valuePositionInBinary = binaryValue[position];
            int positionInValue = value.Length - position - 1;
            value[positionInValue] = this.GetValuePositionToApply(valuePositionInBinary, this.Mask[positionInValue]);
        }

        private char GetValuePositionToApply(char binaryValue, char maskValue) => this.handlers[maskValue](binaryValue);

        private char FloatPositionValue(char binaryValue) => 'X';
        private char LetPassPositionValue(char binaryValue) => binaryValue;
        private char ForcePositionValue(char binaryValue) => '1';
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Day14
{
    public class ValueCalculator
    {
        private Dictionary<char, Func<char, char>> handlers;
        public ValueCalculator()
        {
            this.Converter = new BinaryConverter();
            this.handlers = new Dictionary<char, Func<char, char>>
            {
                { '1', this.ForcePositionValue },
                { '0', this.AvoidPositionValue },
                { 'X', this.LetPassPositionValue }
            };
        }
        public string Mask { get; set; }

        public BinaryConverter Converter { get; private set; }

        public string GetValueToApply(int decimalValue)
        {
            var binaryValue = this.Converter.ToBinary(decimalValue).Replace('0', ' ').Reverse().ToArray();

            var value = this.Mask.Replace('X', '0').ToCharArray();

            Parallel.For(0, binaryValue.Length, ix => this.ApplyValuePosition(value, ix, binaryValue));

            return string.Join("", value);
        }

        private void ApplyValuePosition(char[] value, int position, char[] binaryValue)
        {
            var valuePositionInBinary = binaryValue[position];
            if (valuePositionInBinary == ' ') { return; }
            int positionInValue = value.Length - position - 1;
            value[positionInValue] = this.GetValuePositionToApply(valuePositionInBinary, this.Mask[positionInValue]);
        }

        private char GetValuePositionToApply(char binaryValue, char maskValue) => this.handlers[maskValue](binaryValue);

        private char LetPassPositionValue(char binaryValue) => binaryValue;
        private char AvoidPositionValue(char binaryValue) => '0';
        private char ForcePositionValue(char binaryValue) => '1';
    }
}

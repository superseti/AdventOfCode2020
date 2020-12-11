using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Helpers
{
    class InputDataReader
    {
        public string GetInputData(IResolver resolver)
        {
            var typeResolver = resolver.GetType();
            var basePath = Path.GetDirectoryName(typeResolver.Assembly.Location);
            var fileInputDataName = typeResolver.Name.Replace("DayResolver", "") + ".txt";

            var fileInputData = Path.Combine(basePath, "InputDataFiles", fileInputDataName);

            if (!File.Exists(fileInputData))
            {
                Console.WriteLine("File not found");
                return string.Empty;
            }

            return File.ReadAllText(fileInputData)
                .Replace("\r\n", "\n");
        }

        public string[] GetInputDataSplitted(IResolver resolver)
        {
            return GetInputData(resolver)
                 .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string[] GetInputDataSplittedByBlankLine(IResolver resolver)
        {
            return GetInputData(resolver)
                 .Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public int[] GetInputDataSplittedAsInt(IResolver resolver)
        {
            return this.GetInputDataSplitted(resolver, numberStr => Int32.Parse(numberStr));
        }

        public T[] GetInputDataSplitted<T>(IResolver resolver, Func<string, T> converter)
        {
            return GetInputData(resolver)
                 .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(line => converter(line))
                 .ToArray();
        }
    }
}
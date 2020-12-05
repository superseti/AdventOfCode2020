using System;
using System.IO;

namespace AdventCodeConsole.Helpers
{
    class InputDataReader
    {
        public string GetInputData(IResolver resolver)
        {
            var typeResolver = resolver.GetType();
            var basePath = Path.GetDirectoryName(typeResolver.Assembly.Location);
            var fileInputDataName = typeResolver.Name.Replace("DayResolver", "") + ".txt";

            var fileInputData = Path.Combine(basePath, "InputDataFiles", fileInputDataName);

            return File.ReadAllText(fileInputData)
                .Replace("\r\n", "\n");
        }

        public string[] GetInputDataSplitted(IResolver resolver)
        {
           return GetInputData(resolver)
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

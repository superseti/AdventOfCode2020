namespace AdventOfCode.Day04
{
    class PassportField
    {
        public PassportField(string FieldInfo)
        {
            var data = FieldInfo.Split(':');
            this.Key = data[0];
            this.Value = data[1];
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}

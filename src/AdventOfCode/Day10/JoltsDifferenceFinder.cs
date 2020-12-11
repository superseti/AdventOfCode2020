namespace AdventOfCode.Day10
{
    public class JoltsDifferenceFinder
    {
        public JoltsDifferenceFinder(int[] jolts)
        {
            this.DifferencesInfo = new JoltsDifferencesInfo();
            this.Info = new JoltsInfo(jolts);
            this.Init();
        }

        private void Init()
        {
            var lastJolt = this.Info.InitialJoltage;
            for (int ixJolt = 0; ixJolt < this.Info.Jolts.Length; ixJolt++)
            {
                var currentJolt = this.Info.Jolts[ixJolt];
                this.AddDiference(currentJolt - lastJolt);
                lastJolt = currentJolt;
            }
            this.AddDiference(this.Info.DeviceJoltage - lastJolt);
        }

        private void AddDiference(int difference)
        {
            if (difference == 3)
            {
                this.DifferencesInfo.NumberOfThreeJoltsDifference++;
            }
            if (difference == 1)
            {
                this.DifferencesInfo.NumberOfOneJoltDifference++;
            }
        }

        public JoltsDifferencesInfo DifferencesInfo { get; private set; }
        public JoltsInfo Info { get; private set; }
    }
}

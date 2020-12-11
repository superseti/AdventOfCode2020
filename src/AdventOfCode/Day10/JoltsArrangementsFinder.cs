namespace AdventOfCode.Day10
{
    public class JoltsArrangementsFinder
    {
        public JoltsArrangementsFinder(int[] jolts)
        {
            this.Info = new JoltsInfo(jolts);

            //var itemsJumpable = 0;

            //for (int ixJoly = 0; ixJoly < jolts.Length; ixJoly++)
            //{
            //    itemsJumpable += new ArrangementScopeNode(ixJoly, jolts).NumberOfItemsJumpeables;
            //}

            //this.NumberOfArrangements = 1;

            //for (int ixJumpeable = 1; ixJumpeable <= itemsJumpable; ixJumpeable++)
            //{
            //    this.NumberOfArrangements *= ixJumpeable;
            //}

            this.NumberOfArrangements = new ArrangementScopeNode(null, 0, ref jolts).GetNumberOfArrangement();
        }

        public JoltsInfo Info { get; private set; }

        public double NumberOfArrangements { get; private set; }
    }
}

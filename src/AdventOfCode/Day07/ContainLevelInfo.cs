using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day07
{
    public class BagContainLevelInfo
    {
        public BagContainLevelInfo(BagContainLevelInfo parent, int NumberOfElements, string BagName)
        {
            this.Parent = parent;
            this.Info = new BagContainInfo() {
                NumberOfElements = NumberOfElements,
                BagName = BagName
            };
            this.Bags = new List<BagContainLevelInfo>();
        }
        public BagContainLevelInfo Parent { get; private set; }
        public List<BagContainLevelInfo> Bags { get; private set; }
        public BagContainInfo Info { get; private set; }

        public int GetNumberOfElements()
        {
            var sumChilds = this.Bags.Sum(bag => bag.GetNumberOfElements());

            var result = this.Info.NumberOfElements * sumChilds + this.Info.NumberOfElements;
            return result;
        }
    }
}
﻿using System;

namespace AdventCodeConsole
{
    class FirstDayResolver: IResolver
    {
        /*
         * --- Day 1: Report Repair ---
After saving Christmas five years in a row, you've decided to take a vacation at a nice resort on a tropical island. Surely, Christmas will go on without you.

The tropical island has its own currency and is entirely cash-only. The gold coins used there have a little picture of a starfish; the locals just call them stars. None of the currency exchanges seem to have heard of them, but somehow, you'll need to find fifty of these coins by the time you arrive so you can pay the deposit on your room.

To save your vacation, you need to get all fifty stars by December 25th.

Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently, something isn't quite adding up.

Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.

For example, suppose your expense report contained the following:

1721
979
366
299
675
1456
In this list, the two entries that sum to 2020 are 1721 and 299. Multiplying them together produces 1721 * 299 = 514579, so the correct answer is 514579.

Of course, your expense report is much larger. Find the two entries that sum to 2020; what do you get if you multiply them together?

--- Part Two ---
The Elves in accounting are thankful for your help; one of them even offers you a starfish coin they had left over from a past vacation. They offer you a second one if you can find three numbers in your expense report that meet the same criteria.

Using the above example again, the three entries that sum to 2020 are 979, 366, and 675. Multiplying them together produces the answer, 241861950.

In your expense report, what is the product of the three entries that sum to 2020?
         */

        public void ResolveFirst()
        {
            for (int ixFirst = 0; ixFirst < this.numbers.Length - 2; ixFirst++)
            {
                var firstNumber = this.numbers[ixFirst];
                for (int ixSecond = ixFirst + 1; ixSecond < this.numbers.Length - 1; ixSecond++)
                {
                    var secondNumber = numbers[ixSecond];

                    if (firstNumber + secondNumber == 2020)
                    {
                        Console.WriteLine($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                        return;
                    }
                }
            }

        }

        public void ResolveSecond()
        {
            for (int ixFirst = 0; ixFirst < this.numbers.Length - 2; ixFirst++)
            {
                var firstNumber = this.numbers[ixFirst];
                for (int ixSecond = ixFirst + 1; ixSecond < this.numbers.Length - 1; ixSecond++)
                {
                    var secondNumber = this.numbers[ixSecond];
                    for (int ixThird = ixSecond + 1; ixThird < this.numbers.Length; ixThird++)
                    {
                        var thirdNumber = this.numbers[ixThird];
                        if (firstNumber + secondNumber + thirdNumber == 2020)
                        {
                            Console.WriteLine($"{firstNumber} * {secondNumber} * {thirdNumber} = {firstNumber * secondNumber * thirdNumber}");
                            return;
                        }
                    }
                }
            }

        }

        private readonly int[] numbers = new int[] {
1348,
1621,
1500,
1818,
1266,
1449,
1880,
1416,
1862,
1665,
1588,
1704,
1922,
1482,
1679,
1263,
1137,
1045,
1405,
1048,
1619,
1520,
455 ,
1142,
1415,
1554,
1690,
1886,
1891,
1701,
1915,
1521,
1253,
1580,
1376,
1564,
1747,
1814,
1749,
1485,
1969,
974 ,
1566,
1413,
1451,
1200,
1558,
1756,
1910,
1044,
470 ,
1620,
1772,
1066,
1261,
1776,
988 ,
1976,
1834,
1896,
1646,
1626,
1300,
1692,
1204,
2006,
1265,
1911,
1361,
1766,
1750,
2000,
1824,
1726,
1672,
651 ,
1226,
1954,
1055,
1999,
1793,
1640,
1567,
1040,
1426,
1717,
1658,
1864,
1917,
695 ,
1071,
1573,
1897,
1546,
1727,
1801,
1259,
1290,
1481,
1148,
1332,
1262,
1536,
1184,
1821,
1681,
1671,
1612,
1678,
1703,
1604,
1697,
2003,
1453,
1493,
1797,
1180,
1234,
1775,
1859,
1388,
1393,
667 ,
1767,
1429,
1990,
1322,
1684,
1696,
1565,
1380,
1745,
1685,
1189,
1396,
1593,
1850,
1722,
1495,
1844,
1285,
1483,
1635,
1072,
1947,
1109,
1586,
1730,
1723,
1246,
1389,
1135,
1827,
1531,
1583,
1743,
1958,
183 ,
1323,
1949,
1799,
1269,
1379,
1950,
1592,
1467,
1052,
1418,
2009,
1227,
1254,
1865,
1609,
1848,
1653,
1691,
1633,
1349,
1104,
1790,
1755,
1847,
1598,
1872,
1478,
1778,
1952,
1694,
1238,
1825,
1508,
1141,
1464,
1838,
1292,
1403,
1365,
1494,
934 ,
1235,
};
    }
}
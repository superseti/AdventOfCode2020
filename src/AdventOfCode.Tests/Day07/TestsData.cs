using System.Collections.Generic;

namespace AdventOfCode.Tests.Day07
{
    class BagsRulesTestsData
    {
        public static IEnumerable<object[]> GetRulesSingleLineNonIncludeShinyBag()
        {
            yield return new object[] { "light red bags contain 1 bright white bag, 2 muted yellow bags." };
            yield return new object[] { "dark orange bags contain 3 bright white bags, 4 muted yellow bags." };
            yield return new object[] { "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags." };
            yield return new object[] { "dark olive bags contain 3 faded blue bags, 4 dotted black bags." };
            yield return new object[] { "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags." };
            yield return new object[] { "dotted black bags contain no other bags." };
            yield return new object[] { "faded blue bags contain no other bags." };
        }

        public static IEnumerable<object[]> GetRulesSingleLineIncludeShinyBag()
        {
            yield return new object[] { "bright white bags contain 1 shiny gold bag.", "bright white" };
            yield return new object[] { "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.", "muted yellow" };
            yield return new object[] { "bold brown bags contain 9 faded blue bags, 1 shiny gold bags.", "bold brown" };
        }

        public static IEnumerable<object[]> GetRulesFromShinyBag()
        {
            yield return new object[] { @"shiny gold bags contain 2 dark red bags.
dark red bags contain no other bags", 2 };
            yield return new object[] { @"shiny gold bags contain 6 dark red bags.
dark red bags contain 5 dark orange bags.
dark orange bags contain 4 dark yellow bags.
dark yellow bags contain 3 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 1 dark violet bags.
dark violet bags contain no other bags.", 1956 };

            yield return new object[] { @"shiny gold bags contain 6 dark red bags.
dark red bags contain 5 dark orange bags.
dark orange bags contain 4 dark yellow bags.
dark yellow bags contain 3 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 1 dark violet bags, 5 vibrant olive bags.
dark violet bags contain no other bags.
vibrant olive bags contain no other bags.", 5556 };
            
            yield return new object[] { @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.", 32 };
        }
    }
}
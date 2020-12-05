using AdventCodeConsole.Helpers;
using AdventOfCode;
using System;

namespace AdventCodeConsole
{
    class Program
    {
        private static ResolverWrapper[] resolvers;
        private static string menuOptions;
        static void Main(string[] args)
        {
            Initialize();
            int? optionIndex = null;
            while (optionIndex.HasValue == false || optionIndex >= 0)
            {
                optionIndex = ShowMenu();
                if (optionIndex.HasValue && optionIndex >= 0)
                {
                    Resolve(resolvers[optionIndex.Value].GetResolver());
                }
            }
        }

        private static void Initialize()
        {
            resolvers = new ResolversHelper().GetResolvers();
            menuOptions = string.Empty;
            for (int ixResolver = 0; ixResolver < resolvers.Length; ixResolver++)
            {
                menuOptions += $", {ixResolver + 1}: {resolvers[ixResolver].Description}";
            }
            menuOptions = menuOptions.Substring(2) + ", q: quit";
        }

        private static int? ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose the option to resolve");
            Console.WriteLine(menuOptions);
            var result = Console.ReadLine();
            Console.Clear();

            if (int.TryParse(result, out int resultIndex) &&
                resultIndex > 0 && resultIndex <= resolvers.Length)
            {
                return resultIndex - 1;
            }
            return string.Compare(result, "q", true) == 0 ? -1 : (int?)null;
        }

        static void Resolve(IResolver resolver)
        {
            Console.WriteLine("First star");
            resolver.ResolveFirst();
            Console.ReadLine();
            Console.WriteLine("Second star");
            resolver.ResolveSecond();
            Console.WriteLine();
            Console.WriteLine("press any key to begin again");
            Console.ReadLine();
        }
    }
}
using AdventOfCode;
using System;
using System.Linq;

namespace AdventCodeConsole.Helpers
{
    class ResolversHelper
    {
        public ResolverWrapper[] GetResolvers()
        {
            var iResolverType = typeof(IResolver);
            var iResolverTypes = iResolverType.Assembly
                    .GetTypes()
                    .Where(type => type.GetInterface(iResolverType.FullName) == iResolverType)
                    .OrderBy(type => type.FullName);
            return iResolverTypes.Select(type => new ResolverWrapper(type)).ToArray();
        }
    }
    public class ResolverWrapper
    {
        internal ResolverWrapper(Type resolverType)
        {
            this.ResolverType = resolverType;
            this.Description = this.ResolverType.Name.Replace("DayResolver", "");
        }
        public string Description { get; private set; }
        public Type ResolverType { get; private set; }
        public IResolver GetResolver() => Activator.CreateInstance(this.ResolverType) as IResolver;
    }
}

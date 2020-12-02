﻿using AdventCodeConsole.SecondDay;

namespace AdventCodeConsole.Helper
{
    class ResolversHelper
    {
        public IResolverWrapper[] GetResolvers()
        {
            return new IResolverWrapper[] {
                new ResolverWrapper<FirstDayResolver>(),
                new ResolverWrapper<SecondDayResolver>()
            };
        }
    }

    public interface IResolverWrapper
    {
        string Description { get; }
        IResolver GetResolver();
    }

    public class ResolverWrapper<T>: IResolverWrapper
        where T: IResolver, new()
    {
        public ResolverWrapper()
        {
            this.Description = typeof(T).Name.Replace("DayResolver", "");
        }
        public string Description { get; private set; }
        public IResolver GetResolver() => new T();
    }
}

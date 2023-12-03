using System;
using System.Collections.Generic;
using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider
{
    public abstract class StatProvider : IStatProvider
    {
        protected readonly Dictionary<Type, Stat> _stats = new();

        public T GetStat<T>() where T : Stat
        {
            if (_stats.ContainsKey(typeof(T)) == false)
                return null;

            return (T)_stats[typeof(T)];
        }
    }
}
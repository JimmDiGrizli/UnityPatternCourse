using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider
{
    public abstract class StatProviderDecorator : IStatProvider
    {
        protected readonly IStatProvider _statProvider;

        protected StatProviderDecorator(IStatProvider statProvider)
        {
            _statProvider = statProvider;
        }

        public abstract T GetStat<T>() where T : Stat;
    }
}
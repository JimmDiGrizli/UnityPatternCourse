using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider.PassiveAbility
{
    public class NobelLaureateProvider : StatProviderDecorator
    {
        public NobelLaureateProvider(IStatProvider statProvider) : base(statProvider)
        {
        }

        public override T GetStat<T>()
        {
            return typeof(T) switch
            {
                { } t when t == typeof(IntellectStat) => (T)(_statProvider.GetStat<T>() +
                                                             _statProvider.GetStat<AgilityStat>().Value +
                                                             _statProvider.GetStat<StrengthStat>().Value),
                { } t when t == typeof(AgilityStat) => new AgilityStat(1) as T,
                { } t when t == typeof(StrengthStat) => new StrengthStat(1) as T,
                _ => _statProvider.GetStat<T>()
            };
        }
    }
}
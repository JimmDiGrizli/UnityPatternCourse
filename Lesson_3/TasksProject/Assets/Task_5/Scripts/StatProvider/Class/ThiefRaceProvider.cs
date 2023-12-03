using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider.Class
{
    public class ThiefRaceProvider : StatProviderDecorator
    {
        private readonly int _modifier;

        public ThiefRaceProvider(IStatProvider statProvider, int modifier) : base(statProvider)
        {
            _modifier = modifier;
        }

        public override T GetStat<T>()
        {
            return typeof(T) switch
            {
                { } t when t == typeof(AgilityStat) => (T)(_statProvider.GetStat<T>() * _modifier),
                _ => _statProvider.GetStat<T>()
            };
        }
    }
}
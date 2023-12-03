using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider.PassiveAbility
{
    public class StupidBoyProvider : StatProviderDecorator
    {
        private readonly int _modifier;

        public StupidBoyProvider(IStatProvider statProvider, int modifier) : base(statProvider)
        {
            _modifier = modifier;
        }

        public override T GetStat<T>()
        {
            return typeof(T) switch
            {
                { } t when t == typeof(IntellectStat) => new IntellectStat(1) as T,
                { } t when t == typeof(StrengthStat) => (T)(_statProvider.GetStat<T>() * _modifier),
                _ => _statProvider.GetStat<T>()
            };
        }
    }
}
using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider.Class
{
    public class WizardRaceProvider : StatProviderDecorator
    {
        private readonly int _modifier;

        public WizardRaceProvider(IStatProvider statProvider, int modifier) : base(statProvider)
        {
            _modifier = modifier;
        }

        public override T GetStat<T>()
        {
            return typeof(T) switch
            {
                { } t when t == typeof(IntellectStat) => (T)(_statProvider.GetStat<T>() * _modifier),
                _ => _statProvider.GetStat<T>()
            };
        }
    }
}
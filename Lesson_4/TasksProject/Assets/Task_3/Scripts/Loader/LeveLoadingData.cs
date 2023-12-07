using Task_3.Scripts.VictoryPattern;

namespace Task_3.Scripts.Loader
{
    public class LeveLoadingData
    {
        public LeveLoadingData(VictoryType type) => Type = type;

        public VictoryType Type { get; private set; }
    }
}
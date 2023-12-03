using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider.Race
{
    public class HumanRaceProvider : StatProvider
    {
        public HumanRaceProvider()
        {
            _stats.Add(typeof(AgilityStat), new AgilityStat(2));
            _stats.Add(typeof(StrengthStat), new StrengthStat(2));
            _stats.Add(typeof(IntellectStat), new IntellectStat(5));
            _stats.Add(typeof(HumanSpecialStat), new HumanSpecialStat(5));
        }
    }
}
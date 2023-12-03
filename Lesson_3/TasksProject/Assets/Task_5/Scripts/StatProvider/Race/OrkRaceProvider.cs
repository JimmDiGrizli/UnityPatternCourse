using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider.Race
{
    public class OrkRaceProvider : StatProvider
    {
        public OrkRaceProvider()
        {
            _stats.Add(typeof(AgilityStat), new AgilityStat(2));
            _stats.Add(typeof(StrengthStat), new StrengthStat(5));
            _stats.Add(typeof(IntellectStat), new IntellectStat(2));
        }
    }
}
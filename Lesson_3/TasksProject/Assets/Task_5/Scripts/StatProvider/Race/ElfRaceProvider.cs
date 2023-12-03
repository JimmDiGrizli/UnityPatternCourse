using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider.Race
{
    public class ElfRaceProvider : StatProvider
    {
        public ElfRaceProvider()
        {
            _stats.Add(typeof(AgilityStat), new AgilityStat(5));
            _stats.Add(typeof(StrengthStat), new StrengthStat(2));
            _stats.Add(typeof(IntellectStat), new IntellectStat(2));
        }
    }
}
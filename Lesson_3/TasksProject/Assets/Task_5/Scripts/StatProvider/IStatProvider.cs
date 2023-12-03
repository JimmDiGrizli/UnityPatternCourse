using Task_5.Scripts.StatProperty;

namespace Task_5.Scripts.StatProvider
{
    public interface IStatProvider
    {
        public T GetStat<T>() where T : Stat;
    }
}
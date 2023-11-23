namespace Task2.Scripts.Zones
{
    public class SleepZone : Zone
    {
        protected override void Do(Npc npc) => npc.Sleep();
    }
}
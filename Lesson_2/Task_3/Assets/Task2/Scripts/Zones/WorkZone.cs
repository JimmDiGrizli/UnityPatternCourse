namespace Task2.Scripts.Zones
{
    public class WorkZone : Zone
    {
        protected override void Do(Npc npc) => npc.Work();
    }
}
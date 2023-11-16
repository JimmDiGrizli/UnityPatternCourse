using UnityEngine;

namespace Task3.Scripts.TraderPattern
{
    public class AppleSellingPattern : ITrader
    {
        public void Interact(ISocialize player)
        {
            Debug.Log($"NPC продает яблоки игроку {player}.");
        }
    }
}
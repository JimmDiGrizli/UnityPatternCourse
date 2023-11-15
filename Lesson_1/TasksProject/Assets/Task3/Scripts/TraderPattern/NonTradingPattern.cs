using UnityEngine;

namespace Task3.Scripts.TraderPattern
{
    public class NonTradingPattern : ITrader
    {
        public bool CanInteract(ISocialize player) => true;

        public void Interact(ISocialize player)
        {
            Debug.Log($"NPC не будет торговать с {player}.");
        }
    }
}
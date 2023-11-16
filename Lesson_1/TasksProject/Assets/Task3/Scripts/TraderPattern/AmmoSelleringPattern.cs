using UnityEngine;

namespace Task3.Scripts.TraderPattern
{
    public class AmmoSellingPattern : ITrader
    {
        public void Interact(ISocialize player)
        {
            Debug.Log($"NPC продает броню игроку {player}.");
        }
    }
}
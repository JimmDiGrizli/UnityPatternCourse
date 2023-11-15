using UnityEngine;

namespace Task3.Scripts.TraderPattern
{
    public class AmmoSellingPattern : ITrader
    {
        private readonly int _socialRating;

        public AmmoSellingPattern(int socialRating)
        {
            _socialRating = socialRating < 0 ? 0 : socialRating;
        }

        public bool CanInteract(ISocialize player) => player.SocialRating >= _socialRating;

        public void Interact(ISocialize player)
        {
            if (player.SocialRating >= _socialRating) Debug.Log($"NPC продает броню игроку {player}.");
        }
    }
}
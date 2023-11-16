using Task3.Scripts.TraderPattern;

namespace Task3.Scripts
{
    public class TraderBehaviourSwitcher
    {
        private readonly Npc _npc;

        public TraderBehaviourSwitcher(Npc npc, Player player)
        {
            _npc = npc;
            player.OnSocialRatingChanged += ChangedSellingPattern;
            ChangedSellingPattern(player.SocialRating);
        }

        private void ChangedSellingPattern(int socialRating)
        {
            switch (socialRating)
            {
                case >= 5 and <= 10:
                    _npc.Initialized(new AppleSellingPattern());
                    break;
                case >= 10:
                    _npc.Initialized(new AmmoSellingPattern());
                    break;
                default:
                    _npc.Initialized(new NonTradingPattern());
                    break;
            }
        }
    }
}
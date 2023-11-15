using Task3.Scripts.TraderPattern;
using UnityEngine;

namespace Task3.Scripts
{
    public class TraderExample : MonoBehaviour
    {
        [SerializeField] private Npc _npc;

        private void Awake()
        {
            _npc.Initialized(
                new ITrader[]
                {
                    new NonTradingPattern(),
                    new AppleSellingPattern(3),
                    new AmmoSellingPattern(6)
                }
            );
        }
    }
}
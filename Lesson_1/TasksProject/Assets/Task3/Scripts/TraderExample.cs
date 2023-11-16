using UnityEngine;

namespace Task3.Scripts
{
    public class TraderExample : MonoBehaviour
    {
        [SerializeField] private Npc _npc;
        [SerializeField] private Player _player;
        private TraderBehaviourSwitcher _traderBehaviour;

        private void Awake()
        {
            _traderBehaviour = new TraderBehaviourSwitcher(_npc, _player);
        }
    }
}
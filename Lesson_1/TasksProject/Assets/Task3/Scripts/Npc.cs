using UnityEngine;

namespace Task3.Scripts
{
    public class Npc : MonoBehaviour
    {
        private ITrader _behavior;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) == false)
            {
                return;
            }

            Debug.Log($"Начал общение с {player}.");
            
            _behavior?.Interact(player);
        }

        public void Initialized(ITrader behavior)
        {
            _behavior = behavior;
        }
    }
}
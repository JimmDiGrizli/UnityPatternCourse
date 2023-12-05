using UnityEngine;
using Zenject;

namespace Task_1.Scripts.Player
{
    public class Player : MonoBehaviour, IEnemyTarget
    {
        private int _health;

        public Vector3 Position => transform.position;

        [Inject]
        private void Construct(PlayerStatsConfig playerStatsConfig)
        {
            _health = playerStatsConfig.MaxHealth;
            Debug.Log($"У меня {_health} хп");
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            Debug.Log($"Получил {damage} урона");
        }
    }
}

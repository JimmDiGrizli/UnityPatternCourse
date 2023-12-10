using Task_3.Scripts.SpawnPoints;
using UnityEngine;

namespace Task_3.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CoinSpawner _spawner;

        private void Awake()
        {
            _spawner.StartWork();
        }
    }
}
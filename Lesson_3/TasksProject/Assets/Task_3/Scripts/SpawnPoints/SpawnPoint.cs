using UnityEngine;

namespace Task_3.Scripts.SpawnPoints
{
    public class SpawnPoint : MonoBehaviour
    {
        private Coins.Coin _spawnCoin;

        public void SetCoin(Coins.Coin coin)
        {
            _spawnCoin = coin;
            _spawnCoin.OnPicked += Clean;
        }

        private void Clean()
        {
            _spawnCoin.OnPicked -= Clean;
            _spawnCoin = null;
        }

        public bool IsEmpty() => _spawnCoin is null;
    }
}
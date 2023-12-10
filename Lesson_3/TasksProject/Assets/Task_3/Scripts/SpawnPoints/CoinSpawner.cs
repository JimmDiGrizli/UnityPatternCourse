using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Task_3.Scripts.Coins;
using UnityEngine;
using static UnityEngine.Random;
using Random = System.Random;

namespace Task_3.Scripts.SpawnPoints
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _spawnCooldown = 1;
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        [SerializeField] private CoinFactory _coinFactory;

        private const float BusyRadius = 0.5f;

        private Coroutine _spawn;

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        private IEnumerator Spawn()
        {
            var rnd = new Random();

            while (true)
            {
                yield return new WaitForSeconds(_spawnCooldown);

                var emptyPoints = _spawnPoints.FindAll(point => point.IsEmpty());

                if (emptyPoints.Count == 0) continue;

                var spawnPoint = emptyPoints.ElementAt(rnd.Next(0, emptyPoints.Count));

                var coin = _coinFactory.Get(GetRandomCoinType());
                spawnPoint.SetCoin(coin);
                coin.transform.position = spawnPoint.transform.position;
            }
        }

        private static CoinType GetRandomCoinType() => (CoinType)Range(0, Enum.GetValues(typeof(CoinType)).Length);
    }
}
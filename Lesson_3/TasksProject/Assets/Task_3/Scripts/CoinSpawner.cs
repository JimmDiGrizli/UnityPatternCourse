using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Task_3.Scripts
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _spawnCooldown = 1;
        [SerializeField] private List<Transform> _spawnPoints;
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
                foreach (var point in _spawnPoints.OrderBy(x => rnd.Next()))
                {
                    if (Physics.CheckSphere(point.transform.position, BusyRadius))
                    {
                        continue;
                    }

                    var coin = _coinFactory.Get(
                        (CoinType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CoinType)).Length)
                    );
                    coin.transform.position = point.transform.position;

                    break;
                }

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task_4
{
    public class Spawner : MonoBehaviour, IEnemySpawner, IEnemyDeathNotifier
    {
        public event Action<Enemy.Enemy> DeathNotified;
        public event Action<Enemy.Enemy> Spawned;
        
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;

        private readonly List<Enemy.Enemy> _spawnedEnemies = new List<Enemy.Enemy>();
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

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                Enemy.Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                enemy.Died += OnEnemyDied;
                _spawnedEnemies.Add(enemy);
                
                Spawned?.Invoke(enemy);

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy.Enemy enemy)
        {
            DeathNotified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
        }
    }
}
using System;
using System.Collections.Generic;
using Task_1.Scripts.Pause;
using UnityEngine;
using Zenject;

namespace Task_1.Scripts.Enemies
{
    public class EnemySpawner : IPause, ITickable
    {
        private EnemyFactory _enemyFactory;
        private List<Transform> _spawnPoints;

        private PauseHandler _pauseHandler;
        private bool _isPaused;

        private float _timer;
        private float _spawnCooldown;

        [Inject]
        private void Construct
            (EnemyFactory enemyFactory, PauseHandler pauseHandler, List<Transform> spawnPoints, float spawnCooldown)
        {
            _enemyFactory = enemyFactory;
            _pauseHandler = pauseHandler;
            _spawnPoints = spawnPoints;
            _spawnCooldown = spawnCooldown;

            _pauseHandler.Add(this);
        }

        public void SetPause(bool isPaused) => _isPaused = isPaused;

        public void Tick()
        {
            if (_isPaused)
                return;


            _timer += Time.deltaTime;

            if (_timer < _spawnCooldown)
                return;

            var enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);

            _timer = 0;
        }
    }
}
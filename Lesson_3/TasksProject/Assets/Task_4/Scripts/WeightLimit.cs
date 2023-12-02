using System;
using Task_4.Enemy;
using UnityEngine;

namespace Task_4
{
    public class WeightLimit : IDisposable
    {
        private readonly IEnemySpawner _spawner;
        private readonly IEnemyDeathNotifier _deathNotifier;

        private readonly EnemyVisitor _enemySpawnVisitor;
        private readonly EnemyVisitor _enemyDeathVisitor;

        private readonly int _limit;
        private int _currentWeight;
        private bool _isStopped;

        public WeightLimit(IEnemySpawner spawner, IEnemyDeathNotifier deathNotifier, int limit)
        {
            _spawner = spawner;
            _deathNotifier = deathNotifier;
            _limit = limit;

            _enemySpawnVisitor = new EnemyVisitor(Increase);
            _enemyDeathVisitor = new EnemyVisitor(Decrease);

            _spawner.Spawned += _enemySpawnVisitor.Visit;
            _deathNotifier.DeathNotified += _enemyDeathVisitor.Visit;
        }

        public void Dispose()
        {
            _spawner.Spawned -= _enemySpawnVisitor.Visit;
            _deathNotifier.DeathNotified -= _enemyDeathVisitor.Visit;
        }

        private void Increase(int weight)
        {
            _currentWeight += weight;

            if (_currentWeight >= _limit)
            {
                _spawner.StopWork();
                _isStopped = true;
                
                Debug.Log("Weight limit reached.");
            }
        }

        private void Decrease(int weight)
        {
            _currentWeight -= weight;
            
            if (_currentWeight < _limit && _isStopped)
            {
                _spawner.StartWork();
                _isStopped = false;
                
                Debug.Log("Start spawn again.");
            }
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            private readonly Action<int> _calculate;

            public EnemyVisitor(Action<int> calculate) => _calculate = calculate;

            public void Visit(Ork ork) => _calculate(5);

            public void Visit(Human human) => _calculate(1);

            public void Visit(Elf elf) => _calculate(3);

            public void Visit(Enemy.Enemy enemy) => Visit((dynamic)enemy);
        }
    }
}
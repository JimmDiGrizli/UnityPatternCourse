using System;
using System.IO;
using UnityEngine;
using Zenject;

namespace Task_1.Scripts.Enemies
{
    public class EnemyFactory
    {
        private const string SmallConfig = "SmallConfig";
        private const string MediumConfig = "MediumConfig";
        private const string LargeConfig = "LargeConfig";

        private const string ConfigsPath = "EnemyConfigs";

        private EnemyConfig _small, _medium, _large;

        private readonly DiContainer _container;

        public EnemyFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        public Enemy Get(EnemyType enemyType)
        {
            var config = GetConfig(enemyType);
            var instance = _container.InstantiatePrefabForComponent<Enemy>(config.Prefab);
            instance.Initialize(config.Health, config.Speed);
            return instance;
        }

        private void Load()
        {
            _small = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, SmallConfig));
            _medium = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, MediumConfig));
            _large = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, LargeConfig));
        }

        private EnemyConfig GetConfig(EnemyType enemyType)
        {
            return enemyType switch
            {
                EnemyType.Small => _small,
                EnemyType.Medium => _medium,
                EnemyType.Large => _large,
                _ => throw new ArgumentException(nameof(enemyType))
            };
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Task_1.Scripts.Enemies
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField, Range(0, 10)] private float _spawnCooldown = 1;
        [SerializeField] private List<Transform> _spawnPoints;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyFactory>().AsSingle();
            Container.Bind<ITickable>().To<EnemySpawner>().AsSingle().WithArguments(_spawnCooldown, _spawnPoints);
        }
    }
}

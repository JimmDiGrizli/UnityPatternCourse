using System;
using Task_2.Scripts.Config;
using Task_2.Scripts.View;
using UnityEngine;
using Zenject;

namespace Task_2.Scripts.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private TextView _healthPointView;
        [SerializeField] private TextView _levelView;

        public override void InstallBindings()
        {
            var health = new Property<int>(_playerConfig.HealthPoint);
            var level = new Property<int>(_playerConfig.Level);
            Container.Bind<Player>().AsSingle().WithArguments(health, level);

            Container.Bind<IDisposable>().FromInstance(new PropertyMediator(health, _healthPointView));
            Container.Bind<IDisposable>().FromInstance(new PropertyMediator(level, _levelView));
        }
    }
}
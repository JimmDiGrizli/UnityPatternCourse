using System;
using System.Collections.Generic;
using Task_3.Scripts.Balls;
using Task_3.Scripts.Level;
using Task_3.Scripts.Loader;
using Task_3.Scripts.VictoryPattern;
using Task_3.Scripts.View;
using UnityEngine;
using Zenject;

namespace Task_3.Scripts
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Ball _prefab;
        [SerializeField] private List<BallColor> _colors;
        [SerializeField] private LevelData _levelData;
        [SerializeField] [Space] private GameplayMenuView _menuView;
        [SerializeField] private RuleView _ruleView;

        private LeveLoadingData _data;

        [Inject]
        private void Construct(LeveLoadingData data)
        {
            _data = data;
        }

        public override void InstallBindings()
        {
            BindLevel();
            BindVictoryPattern();
            BindBall();
            BindInput();
        }

        private void BindLevel()
        {
            Container.BindInterfacesAndSelfTo<LevelMediator>().AsSingle().WithArguments(_menuView, _ruleView);

            Container.Bind<LevelData>().FromInstance(_levelData).AsSingle();
            Container.Bind<LevelBuilder>().AsSingle().WithArguments(_levelData, _colors);
            Container.Bind<Level.Level>().AsSingle().NonLazy();
        }

        private void BindVictoryPattern()
        {
            switch (_data.Type)
            {
                case VictoryType.OneColorBalls:
                    Container.BindInterfacesAndSelfTo<OneColorCalculator>().AsSingle();
                    break;

                case VictoryType.AllBall:
                    Container.BindInterfacesAndSelfTo<AllBallsCalculator>().AsSingle();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void BindBall()
        {
            Container.Bind<BallFactory>().AsSingle().WithArguments(_prefab);
            Container.Bind<BallRepository>().AsSingle();
        }

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
    }
}
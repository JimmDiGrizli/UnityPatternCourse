using System;
using System.Collections.Generic;
using Task_3.Scripts.Balls;
using Task_3.Scripts.Loader;
using Task_3.Scripts.VictoryPattern;
using UnityEngine;
using Zenject;

namespace Task_3.Scripts
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private List<BallColor> _colors;

        private LeveLoadingData _data;

        [Inject]
        private void Construct(LeveLoadingData data)
        {
            _data = data;
        }

        public override void InstallBindings()
        {
            Container.Bind<Level>().AsSingle().NonLazy();
            Container.Bind<BallRepository>().AsSingle().WithArguments(_colors);

            BindVictoryPattern();
            BindInput();
        }

        private void BindVictoryPattern()
        {
            switch (_data.Type)
            {
                case VictoryType.OneColorBalls:
                    Container.Bind<IVictoryCalculator>().To<OneColorCalculator>().AsSingle();
                    break;
                
                case VictoryType.AllBall:
                    Container.Bind<IVictoryCalculator>().To<AllBallsCalculator>().AsSingle();
                    break;
            }
        }

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
    }
}
using Task_2.Scripts.View;
using UnityEngine;
using Zenject;

namespace Task_2.Scripts
{
    public class GameInstaller : MonoInstaller
    {
        [Space] [SerializeField] private RestartLevelView _restartLevelView;

        public override void InstallBindings()
        {
            Container.Bind<Gameplay>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartLevelMediator>().AsSingle().WithArguments(_restartLevelView);
        }
    }
}
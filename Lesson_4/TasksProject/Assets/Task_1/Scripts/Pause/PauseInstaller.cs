using Zenject;

namespace Task_1.Scripts.Pause
{
    public class PauseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PauseHandler>().AsSingle();
            Container.Bind<ITickable>().To<InputService>().AsSingle().NonLazy();
        }
    }
}
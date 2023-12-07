using Task_3.Scripts.Loader;
using Zenject;

namespace Task_3.Scripts
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoader();
        }

        private void BindLoader()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoaderMediator>().AsSingle();
        }
    }
}
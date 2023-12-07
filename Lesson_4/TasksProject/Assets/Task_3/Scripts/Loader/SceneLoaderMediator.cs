namespace Task_3.Scripts.Loader
{
    public class SceneLoaderMediator : ISceneLoaderMediator
    {
        private readonly ISimpleSceneLoader _sceneLoader;
        private readonly ILevelLoader _levelLoader;

        public SceneLoaderMediator(ISimpleSceneLoader sceneLoader, ILevelLoader levelLoader)
        {
            _sceneLoader = sceneLoader;
            _levelLoader = levelLoader;
        }

        public void GoToMainMenu() => _sceneLoader.Load(SceneID.MainMenu);

        public void GoToGameplay(LeveLoadingData data) => _levelLoader.Load(data);
    }
}
using System;

namespace Task_3.Scripts.Loader
{
    public class SceneLoader : ISimpleSceneLoader, ILevelLoader
    {
        private readonly ZenjectSceneLoaderWrapper _sceneLoaderWrapper;

        public SceneLoader(ZenjectSceneLoaderWrapper sceneLoaderWrapper)
        {
            _sceneLoaderWrapper = sceneLoaderWrapper;
        }

        public void Load(SceneID sceneID)
        {
            if (sceneID == SceneID.Gameplay)
                throw new ArgumentException($"{SceneID.Gameplay} cannot be started without configuration");

            _sceneLoaderWrapper.Load(null, sceneID);
        }

        public void Load(LeveLoadingData data)
        {
            _sceneLoaderWrapper.Load(container => container.BindInstance(data), SceneID.Gameplay);
        }
    }
}
using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Task_3.Scripts.Loader
{
    public class ZenjectSceneLoaderWrapper
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
        }

        public void Load(Action<DiContainer> action, SceneID id)
        {
            _zenjectSceneLoader.LoadScene((int)id, LoadSceneMode.Single, container => action?.Invoke(container));
        }
    }
}
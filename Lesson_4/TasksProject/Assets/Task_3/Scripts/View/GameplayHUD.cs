using Task_3.Scripts.Loader;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Task_3.Scripts.View
{
    public class GameplayHUD : MonoBehaviour
    {
        [SerializeField] private Button _mainMenu;
        [SerializeField] private Button _restartLevel;

        private SceneLoaderMediator _loader;

        [Inject]
        private void Construct(SceneLoaderMediator sceneLoader)
        {
            _loader = sceneLoader;
        }

        private void OnEnable()
        {
            _mainMenu.onClick.AddListener(OnMainMenuClick);
            _restartLevel.onClick.AddListener(OnRestartLevelClick);
        }

        private void OnDisable()
        {
            _mainMenu.onClick.RemoveListener(OnMainMenuClick);
            _restartLevel.onClick.RemoveListener(OnRestartLevelClick);
        }

        private void OnMainMenuClick() => _loader.GoToMainMenu();


        private void OnRestartLevelClick()
        {
        }
    }
}
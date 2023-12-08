using System;
using Task_3.Scripts.Loader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Task_3.Scripts.View
{
    public class GameplayMenuView : MonoBehaviour
    {
        [SerializeField] private Button _mainMenu;
        [SerializeField] private Button _restartLevel;

        [SerializeField] [Space] private TMP_Text _finalText;
        [SerializeField] private string _winText = "Вы победили!";
        [SerializeField] private string _loseText = "Вы проиграли…";

        private SceneLoaderMediator _loader;
        private LevelMediator _level;

        public event Action OnResetClicked;

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

        public void Show(bool isSuccess)
        {
            gameObject.SetActive(true);
            _finalText.SetText(isSuccess ? _winText : _loseText);
        }

        public void Hide() => gameObject.SetActive(false);

        private void OnMainMenuClick() => _loader.GoToMainMenu();

        private void OnRestartLevelClick() => OnResetClicked?.Invoke();
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task_2.Scripts.View
{
    public class RestartLevelView : MonoBehaviour
    {
        [SerializeField] private Button _restart;

        public event Action OnRestartButtonClicked;

        private void OnEnable() => _restart.onClick.AddListener(OnRestartClick);

        private void OnDisable() => _restart.onClick.RemoveListener(OnRestartClick);

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        private void OnRestartClick() => OnRestartButtonClicked?.Invoke();
    }
}
using Task_3.Scripts.Loader;
using Task_3.Scripts.VictoryPattern;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Task_3.Scripts.View
{
    public class MainMenuHUD : MonoBehaviour
    {
        [SerializeField] private Button _allBalls;
        [SerializeField] private Button _oneColorBalls;
        
        private SceneLoaderMediator _loader;

        [Inject]
        private void Construct(SceneLoaderMediator sceneLoader)
        {
            _loader = sceneLoader;
        }

        private void OnEnable()
        {
            _allBalls.onClick.AddListener(OnAllBallsClick);
            _oneColorBalls.onClick.AddListener(OnOneColorBallsClick);
        }

        private void OnDisable()
        {
            _allBalls.onClick.RemoveListener(OnAllBallsClick);
            _oneColorBalls.onClick.RemoveListener(OnOneColorBallsClick);
        }

        private void OnOneColorBallsClick() => _loader.GoToGameplay(new LeveLoadingData(VictoryType.OneColorBalls));
        

        private void OnAllBallsClick() => _loader.GoToGameplay(new LeveLoadingData(VictoryType.AllBall));
        
    }
}
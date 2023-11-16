using System.Collections.Generic;
using Task4.Scripts.VictoryPattern;
using UnityEngine;
using Random = System.Random;

namespace Task4.Scripts
{
    public class GameExample : MonoBehaviour
    {
        [SerializeField] private List<ColorScriptableObject> _colors;
        private List<Ball> _balls;
        private IVictoryCalculator _victoryCalculator;

        private void Awake()
        {
            _balls = new List<Ball>(FindObjectsOfType<Ball>());
            RunWithOneColor();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) RunWithOneColor();
            if (Input.GetKeyDown(KeyCode.W)) RunWithAllColors();
        }

        private void RunWithAllColors()
        {
            PrepareBalls();
            if (_victoryCalculator is not null) _victoryCalculator.OnFinished -= Finish;
            _victoryCalculator = new AllBallsCalculator(_balls);
            _victoryCalculator.OnFinished += Finish;
        }

        private void RunWithOneColor()
        {
            PrepareBalls();
            if (_victoryCalculator is not null)  _victoryCalculator.OnFinished -= Finish;
            _victoryCalculator = new OneColorCalculator(_balls);
            _victoryCalculator.OnFinished += Finish;
        }

        private void Finish(bool isSuccess)
        {
            Debug.Log(isSuccess ? "Победа!" : "Поражение…");
            _balls.ForEach(ball => ball.gameObject.SetActive(false));
        }

        private void PrepareBalls()
        {
            _balls.ForEach(ball => ball.gameObject.SetActive(true));

            var rnd = new Random();
            _balls.ForEach(ball => ball.SetColor(_colors[rnd.Next(0, _colors.Count)]));
        }
    }
}
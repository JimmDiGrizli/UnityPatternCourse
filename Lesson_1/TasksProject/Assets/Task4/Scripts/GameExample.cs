using System;
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
            _balls.ForEach(ball => ball.OnSelected += color => Interact(color));
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
            _victoryCalculator = new AllBallsCalculator(_balls);
        }

        private void RunWithOneColor()
        {
            PrepareBalls();
            _victoryCalculator = new OneColorCalculator(_balls);
        }

        private void PrepareBalls()
        {
            _balls.ForEach(ball => ball.gameObject.SetActive(true));

            var rnd = new Random();
            _balls.ForEach(ball => ball.SetColor(_colors[rnd.Next(0, _colors.Count)]));
        }

        private void Interact(ColorScriptableObject color)
        {
            switch (_victoryCalculator.Calculate(color))
            {
                case GameState.InProgress:
                    break;
                case GameState.Win:
                    Debug.Log("Победа!");
                    Finish();
                    break;
                case GameState.Loose:
                    Debug.Log("Поражение…");
                    Finish();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Finish() => _balls.ForEach(ball => ball.gameObject.SetActive(false));
    }
}
using System.Collections.Generic;
using Task4.Scripts.VictoryPattern;
using UnityEngine;

namespace Task4.Scripts
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private List<ColorScriptableObject> _colors;

        private List<Ball> _balls;
        private Level _level;

        private void Awake()
        {
            _level = new Level();
            _balls = new List<Ball>(FindObjectsOfType<Ball>());
        }

        private void Start()
        {
            PrepareBalls();
            _level.Run(new OneColorCalculator(_balls));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PrepareBalls();
                _level.Run(new OneColorCalculator(_balls));
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                PrepareBalls();
                _level.Run(new AllBallsCalculator(_balls));
            }
        }

        private void PrepareBalls()
        {
            var rnd = new System.Random();
            foreach (var ball in _balls)
            {
                ball.Prepare(_colors[rnd.Next(0, _colors.Count)]);
            }
        }
    }
}
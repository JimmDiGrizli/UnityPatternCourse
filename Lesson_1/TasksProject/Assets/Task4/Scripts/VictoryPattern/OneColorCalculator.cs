using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task4.Scripts.VictoryPattern
{
    public class OneColorCalculator : IVictoryCalculator
    {
        private readonly ColorScriptableObject _winColor;
        private readonly IReadOnlyCollection<IBall> _balls;
        private int _count;

        public event Action<bool> OnFinished = delegate { };

        public OneColorCalculator(IReadOnlyCollection<IBall> balls)
        {
            _balls = balls;

            foreach (var ball in balls)
            {
                ball.OnSelected += Interact;
            }

            _winColor = balls.First().Color;
            _count = balls.Count(ball => ball.Color == _winColor);

            Debug.Log($"Для победы нужно лопнуть все шары с цветом: {_winColor.Name}");
        }

        private void Interact(ColorScriptableObject color)
        {
            if (color != _winColor)
            {
                Finish(false);
            }

            if (--_count != 0)
            {
                return;
            }

            Finish(true);
        }

        private void Finish(bool isSuccess)
        {
            OnFinished.Invoke(isSuccess);

            foreach (var ball in _balls)
            {
                ball.OnSelected -= Interact;
            }
        }
    }
}
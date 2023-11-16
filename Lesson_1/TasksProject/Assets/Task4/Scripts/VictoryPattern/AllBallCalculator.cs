using System;
using System.Collections.Generic;
using UnityEngine;

namespace Task4.Scripts.VictoryPattern
{
    public class AllBallsCalculator : IVictoryCalculator
    {
        private int _count;
        private readonly IReadOnlyCollection<IBall> _balls;

        public event Action<bool> OnFinished = delegate { };

        public AllBallsCalculator(IReadOnlyCollection<IBall> balls)
        {
            _balls = balls;

            foreach (var ball in balls)
            {
                ball.OnSelected += Interact;
            }

            _count = balls.Count;
            Debug.Log($"Для победы нужно лопнуть все {_count} шары.");
        }

        private void Interact(ColorScriptableObject color)
        {
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
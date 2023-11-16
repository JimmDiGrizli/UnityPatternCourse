using System;
using System.Collections.Generic;

namespace Task4.Scripts.VictoryPattern
{
    public abstract class VictoryCalculator
    {
        private readonly IReadOnlyCollection<IBall> _balls;

        public event Action<bool> OnFinished = delegate { };

        protected VictoryCalculator(IReadOnlyCollection<IBall> balls)
        {
            _balls = balls;

            foreach (var ball in balls)
            {
                ball.OnSelected += Interact;
            }
        }

        protected abstract void Interact(ColorScriptableObject color);

        protected void Finish(bool isSuccess)
        {
            OnFinished.Invoke(isSuccess);

            foreach (var ball in _balls)
            {
                ball.OnSelected -= Interact;
            }
        }
    }
}
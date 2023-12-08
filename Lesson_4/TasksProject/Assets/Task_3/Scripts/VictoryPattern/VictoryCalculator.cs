using System;
using Task_3.Scripts.Balls;

namespace Task_3.Scripts.VictoryPattern
{
    public abstract class VictoryCalculator : IVictoryCalculator
    {
        protected readonly BallRepository _repository;

        public event Action<bool> OnFinished;

        protected VictoryCalculator(BallRepository repository)
        {
            _repository = repository;

            foreach (var ball in _repository.FindAll())
            {
                ball.OnSelected += Interact;
            }
        }

        protected abstract void Interact(BallColor color);

        protected void Finish(bool isSuccess)
        {
            OnFinished?.Invoke(isSuccess);

            foreach (var ball in _repository.FindAll())
            {
                ball.OnSelected -= Interact;
                ball.Deactivate();
            }
        }
    }
}
using Task_3.Scripts.Balls;
using UnityEngine;

namespace Task_3.Scripts.VictoryPattern
{
    public class OneColorCalculator : VictoryCalculator
    {
        private readonly BallColor _winBallColor;
        private int _count;

        public OneColorCalculator(BallRepository repository) : base(repository)
        {
            _winBallColor = _repository.Random();
            _count = _repository.Count(ball => ball.BallColor == _winBallColor);

            Debug.Log($"Для победы нужно лопнуть все шары с цветом: {_winBallColor.Name}");
        }

        protected override void Interact(BallColor color)
        {
            if (color != _winBallColor)
            {
                Finish(false);
            }

            if (--_count != 0)
            {
                return;
            }

            Finish(true);
        }
    }
}
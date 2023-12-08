using Task_3.Scripts.Balls;

namespace Task_3.Scripts.VictoryPattern
{
    public class OneColorCalculator : VictoryCalculator
    {
        private BallColor _winBallColor;
        private int _count;

        public OneColorCalculator(BallRepository repository) : base(repository)
        {
        }

        public override void Start()
        {
            base.Start();

            _winBallColor = _repository.Random().BallColor;
            _count = _repository.Count(ball => ball.BallColor == _winBallColor);
        }

        public override string CurrentRule() => $"Для победы нужно лопнуть все шары с цветом: {_winBallColor.Name}";

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
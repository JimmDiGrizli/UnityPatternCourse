using Task_3.Scripts.Balls;

namespace Task_3.Scripts.VictoryPattern
{
    public class AllBallsCalculator : VictoryCalculator
    {
        private int _count;

        public AllBallsCalculator(BallRepository repository) : base(repository)
        {
        }

        public override void Start()
        {
            base.Start();

            _count = _repository.Count();
        }

        public override string CurrentRule() => $"Для победы нужно лопнуть все {_count} шары.";

        protected override void Interact(BallColor color)
        {
            if (--_count != 0)
            {
                return;
            }

            Finish(true);
        }
    }
}
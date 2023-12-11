using System;
using Task_3.Scripts.VictoryPattern;

namespace Task_3.Scripts.Level
{
    public class Level
    {
        private readonly GridGenerator _builder;
        private readonly IVictoryCalculator _victoryCalculator;

        public event Action OnStarted;
        public event Action<bool> OnFinished;

        public Level(GridGenerator builder, IVictoryCalculator victoryCalculator)
        {
            _builder = builder;
            _victoryCalculator = victoryCalculator;

            Start();
        }

        public void Restart()
        {
            _victoryCalculator.OnFinished -= Finish;
            Start();
        }

        private void Start()
        {
            _builder.Build();
            _victoryCalculator.Start();
            _victoryCalculator.OnFinished += Finish;

            OnStarted?.Invoke();
        }

        private void Finish(bool isSuccess)
        {
            OnFinished?.Invoke(isSuccess);
            _victoryCalculator.OnFinished -= Finish;
        }
    }
}